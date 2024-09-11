using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Web.DAL.Interfaces;
using Web.DAL.Models;
using Web.DAL.Utilities;

namespace Web.DAL.Services
{
    public class IndexService(ILogger logger, IServiceScopeFactory serviceScopeFactory) : IIndexService, IHostedService
    {
        private readonly ConcurrentDictionary<string, ConcurrentDictionary<int, SortedSet<int>>> _index = new();
        private readonly ILogger _logger = logger;
        private readonly IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory;

        private readonly Stopwatch stopwatch = new();
        private bool isInitialized = false;
        public bool IsInitialized() => isInitialized;
        public TimeSpan LoadTime() => stopwatch.Elapsed;

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.Information("Starting initial index build");

            await BuildInitialIndexAsync(cancellationToken);
            isInitialized = true;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            stopwatch.Stop();
            _logger.Information("IndexService is stopping");
            isInitialized = false;
            return Task.CompletedTask;
        }

        public static Task<string[]> Separate(string content)
        {
            // No need for await if there's no asynchronous code here
            return Task.FromResult(TextUtility.SplitText(content));
        }

        public async Task BuildInitialIndexAsync(CancellationToken cancellationToken)
        {
            stopwatch.Start();
            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var documentRepository = scope.ServiceProvider.GetRequiredService<IDocumentRepository>();
                var documents = await documentRepository.GetAllDocumentsWithContentAsync();
                foreach (var document in documents)
                {
                    if (cancellationToken.IsCancellationRequested) break;
                    await IndexDocumentAsync(document);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error during initial index build");
            }
            finally
            {
                stopwatch.Stop();
                _logger.Information("Index build completed in {0:ss\\:fffffff} seconds : ticks", stopwatch.Elapsed);
            }
        }

        public Task IndexDocumentAsync(Document document)
        {
            _logger.Information("Indexing document: {DocumentId}", document.DocumentId);

            var words = TextUtility.SplitText(document.Content);

            for (int position = 0; position < words.Length; position++)
            {
                AddEntry(words[position], position, document.DocumentId);
            }
            return Task.CompletedTask;
        }

        public Task DeleteDocumentAsync(int documentId)
        {
            _logger.Information("Deleting document from index: {DocumentId}", documentId);
            foreach (var wordEntry in _index)
            {
                wordEntry.Value.TryRemove(documentId, out _);
                if (wordEntry.Value.IsEmpty)
                {
                    _index.TryRemove(wordEntry.Key, out _);
                }
            }
            return Task.CompletedTask;
        }

        public Task<IEnumerable<IndexEntry>> SearchAsync(string query)
        {
            _logger.Information("Searching for query: {Query}", query);

            var words = TextUtility.SplitText(query)
                                  .Select(CleanWord)
                                  .Where(w => !string.IsNullOrEmpty(w))
                                  .ToList();

            var results = new ConcurrentBag<IndexEntry>();

            Parallel.ForEach(words, word =>
            {
                if (_index.TryGetValue(word, out var documentsAndPositions))
                {
                    foreach (var docEntry in documentsAndPositions)
                    {
                        results.Add(new IndexEntry(docEntry.Key, docEntry.Value, word));
                    }
                }
            });

            return Task.FromResult(results.AsEnumerable());
        }


        public Task<IEnumerable<IndexEntry>> GetIndexAsync()
        {
            _logger.Information("Returning index.");
            var results = new ConcurrentBag<IndexEntry>();

            foreach (var entry in _index)
            {
                foreach (var docEntry in entry.Value)
                {
                    results.Add(new IndexEntry(docEntry.Key, docEntry.Value, entry.Key));
                }
            }

            return Task.FromResult(results.AsEnumerable());
        }

        private void AddEntry(string word, int position, int documentId)
        {
            word = CleanWord(word);
            if (string.IsNullOrEmpty(word)) return;

            _index.AddOrUpdate(word,
                _ => new ConcurrentDictionary<int, SortedSet<int>> { [documentId] = new SortedSet<int> { position } },
                (_, docDict) =>
                {
                    docDict.AddOrUpdate(documentId,
                        _ => new SortedSet<int> { position },
                        (_, positions) =>
                        {
                            positions.Add(position);
                            return positions;
                        });
                    return docDict;
                });
        }

        private static string CleanWord(string word)
        {
            return string.IsNullOrWhiteSpace(word) ? string.Empty : word.ToLowerInvariant();
        }

        public Task<IndexEntry> GetIndicesInContent(Document doc, IndexEntry entry)
        {
            _logger.Information($"Finding content indices for word '{entry.Word}' in document {doc.DocumentId}");

            var indices = new SortedSet<int>();
            string pattern = $@"\b{Regex.Escape(entry.Word)}\b";
            var matches = Regex.Matches(doc.Content, pattern, RegexOptions.IgnoreCase);

            foreach (Match match in matches)
            {
                indices.Add(match.Index);
            }

            return Task.FromResult(new IndexEntry(entry.DocumentId, indices, entry.Word));
        }
    }
}

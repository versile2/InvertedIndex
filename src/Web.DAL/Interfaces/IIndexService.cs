using System.Threading.Tasks;
using Web.DAL.Models;

namespace Web.DAL.Interfaces
{
    public interface IIndexService
    {
        /// <summary>
        /// Indexes a document, adding its words and their positions to the index.
        /// </summary>
        /// <param name="document">The document to index.</param>
        Task IndexDocumentAsync(Document document);
        /// <summary>
        /// Cause the Index to be completely rebuilt 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task BuildInitialIndexAsync(CancellationToken cancellationToken);
        /// <summary>
        /// Removes a document from the index.
        /// </summary>
        /// <param name="documentId">The ID of the document to remove.</param>
        Task DeleteDocumentAsync(int documentId);

        /// <summary>
        /// Searches the index for documents containing the specified query terms.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <returns>A collection of search results, each containing a document ID and word positions.</returns>
        Task<IEnumerable<IndexEntry>> SearchAsync(string query);
        /// <summary>
        /// Returns the full Search Index
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<IndexEntry>> GetIndexAsync();
        /// <summary>
        /// Swap the index locations from a very fast index lookup to the startIndex inside the actual content
        /// </summary>
        /// <param name="doc">The document containing the content</param>
        /// <param name="entry">The "fast" lookup index</param>
        /// <returns></returns>
        Task<IndexEntry> GetIndicesInContent(Document doc, IndexEntry entry);
        /// <summary>
        /// Returns true when the Index is finished being initialized.
        /// </summary>
        /// <returns></returns>
        bool IsInitialized();
        /// <summary>
        /// Returns the amount of time to initialize the index.
        /// </summary>
        /// <returns></returns>
        TimeSpan LoadTime();
    }
}

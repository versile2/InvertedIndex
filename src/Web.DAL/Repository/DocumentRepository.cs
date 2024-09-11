using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Web.DAL.Data;
using Web.DAL.Interfaces;
using Web.DAL.Models;

namespace Web.DAL.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;
        public DocumentRepository(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            using var context = _dbContextFactory.CreateDbContext();
            context.Initialize();
        }
        public async Task<OperationResult<Document>> DeleteAsync(int documentID)
        {
            using var context = _dbContextFactory.CreateDbContext();
            var document = await context.Documents.FindAsync(documentID);
            if (document == null)
            {
                return OperationResult<Document>.FailureResult(
                    message: $"Document with ID {documentID} not found.",
                    details: "Unable to delete a non-existent document."
                );
            }

            context.Documents.Remove(document);
            await context.SaveChangesAsync();
            return OperationResult<Document>.SuccessResult(document, "Document deleted successfully.");
        }

        public async Task<List<Document>> GetAllDocumentsAsync()
        {
            using var context = _dbContextFactory.CreateDbContext();
            return await context.Documents.ToListAsync();
        }

        public async Task<IReadOnlyList<Document>> GetAllDocumentsWithContentAsync()
        {
            using var context = _dbContextFactory.CreateDbContext();
            var list = await context.Documents.AsNoTracking().ToListAsync();
            foreach (var doc in list)
            {
                await LoadDocDataAsync(context, doc);
            }
            return list;
        }

        public async Task<OperationResult<Document>> GetDocumentWithContentById(int documentId)
        {
            using var context = _dbContextFactory.CreateDbContext();
            var document = await context.Documents.FirstOrDefaultAsync(x => x.DocumentId == documentId);

            if (document != null)
            {
                await LoadDocDataAsync(context, document);
                return OperationResult<Document>.SuccessResult(document, "Document retrieved successfully.");
            }
            else
            {
                return OperationResult<Document>.FailureResult(
                    message: $"Document with ID {documentId} not found.",
                    details: $"A document with the ID {documentId} was requested but could not be found in the database."
                );
            }
        }

        public async Task<OperationResult<Document>> InsertAsync(Document doc)
        {
            using var context = _dbContextFactory.CreateDbContext();
            try
            {
                context.Documents.Add(doc);
                await context.SaveChangesAsync();
                await SaveDocDataAsync(context, doc);
                return OperationResult<Document>.SuccessResult(doc, "Document inserted successfully.");
            }
            catch (Exception ex)
            {
                return OperationResult<Document>.FailureResult(
                    message: "Failed to insert document.",
                    details: ex.Message
                );
            }
        }

        public async Task<OperationResult<Document>> UpdateAsync(Document doc)
        {
            using var context = _dbContextFactory.CreateDbContext();
            try
            {
                context.Entry(doc).State = EntityState.Modified;
                await context.SaveChangesAsync();
                if (doc.Data != null)
                    await SaveDocDataAsync(context, doc);
                return OperationResult<Document>.SuccessResult(doc, "Document updated successfully.");
            }
            catch (Exception ex)
            {
                return OperationResult<Document>.FailureResult(
                    message: "Failed to update document.",
                    details: ex.Message
                );
            }
        }

        private static async Task SaveDocDataAsync(AppDbContext context, Document doc)
        {
            if (doc.Data != null)
            {
                var sql = "UPDATE Documents SET Data = @data WHERE DocumentId = @id";
                var parameters = new[]
                {
                    new SqliteParameter("@data", SqliteType.Blob) { Value = doc.Data },
                    new SqliteParameter("@id", SqliteType.Integer) { Value = doc.DocumentId }
                };
                await context.Database.ExecuteSqlRawAsync(sql, parameters);
            }
        }

        private static async Task LoadDocDataAsync(AppDbContext context, Document doc)
        {
            if (context.Database.GetDbConnection() is not SqliteConnection connection)
            {
                throw new InvalidOperationException("This method requires a SQLite database connection.");
            }

            await context.Database.OpenConnectionAsync();

            try
            {
                using var command = connection.CreateCommand();
                command.CommandText = "SELECT Data FROM Documents WHERE DocumentId = @id";
                command.Parameters.AddWithValue("@id", doc.DocumentId);

                using var reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    if (!reader.IsDBNull(0))
                    {
                        long blobSize = reader.GetBytes(0, 0, null, 0, 0);
                        using var blob = new SqliteBlob(connection, "Documents", "Data", doc.DocumentId);
                        doc.Data = new byte[blobSize];
                        await blob.ReadAsync(doc.Data.AsMemory(0, (int)blobSize));
                    }
                    else
                    {
                        doc.Data = null;
                    }
                }
            }
            finally
            {
                await context.Database.CloseConnectionAsync();
            }
        }
    }
}

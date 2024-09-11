using Web.DAL.Models;

namespace Web.DAL.Interfaces
{
    public interface IDocumentRepository
    {
        Task<List<Document>> GetAllDocumentsAsync();
        Task<IReadOnlyList<Document>> GetAllDocumentsWithContentAsync();
        Task<OperationResult<Document>> GetDocumentWithContentById(int documentID);
        Task<OperationResult<Document>> UpdateAsync(Document doc);
        Task<OperationResult<Document>> InsertAsync(Document doc);
        Task<OperationResult<Document>> DeleteAsync(int documentID);
    }
}

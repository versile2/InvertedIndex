using System.ComponentModel.DataAnnotations;
using Web.DAL.Models;

namespace Web.UI.Data.ViewModels
{
    public class VM_SearchResult
    {
        [Key]
        public Guid UniqueId { get; } = Guid.NewGuid();
        public int DocumentId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public IEnumerable<int> Positions { get; set; }
        public string Word { get; set; }

        public VM_SearchResult(IndexEntry entry, Document? doc)
        {
            FileName = doc?.FileName ?? string.Empty;
            DocumentId = entry.DocumentId;
            Positions = entry.Positions;
            Word = entry.Word;
            UniqueId = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"{Word} in {Positions.Count()} positions in {DocumentId}:{FileName}";
        }
    }
}

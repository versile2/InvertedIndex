namespace Web.DAL.Models
{
    public readonly struct IndexEntry(int documentId, IEnumerable<int> positions, string word)
    {
        public IEnumerable<int> Positions { get; init; } = positions;
        public int DocumentId { get; init; } = documentId;
        public string Word { get; init; } = word;
    }
}

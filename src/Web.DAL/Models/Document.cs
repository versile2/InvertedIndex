using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.DAL.Models
{
    public class Document
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocumentId { get; set; }
        [Required, StringLength(100)]
        public string FileName { get; set; } = default!;
        [Required, StringLength(100)]
        public byte[]? Data { get; set; }
        public string Content
        {
            get
            {
                return Data != null ? System.Text.Encoding.UTF8.GetString(Data) : string.Empty;
            }
        }
    }
}

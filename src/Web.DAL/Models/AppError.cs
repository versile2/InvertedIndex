using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.DAL.Models
{
    public class AppError
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ErrorId { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        [Required, StringLength(50)]
        public string LoggedBy { get; set; } = default!;
        [Required, StringLength(10)]
        public string Type { get; set; } = default!;
        [Required, StringLength(99)]
        public string Message { get; set; } = default!;
        public string Data { get; set; } = string.Empty;

        public int ErrorStatusId { get; set; }
        [ForeignKey(nameof(ErrorStatusId))]
        public ErrorStatus ErrorStatus { get; set; } = default!;
    }
}

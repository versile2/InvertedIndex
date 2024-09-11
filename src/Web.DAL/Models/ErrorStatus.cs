using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.DAL.Models
{
    public class ErrorStatus
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ErrorStatusId { get; set; }
        [Required, StringLength(10)]
        public string ErrorStatusText { get; set; } = default!;
    }
}

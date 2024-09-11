using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.DAL.Models
{
    public class Data_NavLink
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NavLinkId { get; set; }
        public int OrderById { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; } = default!;
        public string? Icon { get; set; }
        [StringLength(299)]
        public string? Href { get; set; }
        [StringLength(299)]
        public string? Role { get; set; }
        [Required]
        public bool IsNewWindow { get; set; } = false;
        [Required]
        public bool IsActive { get; set; } = true;

        // Navigation property for child links
        public List<Data_NavLink> ChildNavLinks { get; set; } = [];

        // Foreign key for parent link
        public int? ParentId { get; set; }

        // Foreign key attribute
        //[ForeignKey("ParentId")]
        public virtual Data_NavLink? ParentNavLink { get; set; }
    }
}

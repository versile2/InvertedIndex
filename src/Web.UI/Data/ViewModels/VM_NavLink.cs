using System.ComponentModel.DataAnnotations;
using Web.DAL.Models;

namespace Web.UI.Data.ViewModels
{
    public class VM_NavLink
    {
        [Key]
        public int NavLinkId { get; set; }
        [Required]
        public int OrderById { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; } = default!;
        public string? Icon { get; set; }
        [StringLength(299)]
        public string? Href { get; set; }
        [MaxLength(299)]
        public string? Role { get; set; }
        [Required]
        public bool IsNewWindow { get; set; } = false;
        [Required]
        public bool IsActive { get; set; } = true;

        // Foreign key for parent link
        public int ParentId { get; set; }

        public VM_NavLink() { }

        public VM_NavLink(Data_NavLink nav)
        {
            NavLinkId = nav.NavLinkId;
            OrderById = nav.OrderById;
            Title = nav.Title;
            Icon = nav.Icon;
            Href = nav.Href;
            Role = nav.Role;
            IsNewWindow = nav.IsNewWindow;
            IsActive = nav.IsActive;
            ParentId = nav.ParentId ?? -1;
        }
    }
}

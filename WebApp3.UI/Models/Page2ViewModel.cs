using System.ComponentModel.DataAnnotations;

namespace WebApp3.UI.Models
{
    public class Page2ViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Mobile Phone")]
        public string MobilePhone { get; set; }
        [Display(Name = "AllowPermission")]
        public bool AllowPermission { get; set; }
    }
}

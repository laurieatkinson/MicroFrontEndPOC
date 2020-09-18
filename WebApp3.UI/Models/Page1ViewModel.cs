using System.ComponentModel.DataAnnotations;

namespace WebApp3.UI.Models
{
    public class Page1ViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}

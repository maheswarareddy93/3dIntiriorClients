using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _3dIntiriorClients.Models
{
    public class RegisterViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(70)]
        [DisplayName("Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use letters only please")]
        public string name { get; set; }
        [Required(ErrorMessage = "Please Enter MobileNo")]
        [Display(Name = "Mobile no")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Mobile Number Must be 10 numbers")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Mobile Number Contains only Numbers")]
        public string mobile { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [StringLength(250)]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*\\.([a-z]{2,4})$", ErrorMessage = "InvalidEmail")]
        public string email { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Location is Required")]
        [DisplayName("Location")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use letters only please")]
        public string location { get; set; }

        public string leadTypeName { get; set; }
        public bool leadType { get; set; }
        public bool leadTypeOwner { get; set; }
    }
}

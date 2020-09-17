using System.ComponentModel.DataAnnotations;

namespace _3dIntiriorClients.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "UserName is Required")]
        [StringLength(250)]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*\\.([a-z]{2,4})$", ErrorMessage = "InvalidEmail")]
        public string email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string password { get; set; }
        public string name { get; set; }
        public string mobile { get; set; }

        public int customerId { get; set; }
    }
}

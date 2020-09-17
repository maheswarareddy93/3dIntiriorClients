using System.ComponentModel.DataAnnotations;

namespace _3dIntiriorClients.Models
{
    public class AdminsInfo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public sbyte? IsActive { get; set; }

        public string Password { get; set; }
    }
}

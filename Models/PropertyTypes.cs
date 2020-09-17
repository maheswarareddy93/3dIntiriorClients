using System.ComponentModel.DataAnnotations;

namespace _3dIntiriorClients.Models
{
    public class PropertyTypes
    {

        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
    }
}

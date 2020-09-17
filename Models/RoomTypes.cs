using System.ComponentModel.DataAnnotations;

namespace _3dIntiriorClients.Models
{
    public class RoomTypes
    {
        [Key]
        public int RoomId { get; set; }

        public string RoomType { get; set; }
    }
}

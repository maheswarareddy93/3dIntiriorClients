using System.ComponentModel.DataAnnotations;

namespace _3dIntiriorClients.Models
{
    public class GallaryImages
    {
        [Key]
        public int GId { get; set; }
        public int RoomTypeID { get; set; }
        public string CreatedDate { get; set; }

        public string UpdatedDate { get; set; }
        public string Images { get; set; }
    }
}

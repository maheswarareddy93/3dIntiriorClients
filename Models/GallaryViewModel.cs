using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3dIntiriorClients.Models
{
    public class GallaryViewModel
    {
        public string RoomType { get; set; }

        public IEnumerable<IFormFile> lstImages { get; set; }

        public int RoomTypeID { get; set; }

        public List<RoomTypes> SelectRoomType { get; set; }

        public GallaryImagesToDB images { get; set; }

        public string Gimages { get; set; }
    }
}

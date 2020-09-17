using _3dIntiriorClients.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3dIntiriorClients.Interface
{
    public interface IGallaryData
    {
        GallaryImages GetGallaryImages(int id);
        bool AddImagesToGallary(GallaryViewModel data);
        bool DeleteImagesFromGallary(string imageId,string roomType);
        List<RoomTypes> GetRoomTypes();
    }
}

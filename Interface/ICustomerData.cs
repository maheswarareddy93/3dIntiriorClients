using _3dIntiriorClients.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3dIntiriorClients.Interface
{
    public interface ICustomerData
    {
        List<PropertyTypes> GetPropertyTypes();
        string ReferenceImagesToDB(Projectdatamodel model);
        List<ProjectDataInfo> GetProjectList(int id);
        //Getting Final 3D View Of Customer by CUUID
        ThreeDInfoViewModel Get3DViewInfo(string id);
    }
}

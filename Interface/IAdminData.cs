using _3dIntiriorClients.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3dIntiriorClients.Interface
{
    public interface IAdminData
    {
        List<CustomerViewModel> GetCustomers();
        ProjectDataInfo GetCustomerData(string cid,string cuuid);

        void UpdateThreeDInfo(ThreeDSpecUpdate specifications);
        
    }
}

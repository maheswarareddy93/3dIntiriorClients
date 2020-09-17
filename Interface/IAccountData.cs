using _3dIntiriorClients.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3dIntiriorClients.Interface
{
    public interface IAccountData
    {
        bool AddUser(RegisterViewModel model);
        bool checkUserExist(string email, string mobile);
        CustomerInfo LoginCheck(string email, string password);
        AdminsInfo AdminLoginCheck(string email, string password);
    }
}

using _3dIntiriorClients.Interface;
using _3dIntiriorClients.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace _3dIntiriorClients.Repository
{
    public class AccountRepositary : IAccountData
    {
        static ApplicationDbContext _context;
        public AccountRepositary(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool AddUser(RegisterViewModel model)
        {
            CustomerInfo objTblcustomer = new CustomerInfo();
            bool flag = false;
            if (checkUserExist(model.email, model.mobile))
            {
                flag = false;
            }
            else
            {
                using (var scope = new TransactionScope())
                {
                    objTblcustomer.Customername = model.name;
                    objTblcustomer.Mobileno = model.mobile;
                    objTblcustomer.Emailid = model.email;
                    objTblcustomer.LeadType = model.leadTypeName;
                    objTblcustomer.IsActive = 0;
                    objTblcustomer.Password = Guid.NewGuid().ToString("N").Substring(0, 8);
                    objTblcustomer.CreatedDate = DateTime.Now.ToString("dd-MM-yyyy");
                    _context.customerInfo.Add(objTblcustomer);
                    _context.SaveChanges();
                    scope.Complete();
                    flag = true;
                   
                }
            }
            return flag;
        }
        public bool checkUserExist(string email, string mobile)
        {
            bool flag = false;
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(mobile))
            {
                var user = _context.customerInfo.Where(x => x.Emailid == email && x.Mobileno == mobile).FirstOrDefault();
                if (user != null)
                {
                    flag = true;
                }
                else { flag = false; }
            }
            return flag;
        }

        public CustomerInfo LoginCheck(string email, string password)
        {
            CustomerInfo customer = _context.customerInfo.Where(x => x.Emailid == email && x.Password == password).FirstOrDefault();
            return customer;
            
        }

        public AdminsInfo AdminLoginCheck(string email, string password)
        {
            AdminsInfo admin = _context.AdminsInfo.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
            return admin;
        }
    }
}

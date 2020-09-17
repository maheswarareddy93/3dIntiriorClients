using System;

namespace _3dIntiriorClients.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class customertest
    {
        public  string Name { get; set; }
        public  string LastName { get; set; }
    }

    public class B: customertest
    {
        
    }
   
    
}

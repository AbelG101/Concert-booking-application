using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Psswd { get; set; }

        public Customer(int customerId, string userName, string fullName, string psswd)
        {
            this.CustomerID = customerId;
            this.UserName = userName;
            this.FullName = fullName;
            this.Psswd = psswd;
        }

        public Customer() { }
    }
}

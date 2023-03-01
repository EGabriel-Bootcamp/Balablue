using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Entity
{
    public class CreateAccount
    {
        public string? UserName { get; set; }
        
        public string? Email { get; set; }
        public string? Age { get; set; }
        
        public string? Phone { get; set; }
        public string AccountNumber { get; set; }

        public string? Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
     public class CustomerVM
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Nic { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public  string BDay { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }

    }
}

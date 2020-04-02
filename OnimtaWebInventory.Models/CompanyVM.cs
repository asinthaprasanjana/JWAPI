using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
    public class CompanyVM
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string VATNo { get; set; }
        public string RegistrationNo { get; set; }
        public int PhoneNo { get; set; }
        public int CreatedUserId { get; set; }
  
        }
}

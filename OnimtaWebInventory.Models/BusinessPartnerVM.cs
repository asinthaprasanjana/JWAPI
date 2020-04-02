using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public class BusinessPartnerVM
    {
        public int CompanyId { get; set;  }
         public int BusinessPartnerId { get; set; }
         public int BusinessPartnerTypeId { get; set; }
        public string Addressing { get; set; }
        public string RegisteredAs { get; set; }
        public string FirstName { get; set; }
         public string LastName { get; set; }
         public string CompanyName { get; set; }
        public string NIC { get; set; }
        public string CompanyCode { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string LandPhoneNo { get; set; }
        public int CreatedUserId { get; set; }
        public int BankId { get; set; }
        public string BranchName { get; set; }
        public string BankName { get; set; }
        public string CompanyOwner { get; set; }
        public string AccountNo { get; set; }
        public int CreditPeriod { get; set; }
        public string VatRegNo { get; set; }
        public string BrcNo { get; set; }
        public int DiscountRate { get; set; }
        public int BspGroupId { get; set; }
        public string GroupName { get; set; }

        public int IsForiegn { get; set; }


        public int IsActive { get; set; }

    }
}

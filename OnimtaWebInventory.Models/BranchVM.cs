using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public class BranchVM
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string DisplayName { get; set; }
        public string BranchType { get; set; }
        public int BranchTypeId { get; set; }
        public int PhoneNo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int CompanyId { get; set; }
        public int CreatedUserId { get; set; }
        public int ProductQuantity { get; set; }
        public IEnumerable<WareHouseVM> wareHouseVM { get; set; }
    }

    public class WareHouseVM
    {
        public int Id { get; set; } 
        public int  WareHouseId { get; set; }
        public int BranchId { get; set; }
        public string Code { get; set; }
        public int Volume { get; set; }

    }


}

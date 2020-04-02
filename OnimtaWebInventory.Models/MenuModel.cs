using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public class MenuModel
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Label { get; set; }
        public string Icon { get; set; }
        public string RouterLink { get; set; }
        public int CompanyId { get; set; }
        public IEnumerable< SubMenuModel> Items { get; set; }
        public IEnumerable<AccessList> accessList { get; set; }
    }

    public class SubMenuModel
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Label { get; set; }
        public string Icon { get; set; }
        public string RouterLink { get; set; }
        public int CompanyId { get; set; }

    }

    public class UserRoleMenuVM{
        public int Id { get; set; }
        public int userRole { get; set; }
        public int Module { get; set; }
        public bool allow { get; set; }
    
    }

    public class AccessList
    {
        public string RouterLink { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
     public class OrganizationSettingVM
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Date { get; set; }
        public int CompanyId { get; set; }

    }

    public class OrganizationBranchVM
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int CompanyId { get; set; }

    }
}

using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.OrganizationSetting
{
    public class OrganizationSettingRequest : BaseRequest
    {
        public OrganizationSettingVM organizationSettingVM { get; set; }

    }
    public class OrganizationBranchRequest : BaseRequest
    {
        public OrganizationBranchVM organizationBranchvm { get; set; }
    }
     public class CompanyRequest : BaseRequest
    {
        public CompanyVM companyVM { get; set; }
    }

}

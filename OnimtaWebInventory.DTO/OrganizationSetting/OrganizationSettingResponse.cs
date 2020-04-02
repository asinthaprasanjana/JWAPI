using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.OrganizationSetting
{
    public class OrganizationSettingResponse : BaseResponse
    {
        public IEnumerable<OrganizationSettingVM> organizationSettingVM { get; set; }
    }

    public class OrganizationBranchResponse : BaseResponse
    {
        public IEnumerable<OrganizationBranchVM> organizationBranchvm { get; set; }
     }

    public class CompanyResponse : BaseResponse
    {
        public IEnumerable<CompanyVM> companyVM { get; set; }
    }
}

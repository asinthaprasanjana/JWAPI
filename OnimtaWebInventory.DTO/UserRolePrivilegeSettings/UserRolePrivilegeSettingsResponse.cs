using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.UserRolePrivilegeSettings
{
   public  class UserRolePrivilegeSettingsResponse :BaseResponse
    {
        public IEnumerable<UserRolePrivilegeSettingsVM> userRolePrivilegeSettingsVM { get; set; }
    }
}

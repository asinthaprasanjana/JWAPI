using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.UserRolePrivilegeSettings
{
  public  class UserRolePrivilegeSettingsRequest : BaseRequest
    {   
        public UserRolePrivilegeSettingsVM userRolePrivilegeSettingsVM { get; set; }

    }
}

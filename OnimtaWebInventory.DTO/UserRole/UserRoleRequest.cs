using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.UserRole
{
  public  class UserRoleRequest : BaseRequest
    {
        public UserRoleVM userRoleVM { get; set; }
        public UserRoleVm userRole { get; set; }
    }
}

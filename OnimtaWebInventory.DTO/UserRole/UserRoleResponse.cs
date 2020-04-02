using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.UserRole
{ 
   public class UserRoleResponse :BaseResponse
    {
        public IEnumerable<UserRoleVM> userRoleVM { get; set; }
        public IEnumerable<UserRoleVm> userRoles { get; set; }
        public UserRoleVm userRole { get; set; }

    }
}

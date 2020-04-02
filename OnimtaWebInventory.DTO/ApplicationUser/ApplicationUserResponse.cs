using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.ApplicationUser
{
   public class ApplicationUserResponse :BaseResponse
    {
        public IEnumerable<ApplicationUserVM> applicationUserVM { get; set; }
        public ApplicationUserVM applicationUserVm { get; set; }
    }
}

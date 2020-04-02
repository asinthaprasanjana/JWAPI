using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.ApplicationUser
{
   public class ApplicationUserRequest :BaseRequest
    {
        public ApplicationUserVM applicationUserVM { get; set; }
      
    }
}

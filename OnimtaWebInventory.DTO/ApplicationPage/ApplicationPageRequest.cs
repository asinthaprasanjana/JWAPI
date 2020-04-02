using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.ApplicationPage
{
   public class ApplicationPageRequest : BaseRequest
    {
        public ApplicationPageVM applicationPageVM { get; set; }
    }
}

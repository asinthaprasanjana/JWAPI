using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.ApplicationPage
{
 public class ApplicationPageResponse :BaseResponse
    {
        public IEnumerable<ApplicationPageVM> applicationPageVM { get; set; }
        public ApplicationPageVM applicationPage { get; set; }

    }
}

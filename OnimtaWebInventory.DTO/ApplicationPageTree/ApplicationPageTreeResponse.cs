using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.ApplicationPageTree
{
   public class ApplicationPageTreeResponse :BaseResponse
    {
        public IEnumerable<ApplicationPageTreeVm>  ApplicationPageTreeVm { get; set; }
    }
}

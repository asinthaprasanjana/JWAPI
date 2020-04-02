using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Customer
{
  public  class CustomerResponse :BaseResponse
    {
        public IEnumerable<CustomerVM> customerVm { get; set; }

    }
}

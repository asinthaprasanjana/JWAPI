using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Menu
{
     public  class MenuResponse : BaseResponse
    {
       public  IEnumerable<MenuModel> menuModel { get; set; }
        public IEnumerable<UserRoleMenuVM> userRoleMenu { get; set; }
        public IEnumerable<AccessList> AccessList { get; set; }

        public Boolean  Allow { get; set; }
    }
}

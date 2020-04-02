using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public  class AdvanceSettingVM
    {
       // public int Id { get; set; }
        public int SettingTypeId { get; set; }
        public int  IsActive { get; set; }
        public int CreatedUserId { get; set; }
    }
}

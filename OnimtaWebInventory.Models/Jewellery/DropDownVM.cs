using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models.Jewellery
{
   public  class DropDownVM
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public string Name { get; set; }
        public string IdName { get; set; }
        public int  Category { get; set; }
        public Boolean IsDeleted { get; set; }
        public Boolean IsActive { get; set; }
        public int numberOfItems { get; set; }
        public string Type { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
    public class ProductLevelVM
    {
        public int Id { get; set; }
        public int ParentLevelId { get; set; }
        public int Level { get; set; }
        public string AttributeName { get; set; }
        public string LevelName { get; set; }

        public string ParentIds { get; set; }

        public IEnumerable<ProductLevelVM> values {get; set; }


    }

    public class IndustryVM
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Level1 { get; set; }
        public string Level2 { get; set; }
        public string Level3 { get; set; }
        public string Level4 { get; set; }
        public string Level5 { get; set; }
       // public Boolean IsDeleted { get; set; }
    }

    public class IndustryLevelVM
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public int Level { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}

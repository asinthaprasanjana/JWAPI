using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
    public class CommonAttributesVM
    {
        public int Id { get; set; }
        public string AttributeName { get; set; }
        public IEnumerable<CommonAttributesValuesVM> Data { get; set; }
        public int ShowAttribute { get; set; }
        public string Type { get; set; }
    }

    public class ValueArray
    {
        public string Name { get; set; }
    }

    public class TypesVM
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class CommonGroupsVM
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string AttributeString { get; set; }
        public IEnumerable<string> Attributes { get; set; }
        public IEnumerable<CommonAttributesVM> AttributesArr {get;set;}
    }
}
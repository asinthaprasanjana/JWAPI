using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
  public  class EmailVM
    {
        public  string ToEmail { get; set; }
        public string  SenderName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int TemplateTypeId { get; set; }
        public string CC { get; set; }

        public string Reference1 { get; set; }
        public string Reference2 { get; set; }
        public string Reference3 { get; set; }
        public string Reference4 { get; set; }
        public string Reference5 { get; set; }



    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
    public class SeasonVM
    {
        public int  Id {get;set;}
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int  CreatedUserId { get; set; }
	     public DateTime CreatedDateTime { get; set; }
         public int  LastModifiedUserId { get; set; }
         public DateTime LastModifiedDateTime { get; set; }

    }
}

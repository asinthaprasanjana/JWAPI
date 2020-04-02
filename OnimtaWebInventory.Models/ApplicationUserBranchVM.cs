using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public class ApplicationUserBranchVM
    {
        public int UserId { get; set; }
        public int BusinessProcessId { get; set; }
        public string Branches { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int LastModifiedUserId { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
       
    }
}

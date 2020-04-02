using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public  class AuditVM
    {
        public int Id { get; set; }
        public int AuditTypeId { get; set; }
        public string AuditName { get; set; }
        public string UserName { get; set; }
        public  int UserId { get; set; }
        public string Date { get; set; }
        public int CrudTypeId { get; set; }
        public string ReferenceNo1 { get; set; }
        public string ReferenceNo2 { get; set; }
        public string Details { get; set; }
    }
}

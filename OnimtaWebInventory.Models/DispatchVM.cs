using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public  class DispatchVM
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int BusinessPartnerId { get; set; }
        public string BusinessPartnerName { get; set; }
        public int DispatchTypeId { get; set; }
        public int BusinessPartnerTypeId { get; set; }
        public string DocumentNo { get; set; }
        public int ReasonId { get; set; }
        public string ReasonName { get; set; }
        public string Comment { get; set; }
        public int CreatedUserId { get; set; }
        public string Date { get; set; }
        public string ReturnDate { get; set; }
        public string RecieveStatus { get; set; }
        public string Reason { get; set; }
        public string ContactDetail { get; set; }
        public  IEnumerable<PurchaseOrderItemVM> PurchaseOrderItemVM { get; set; } 


    }
}

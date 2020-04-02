using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models.Jewellery
{
   public  class JewelleryTransferVM
    {
        public int Id { get; set; }
        public string Remarks { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string DocumentNumber { get; set; }
        public IEnumerable<JewelleryTransferProductsVM> Products { get; set; }
        public Boolean IsCancelled { get; set; }
    }

    public class JewelleryTransferProductsVM
    {
        public int Id { get; set; }
        public int Product { get; set; }
        public int TransferId { get; set; }
        public Boolean IsDeleted { get; set; }
        public JewelleryProductVM ProductObj { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }




}

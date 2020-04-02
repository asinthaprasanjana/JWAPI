using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
  public  class PriceCategoryVM
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int  OrderId { get; set; }
        public int CreatedUserId { get; set; }
        public string UserName { get; set; }
        public string  Date { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public  class ApplicationPageVM
    {
        public int PageId { get; set; }
        public string PageName{ get; set; }
        public  int IsMainMenu  { get; set; }
        public string RouterLink { get; set; }
        public  int MainMenuId { get; set; }
        public int PriorityNo { get; set; }
        public bool IsActive { get; set; }
        public string Icon { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Date { get; set; }

    }
}

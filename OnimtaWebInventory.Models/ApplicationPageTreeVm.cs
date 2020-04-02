using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public class ApplicationPageTreeVm
    {
        public int Id { get; set; }
        public int Data { get; set; }
        public string ExpandedIcon { get; set; }
        public string Label { get; set; }
        public string CollapsedIcon { get; set; }
        public int CompanyId { get; set; }
        public IEnumerable< ApplicationPageTreeChildrenVm> Children { get; set; }

    }

    public class ApplicationPageTreeChildrenVm
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int Data { get; set; }
        public string ExpandedIcon { get; set; }
        public string Label { get; set; }
        public string CollapsedIcon { get; set; }
        public string RouterLink { get; set; }
        public int MainMenuId { get; set; }
        public bool IsMainMenu { get; set; }
    }
}

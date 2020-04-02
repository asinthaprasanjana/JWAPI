using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public class DocumentTypeVm
    {
        public int Id { get; set; }
        public int DocumentTypeId { get; set; }

        public string DocumentTypeName { get; set; }

        public int Number { get; set; }
        public string Text { get; set; }
    
        public string Data { get; set; }

        public string UserName { get; set; }

        public string Date { get; set; }

        public int UserId { get; set; }


    }
}

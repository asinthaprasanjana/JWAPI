using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.DocumentType
{
   public class DocumentTypeResponse :BaseResponse
    {
        public IEnumerable<DocumentTypeVm> documentTypeVm { get; set; }
    }
}

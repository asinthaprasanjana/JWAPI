using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Season
{
   public class SeasonRequest : BaseRequest
    {
        public SeasonVM seasonVM { get; set; }
    }
}

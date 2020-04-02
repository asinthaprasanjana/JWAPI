using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.UserComment
{
   public  class UserCommentRequest : BaseRequest
    {
        public UserCommentVM userCommentVM { get; set; }
    }
}

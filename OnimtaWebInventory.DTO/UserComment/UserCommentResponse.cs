using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.UserComment
{
   public class UserCommentResponse :BaseResponse
    {
        public IEnumerable<UserCommentVM> userCommentVM { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaInventoryCommon
{
   public abstract class  BaseResponse
    {
      
         public bool IsSuccess { get; set; }
         public string Message { get; set; }


    }
}

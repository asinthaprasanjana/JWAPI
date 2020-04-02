using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.ChatBot
{
  public  class ChatBotResponse :BaseResponse
    {
        public IEnumerable<ChatBotVM> chatBotVM { get; set; }

    }
}

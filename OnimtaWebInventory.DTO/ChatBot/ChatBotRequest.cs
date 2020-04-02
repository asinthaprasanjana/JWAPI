using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.ChatBot
{
  public  class ChatBotRequest :BaseRequest
    {
        public ChatBotVM chatBotVM { get; set; }
    }
}

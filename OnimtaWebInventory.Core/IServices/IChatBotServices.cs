using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
    public interface IChatBotServices
    {
        Task<ChatBotVM> AddChatBotQuestion(ChatBotVM chatBotVM);
        Task<ChatBotVM> UpdateChatBotQuestion(ChatBotVM chatBotVM);
        Task<IEnumerable<ChatBotVM>> GetAllChatBotQuestions();
    }
}

using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface IChatBotRepository
    {
        Task<ChatBotVM> AddChatBotQuestion(ChatBotVM chatBotVM);
        Task<ChatBotVM> UpdateChatBotQuestion(ChatBotVM chatBotVM);
        Task<IEnumerable<ChatBotVM>> GetAllChatBotQuestions();

    }
}

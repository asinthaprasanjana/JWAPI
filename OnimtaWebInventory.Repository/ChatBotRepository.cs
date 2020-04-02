using Dapper;
using DBConnect;
using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Repository
{
    public class ChatBotRepository : DBContext,IChatBotRepository
    {
        public async Task<ChatBotVM> AddChatBotQuestion(ChatBotVM chatBotVM)
        {
            ChatBotVM chatBotVm = new ChatBotVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@QuestionBody", chatBotVM.QuestionBody);
                chatBotVM = await dbConnection.QuerySingleOrDefaultAsync<ChatBotVM>("msd.AddChatBotQuestion", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return chatBotVM;
        }

        public async Task<IEnumerable<ChatBotVM>> GetAllChatBotQuestions()
        {
            IEnumerable<ChatBotVM> chatBotVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                chatBotVM = await dbConnection.QueryAsync<ChatBotVM>("msd.GetAllChatBotQuestions", commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return chatBotVM;
        }

        public async Task<ChatBotVM> UpdateChatBotQuestion(ChatBotVM chatBotVM)
        {
            ChatBotVM chatBotVm = new ChatBotVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@QuestionId",chatBotVM.QuestionId);
                dynamicParameterlist.Add("@QuestionBody", chatBotVM.QuestionBody);
                chatBotVM = await dbConnection.QuerySingleOrDefaultAsync<ChatBotVM>("msd.UpdateChatBotQuestion", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return chatBotVM;
        }
    }
}

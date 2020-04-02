using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OnimtaWebInventory.Services
{
    public class ChatBotServices : IChatBotServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public ChatBotServices( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ChatBotVM> AddChatBotQuestion(ChatBotVM chatBotVM)
        {
            ChatBotVM chatBotVm = new ChatBotVM();
            using (_unitOfWork)
            {


                try
                {
                  chatBotVM = await  _unitOfWork.ChatBotRepository.AddChatBotQuestion(chatBotVM);

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

           
                   
            return chatBotVM;
        }

        public async Task<IEnumerable<ChatBotVM>> GetAllChatBotQuestions()
        {
            IEnumerable<ChatBotVM>  chatBotVM;
            using (_unitOfWork)
            {


                try
                {
                  chatBotVM = await  _unitOfWork.ChatBotRepository.GetAllChatBotQuestions();

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

           
            return chatBotVM;
        }

        public async Task<ChatBotVM> UpdateChatBotQuestion(ChatBotVM chatBotVM)
        {

            ChatBotVM chatBotVm = new ChatBotVM();
            using (_unitOfWork)
            {


                try
                {
                 chatBotVM = await  _unitOfWork.ChatBotRepository.UpdateChatBotQuestion(chatBotVM);

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
               
            return chatBotVM;
        }
    }
}

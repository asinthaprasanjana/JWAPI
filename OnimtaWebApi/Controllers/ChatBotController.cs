using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.ChatBot;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class ChatBotController : Controller
    {
        private IChatBotServices _chatBotServices;
        private ILogger<ChatBotController> _logger;

       public ChatBotController(IChatBotServices ChatBotServices, ILogger<ChatBotController> logger)
        {
            _logger = logger;
            _chatBotServices = ChatBotServices;
        }
        [HttpPost]
        public async Task<ChatBotResponse> AddChatBotQuestion([FromBody]ChatBotRequest chatBotRequest)
        {
            ChatBotResponse chatBotResponse = new ChatBotResponse();
            IEnumerable<ChatBotVM> chatBotVM;

            try
            {
                chatBotVM = new List<ChatBotVM> {
                    await _chatBotServices.AddChatBotQuestion(chatBotRequest.chatBotVM)
                };
                chatBotResponse.chatBotVM = chatBotVM;
                chatBotResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                chatBotResponse.IsSuccess = false;
                chatBotResponse.Message = ex.Message;
            }
            return chatBotResponse;
        }

        [HttpPut]
        public async Task<ChatBotResponse> UpdateChatBotQuestion([FromBody]ChatBotRequest chatBotRequest)
        {
            ChatBotResponse chatBotResponse = new ChatBotResponse();
            IEnumerable<ChatBotVM> chatBotVM;

            try
            {
                chatBotVM = new List<ChatBotVM> {
                    await _chatBotServices.UpdateChatBotQuestion(chatBotRequest.chatBotVM)
                };
                chatBotResponse.chatBotVM = chatBotVM;
                chatBotResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                chatBotResponse.IsSuccess = false;
                chatBotResponse.Message = ex.Message;
            }
            return chatBotResponse;
        }

        [HttpGet]
        public async Task<ChatBotResponse> GetAllChatBotQuestions()
        {
            ChatBotResponse chatBotResponse = new ChatBotResponse();
            IEnumerable<ChatBotVM> chatBotVM;
            try
            {

                chatBotVM = await _chatBotServices.GetAllChatBotQuestions();
                chatBotResponse.chatBotVM = chatBotVM;
                chatBotResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                chatBotResponse.IsSuccess = false;
                chatBotResponse.Message = ex.Message;
            }
            return chatBotResponse;
        }
    }
}
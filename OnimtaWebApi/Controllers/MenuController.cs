using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.ApplicationPage;
using OnimtaWebInventory.DTO.Menu;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{

    [Route("api/[controller]/[action]")]

    public class MenuController : Controller
    {
        private IMenuServices _MenuServices;
        private ILogger<MenuController> _logger;

        public MenuController(IMenuServices MenuServices, ILogger<MenuController> logger)
        {
            _MenuServices = MenuServices;
            _logger = logger;
            //_mapper = mapper;
        }

        [HttpGet("{id},{companyId}")]
        public async Task<MenuResponse> GetMenuModelDetailsByUserId(int id, int companyId)
        {
            MenuResponse menuResponse = new MenuResponse();
            IEnumerable<MenuModel> menuModel;
            try
            {
                menuModel = await _MenuServices.GetMenuModelDetailsByUserId(id, companyId);
                menuResponse.menuModel = menuModel;
                menuResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                menuResponse.IsSuccess = false;
                menuResponse.Message = exc.Message;
            }

            return menuResponse;
        }

        [HttpGet]
        public async Task<ApplicationPageResponse> GetMainMenuModelDetails()
        {
            ApplicationPageResponse applicationPageResponse = new ApplicationPageResponse();
            IEnumerable<ApplicationPageVM> applicationPageVM;
            try
            {
                applicationPageVM = await _MenuServices.GetMainMenuModelDetails();
                applicationPageResponse.applicationPageVM = applicationPageVM;
                applicationPageResponse.IsSuccess = true;
            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                applicationPageResponse.IsSuccess = false;
                applicationPageResponse.Message = ex.Message;
            }
            return applicationPageResponse;
        }

        [HttpGet("{userRole}")]
        public async Task<MenuResponse> GetUserRoleMenuDetailsByUserRoleId(int userRole)
        {
            MenuResponse menuResponse = new MenuResponse();
            IEnumerable<MenuModel> menuModel;

            try
            {
                menuModel = await _MenuServices.GetUserRoleMenuDetailsByUserRoleId(userRole);
                menuResponse.AccessList = menuModel.ElementAt(0).accessList;
                menuResponse.menuModel = menuModel;
                menuResponse.IsSuccess = true;
            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                menuResponse.IsSuccess = false;
                menuResponse.Message = ex.Message;
            }

            return menuResponse;
        }


        [HttpGet("{userRole},{module},{actions}")]
        public async Task<MenuResponse> CheckUserRolePermission(int userRole, int module, int actions)
        {
            MenuResponse menuResponse = new MenuResponse();
            Boolean Allow = new Boolean();

            try
            {
                Allow = await _MenuServices.ChekUserRolePermission(userRole, module, actions);
                menuResponse.Allow = Allow;
                menuResponse.IsSuccess = true;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                menuResponse.IsSuccess = false;
                menuResponse.Message = ex.Message;
            }
            return menuResponse;
        }
    }
}
using DBConnect;
using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Services
{
    public class MenuServices : IMenuServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public MenuServices(IMenuRepository IMenuRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ApplicationPageVM>> GetMainMenuModelDetails()
        {
            IEnumerable<ApplicationPageVM> applicationPageVM ;
            using (_unitOfWork)
            {

                applicationPageVM = await _unitOfWork.MenuRepository.GetMainMenuModelDetails();
            }

           
            return applicationPageVM;
        }

        public async Task<IEnumerable<MenuModel>> GetMenuModelDetailsByUserId(int companyId , int userRoleId)
        {
            
                IEnumerable<MenuModel> menuModel;
                IEnumerable<SubMenuModel> subMenuModel;

                int count = 0;

            using (_unitOfWork)
            {


                menuModel = await _unitOfWork.MenuRepository.GetMenuModelDetailsByUserRoleId(userRoleId, companyId);

                if (menuModel.Count() >= 1)
                {
                    for (int i = 0; i < menuModel.Count(); i++)
                    {
                        count++;
                        int pageId = menuModel.ElementAt(i).Id;
                        subMenuModel = await _unitOfWork.MenuRepository.GetSubMenuModelDetailsByMainMenuId(pageId, userRoleId);
                        if (subMenuModel.Count() >= 1)
                        {
                            menuModel.ElementAt(i).Items = subMenuModel;
                        }
                        else
                        {
                            menuModel.ElementAt(i).Items = null;
                        }
                    }
                }
            }
                return menuModel;
            
        }

        public async Task<IEnumerable<MenuModel>> GetUserRoleMenuDetailsByUserRoleId(int userRole)
        {
            IEnumerable<MenuModel> menuModel;

            using (_unitOfWork)
            {
                try
                {
                    menuModel = await _unitOfWork.MenuRepository.GetUserRoleMenuDetailsByUserRoleId(userRole);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return menuModel;
        }


        public async Task<IEnumerable<AccessList>> GetUserRoleAccesList(int userRole)
        {
            IEnumerable<AccessList> accessList;

            using (_unitOfWork)
            {
                try
                {
                    accessList = await _unitOfWork.MenuRepository.GetUserRoleAccesList(userRole);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return accessList;
        }

        public async Task<Boolean> ChekUserRolePermission(int userRole, int module, int actions)
        {
            Boolean bool1 = new Boolean();

            using (_unitOfWork)
            {
                try
                {
                    bool1 = await _unitOfWork.MenuRepository.ChekUserRolePermission(userRole, module, actions);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return bool1;
        }
    }
}

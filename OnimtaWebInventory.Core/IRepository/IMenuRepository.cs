using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface IMenuRepository
    {
        Task<IEnumerable< MenuModel>> GetMenuModelDetailsByUserRoleId(int UserRoleid, int companyId);
        Task<IEnumerable<SubMenuModel>> GetSubMenuModelDetailsByMainMenuId(int id , int UserRoleid);
        Task<IEnumerable<ApplicationPageVM>>GetMainMenuModelDetails();

        Task<IEnumerable<MenuModel>>GetUserRoleMenuDetailsByUserRoleId(int userRole);

        Task<IEnumerable<AccessList>> GetUserRoleAccesList(int userRole);
        Task<Boolean> ChekUserRolePermission(int userRole, int module, int actions);

          


    }
}

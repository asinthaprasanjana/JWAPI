using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
    public interface IMenuServices
    {
        Task<IEnumerable<MenuModel>> GetMenuModelDetailsByUserId( int companyId, int userRoleId);
        Task<IEnumerable<ApplicationPageVM>> GetMainMenuModelDetails();

        Task<IEnumerable<MenuModel>> GetUserRoleMenuDetailsByUserRoleId(int userRole);

        Task<IEnumerable<AccessList>> GetUserRoleAccesList(int userRole);
        Task<Boolean> ChekUserRolePermission(int userRole, int module, int actions);

    }
}

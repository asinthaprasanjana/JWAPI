using Dapper;
using DBConnect;
using Microsoft.EntityFrameworkCore;
using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Repository
{
    public class MenuRepository : DBContext, IMenuRepository
    {
        public async Task<IEnumerable<ApplicationPageVM>> GetMainMenuModelDetails()
        {
            IEnumerable<ApplicationPageVM> applicationPageVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                applicationPageVM = await dbConnection.QueryAsync<ApplicationPageVM>("usm.GetMainMenuModelDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return applicationPageVM;
        }

        public async Task<IEnumerable<MenuModel>> GetMenuModelDetailsByUserRoleId(int userRoleId,int companyId)
        {
            IEnumerable<MenuModel> menuModel;
            try
            {
                var Parameterlist = new DynamicParameters();
                Parameterlist.Add("@UserRoleId", userRoleId);
                Parameterlist.Add("@CompanyId", companyId);
                menuModel = await dbConnection.QueryAsync<MenuModel>("msd.GetMenuDetailsByUserRoleId", Parameterlist, commandType: CommandType.StoredProcedure);
                 return menuModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable< SubMenuModel>> GetSubMenuModelDetailsByMainMenuId(int MainMenuid , int UserRoleId)
        {
            IEnumerable<SubMenuModel> menuModel;
            try
            {
                var Parameterlist = new DynamicParameters();
                Parameterlist.Add( "@MainMenuId", MainMenuid);
                Parameterlist.Add("@UserRoleId", UserRoleId);
                menuModel = await dbConnection.QueryAsync<SubMenuModel>("msd.GetSubMenuDetailsByMainMenuId", Parameterlist, commandType: CommandType.StoredProcedure);
                dbConnection.Close();
                return menuModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<MenuModel>> GetUserRoleMenuDetailsByUserRoleId(int userRole)
        {
            IEnumerable<MenuModel> menuModel;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@userRole", userRole);
                menuModel = await dbConnection.QueryAsync<MenuModel>("[mnu].[GetUserRoleMenuDetailsByUserRoleId]", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                menuModel.ElementAt(0).accessList = await dbConnection.QueryAsync<AccessList>("[mnu].[GetUserRoleAccesList]", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return menuModel;
        }


        public async Task<IEnumerable<AccessList>> GetUserRoleAccesList(int userRole)
        {
            IEnumerable<AccessList> accessList;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@UserRole", userRole);
                accessList = await dbConnection.QueryAsync<AccessList>("[mnu].[GetUserRoleAccesList]", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return accessList;
        }

        public async Task<Boolean> ChekUserRolePermission(int userRole, int module, int actions)
        {
            Boolean bool1 = new Boolean();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@userRole", userRole);
                dynamicParameterlist.Add("@Module", module);
                dynamicParameterlist.Add("@Action", actions);
                bool1 = await dbConnection.QuerySingleOrDefaultAsync<Boolean>("mnu.CheckUserRolePermissions", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                    
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return bool1;
        }
    }
}

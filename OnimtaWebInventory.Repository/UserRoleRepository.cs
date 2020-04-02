using Dapper;
using DBConnect;
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
    public class UserRoleRepository :DBContext, IUserRoleRepository
    {
        public async Task<UserRoleVM> AddUserRolesDetails(UserRoleVM userRoleVM)
        {
            UserRoleVM userRoleVm = new UserRoleVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id",userRoleVM.Id);
                dynamicParameterlist.Add("@RoleId",userRoleVM.RoleId);
                dynamicParameterlist.Add("@CompanyId",userRoleVM.CompanyId);
                dynamicParameterlist.Add("@UserRoleName",userRoleVM.UserRoleName);
                dynamicParameterlist.Add("@PageNameList",userRoleVM.pageNameList);
                dynamicParameterlist.Add("@PageIdList", userRoleVM.pageIdList);
                dynamicParameterlist.Add("@CreatedUserId", userRoleVM.CreatedUserId);

                userRoleVM = await dbConnection.QueryFirstOrDefaultAsync<UserRoleVM>("usm.AddUserRole", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return userRoleVM;
        }

        public async Task<ApplicationPageVM> GetPageDetailsByPageId(int pageId)
        {
            ApplicationPageVM applicationPageVM = new ApplicationPageVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PageId",pageId);

                applicationPageVM = await dbConnection.QueryFirstOrDefaultAsync<ApplicationPageVM>("usm.GetPageDetailsByPageId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return applicationPageVM;
        }

        public async Task<IEnumerable<ApplicationPrivilegeVM>> GetPrivilegesByPageId(int pageId)
        {
            IEnumerable<ApplicationPrivilegeVM> applicationPrivilegeVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PageId", pageId);

                applicationPrivilegeVM = await dbConnection.QueryAsync<ApplicationPrivilegeVM>("msd.GetApplicationPrivilegesByPageId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return applicationPrivilegeVM;
        }

        public async Task<IEnumerable<UserRolePrivilegeSettingsVM>> getUserPrivilegeDetails()
        {
            IEnumerable<UserRolePrivilegeSettingsVM> userRolePrivilegeSettingsVMs;

            try
            {
                userRolePrivilegeSettingsVMs = await dbConnection.QueryAsync<UserRolePrivilegeSettingsVM>("usm.getUserPrivilegeDetails", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return userRolePrivilegeSettingsVMs;
        }

        public async Task<IEnumerable<UserRoleVm>> GetUserRolesDetails()
        {
           IEnumerable <UserRoleVm> userRoleVm ;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
               
                userRoleVm = await dbConnection.QueryAsync<UserRoleVm>("usm.getUserRolesDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);
          }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return userRoleVm;
        }

        public async Task<UserRoleVM> UpdateApplicationUserPrivilegeDetailsByUserId(int userId, string privilegesId)
        {
            UserRoleVM userRoleVM = new UserRoleVM();
            try
            {
                var dynamicParamterlist = new DynamicParameters();
                dynamicParamterlist.Add("@UserId", userId);
                dynamicParamterlist.Add("@PrivilegesId", privilegesId);

                userRoleVM = await dbConnection.QuerySingleOrDefaultAsync<UserRoleVM>("[msd].[UpdateApplicationUserPrivilegeDetailsByUserId]", dynamicParamterlist, _transaction, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return userRoleVM;
        }


        public async Task<IEnumerable<UserRoleVM>> getUserRolesDetailsByPrivilegeId(int companyId,string privilegeId)
        {
            IEnumerable<UserRoleVM> userRoleVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyId", companyId);
                dynamicParameterlist.Add("@PrivilegeId", privilegeId);
                userRoleVM = await dbConnection.QueryAsync<UserRoleVM>("usm.getUserRolesDetailsByPrivilegeId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return userRoleVM;
        }



        public async Task<IEnumerable<UserBranchVm>> UpdateUserBranchDetailsByUserId(UserBranchVm userBranchVm)
        {
            IEnumerable<UserBranchVm> UserBranchVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@UserId", userBranchVm.UserId);
                dynamicParameterlist.Add("@CreatedUserId", userBranchVm.CreatedUserId);
                dynamicParameterlist.Add("@Branches", userBranchVm.Branches);
                dynamicParameterlist.Add("@BusinessProcessId", userBranchVm.BusinessProcessId);


                UserBranchVM = await dbConnection.QueryAsync<UserBranchVm>("usm.UpdateUserBranchDetailsByUserId", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return UserBranchVM;
        }

        public async Task<IEnumerable<UserBranchVm>>DeleteUserBranchDetailsByUserId(UserBranchVm userBranchVm)
        {
            IEnumerable<UserBranchVm> UserBranchVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@UserId", userBranchVm.UserId);
                dynamicParameterlist.Add("@CreatedUserId", userBranchVm.CreatedUserId);
           


                UserBranchVM = await dbConnection.QueryAsync<UserBranchVm>("usm.DeleteUserBranchDetailsByUserId", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return UserBranchVM;
        }

        public async Task<int> UpdateUserRolePrivilegeSettings(int privilegeId, int status,string roleIds)
        {   
          
            int a = 0;
            try
            {
                var dynamicParamterlist = new DynamicParameters();
                dynamicParamterlist.Add("@PrivilegeId", privilegeId);
                dynamicParamterlist.Add("@Status", status);
                dynamicParamterlist.Add("@RoleIds", roleIds);
                await dbConnection.QuerySingleOrDefaultAsync("usm.UpdateUserRolePrivilegeSettings", dynamicParamterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return a;
        }

        public async Task<UserRoleVM> UpdateUserRolesDetailsByUserId(UserRoleVM userRoleVM)
        {
            UserRoleVM userRoleVm = new UserRoleVM();
            try
            {
                var dynamicParamterlist = new DynamicParameters();
                dynamicParamterlist.Add("@UserRoleID",userRoleVM.RoleId);
                dynamicParamterlist.Add("@UserId", userRoleVM.UserId);
                dynamicParamterlist.Add("@UserPrivilegeIds",userRoleVM.PrivilegesId);
                dynamicParamterlist.Add("@CreatedUserId", userRoleVM.CreatedUserId);
                userRoleVM = await dbConnection.QuerySingleOrDefaultAsync<UserRoleVM>("usm.UpdateUserRolesDetailsByUserId", dynamicParamterlist, _transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return userRoleVM;
        }

        public async Task<UserRoleVM> UpdateUserRolesDetailsByUserRoleId(UserRoleVM userRoleVM)
        {
            UserRoleVM userRoleVm = new UserRoleVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@UserRoleID", userRoleVM.RoleId);
                dynamicParameterlist.Add("@PageIds", userRoleVM.pageIdList);
                dynamicParameterlist.Add("@CreatedUserId", userRoleVM.CreatedUserId);
                userRoleVM = await dbConnection.QuerySingleOrDefaultAsync<UserRoleVM>("usm.UpdateUserRolesDetailsByUserRoleId", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return userRoleVM;

        }

        public async Task<IEnumerable<UserRoleVM>> GetUserPrivilegeDetailsByUserId(int userId)
        {
            IEnumerable<UserRoleVM> userRoleVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@UserId", userId);
                userRoleVM = await dbConnection.QueryAsync<UserRoleVM>("msd.GetUserPrivilegeDetailsByUserId", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return userRoleVM;
        }

       

        public async  Task<IEnumerable<UserBranchVm>> GetUserBranchDetailsByuserId(int userId, int businessProcessId)
        {
            IEnumerable<UserBranchVm> userBranchVm ;
            try
            {
                var dynamicParamterlist = new DynamicParameters();
                dynamicParamterlist.Add("@UserId", userId);
                dynamicParamterlist.Add("@BusinessProcessId", businessProcessId);
                userBranchVm = await dbConnection.QueryAsync<UserBranchVm>("usm.GetUserBranchDetailsByUserId", dynamicParamterlist,commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return userBranchVm;
        }

        public async Task<IEnumerable<ModuleVM>> GetModules()
        {
            IEnumerable<ModuleVM> Modules;
           
            try
            {
                var dynamicParamterlist = new DynamicParameters();
                Modules = await dbConnection.QueryAsync<ModuleVM>("mnu.GetModules", dynamicParamterlist, commandType: CommandType.StoredProcedure); 

                for(int i = 0;i< Modules.Count();i++)
                {
                    dynamicParamterlist.Add("@Id", Modules.ElementAt(i).Id);
                    Modules.ElementAt(i).Actions = await dbConnection.QueryAsync<ModuleVM>("mnu.GetActionsOfModule", dynamicParamterlist, commandType: CommandType.StoredProcedure);
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Modules;
        }

        public async Task<UserRoleVm> AddUserRoleDetails(UserRoleVm userRole)
        {
            UserRoleVm UserRole = new UserRoleVm();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Name", userRole.Name);
                dynamicParameterlist.Add("@CreatedUser", userRole.CreatedUser);
                UserRole = await dbConnection.QuerySingleOrDefaultAsync<UserRoleVm>("mnu.AddUserRoleDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

                foreach(ModuleVM perm in userRole.Permissions)
                {
                    var dynamicParameterlist1 = new DynamicParameters();
                    dynamicParameterlist1.Add("@UserRoleId", UserRole.Id);
                    dynamicParameterlist1.Add("@ModuleId", perm.Id);
                    dynamicParameterlist1.Add("@ModuleId", perm.Id);
                    dynamicParameterlist1.Add("@CreatedUserId", userRole.CreatedUser);

                    var dynamicParameterlist2 = new DynamicParameters();
                    dynamicParameterlist2.Add("@UserRoleId", UserRole.Id);
                    dynamicParameterlist2.Add("@ModuleId", perm.Id);
                    dynamicParameterlist2.Add("@AllowModule", perm.Allow);
                    await dbConnection.QuerySingleOrDefaultAsync<UserRoleVm>("mnu.AddUserRoleMenu", dynamicParameterlist2, _transaction, commandType: CommandType.StoredProcedure);

                    foreach (ModuleVM action in perm.Actions)
                    {
                        dynamicParameterlist1.Add("@Allow", action.Allow);
                        dynamicParameterlist1.Add("@Action", action.Id);
                        await dbConnection.QuerySingleOrDefaultAsync<UserRoleVm>("mnu.AddUserRolePermission", dynamicParameterlist1, _transaction, commandType: CommandType.StoredProcedure);
                    }

                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return UserRole;
        }
          
        public async Task<UserRoleVm> UpdateUserRoleDetails(UserRoleVm userRole)
        {
            UserRoleVm userRoles = new UserRoleVm();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", userRole.Id);
                dynamicParameterlist.Add("@Name", userRole.Name);
                dynamicParameterlist.Add("@LastModifiedUserId", userRole.LastModifiedUserId);

                userRoles = await dbConnection.QuerySingleOrDefaultAsync<UserRoleVm>("[mnu].[UpdateUserRoleDetails]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

                foreach (ModuleVM perm in userRole.Permissions)
                {
                    var dynamicParameterlist1 = new DynamicParameters();
                    dynamicParameterlist1.Add("@UserRoleId", userRole.Id);
                    dynamicParameterlist1.Add("@ModuleId", perm.Id);
                    dynamicParameterlist1.Add("@LastModifiedUserId", userRole.CreatedUser);

                    var dynamicParameterlist2 = new DynamicParameters();
                    dynamicParameterlist2.Add("@UserRoleId", userRole.Id);
                    dynamicParameterlist2.Add("@ModuleId", perm.Id);
                    dynamicParameterlist2.Add("@AllowModule", perm.Allow);
                    await dbConnection.QuerySingleOrDefaultAsync<UserRoleVm>("mnu.UpdateUserRoleMenu", dynamicParameterlist2, _transaction, commandType: CommandType.StoredProcedure);

                    foreach (ModuleVM action in perm.Actions)
                    {
                        dynamicParameterlist1.Add("@Allow", action.Allow);
                        dynamicParameterlist1.Add("@Action", action.Id);
                        await dbConnection.QuerySingleOrDefaultAsync<UserRoleVm>("mnu.UpdateUserRolePermission", dynamicParameterlist1, _transaction, commandType: CommandType.StoredProcedure);
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return userRoles;
        }

        public async Task<UserRoleVm> DeleteUserRoleDetails(int id)
        {
            UserRoleVm userRoleVm = new UserRoleVm();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@UserRoleId", id);
                userRoleVm = await dbConnection.QuerySingleOrDefaultAsync<UserRoleVm>("mnu.DeleteUserRoleDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return userRoleVm;
        }

        public async Task<IEnumerable<UserRoleVm>> GetAllUserRoleDetails()
        {
            IEnumerable<UserRoleVm> userRoleVm;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                userRoleVm = await dbConnection.QueryAsync<UserRoleVm>("[mnu].[GetAllUserRoleDetails]", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return userRoleVm;
        }

        public async Task<UserRoleVm> GetUserRoleDetail(int id)
         {
            UserRoleVm userRoleVm = new UserRoleVm();
            UserRoleVm Module = new UserRoleVm();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@UserRoleId", id);
                userRoleVm = await dbConnection.QuerySingleOrDefaultAsync<UserRoleVm>("mnu.GetUserRoleDetail", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                userRoleVm.Permissions = await GetModules();
                
                for(int i=0;userRoleVm.Permissions.Count()>i; i++)
                {
                    var dynamicParameterlist1 = new DynamicParameters();
                    dynamicParameterlist1.Add("@UserRole", id);
                    dynamicParameterlist1.Add("@Module", userRoleVm.Permissions.ElementAt(i).Id);
                    Module = await dbConnection.QuerySingleOrDefaultAsync<UserRoleVm>("mnu.GetUserRoleMenuDetails", dynamicParameterlist1, commandType: CommandType.StoredProcedure);
                    if(Module != null)
                    {
                        userRoleVm.Permissions.ElementAt(i).Allow = Module.Allow;
                    }
                    for (int j=0;userRoleVm.Permissions.ElementAt(i).Actions.Count()>j; j++)
                    {
                        dynamicParameterlist1.Add("@Action", userRoleVm.Permissions.ElementAt(i).Actions.ElementAt(j).Id);
                        Module = await dbConnection.QuerySingleOrDefaultAsync<UserRoleVm>("mnu.GetUserRolePermissionByUserRoleId", dynamicParameterlist1, commandType: CommandType.StoredProcedure);
                        if(Module != null)
                        {
                            userRoleVm.Permissions.ElementAt(i).Actions.ElementAt(j).Allow = Module.Allow;
                        }

                    }
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return userRoleVm;
        }

        public Task<IEnumerable<UserBranchVm>> UpdateUserBranchDetailsByUserId(IEnumerable<UserBranchVm> userBranchVm)
        {
            throw new NotImplementedException();
        }

       
    }
    }
		
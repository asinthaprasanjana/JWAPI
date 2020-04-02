using DBConnect;
using Microsoft.AspNetCore.Hosting;
using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text; 
using System.Threading.Tasks;
using System.Transactions;


namespace OnimtaWebInventory.Services
{
    public class UserRoleServices :  IUserRoleServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public static IList<UserRoleVM> userRoleVM = new List<UserRoleVM>();

        public UserRoleServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserRoleVM> AddUserRolesDetails(UserRoleVM userRoleVM)
        {
                 UserRoleVM userRoleVm = new UserRoleVM();
           
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    userRoleVm = await _unitOfWork.UserRoleRepository.AddUserRolesDetails(userRoleVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }



            return userRoleVm;
        }

        public async Task<IEnumerable<UserRoleVm>> GetUserRolesDetails()
        {
            IEnumerable<UserRoleVm> userRoleVm;
            UserRoleVM tempuserRoleVM = new UserRoleVM();
            string[] PageIdList = new string[1000];

            IEnumerable<ApplicationPageVM> applicationPageVM;

            
               
            using (_unitOfWork)
            {


                try
                {
                 
                     userRoleVm = await _unitOfWork.UserRoleRepository.GetUserRolesDetails();

                                    //for (int i = 0; i < userRoleVM.Count(); i++)
                                    //{
                                    //    string PageNameList = "";
                                    //    int userRoleId = userRoleVM.ToList()[i].RoleId;
                                    //    UserRoleVM userRole = new UserRoleVM();
                                    //    userRole = UserRoleServices.userRoleVM.SingleOrDefault(m => m.RoleId == userRoleId);

                                    //    if(userRole ==null)
                                    //    {
                                    //        applicationPageVM = await _unitOfWork.ApplicationUserRepository.GetApplicationPageDetailsByUserRoleId(userRoleId);
                                    //        for (int x = 0; x < applicationPageVM.Count(); x++)
                                    //        {
                                    //            PageNameList = PageNameList + applicationPageVM.ToList()[x].PageName + " , ";
                                    //        }
                                    //        userRoleVM.ToList()[i].pageNameList = PageNameList;
                                    //        UserRoleServices.userRoleVM.Add(userRoleVM.ToList()[i]);
                                    //    }
                                    //}
                   
                }
                catch (Exception ex)
                {
                   
                    throw new Exception(ex.Message);

                }
            }
            return userRoleVm;
        }


        public async Task<IEnumerable<UserRoleVM>> getUserRolesDetailsByPrivilegeId(int companyId,string privilegeIds)
        {
            IEnumerable<UserRoleVM> userRoleVM;
          
           
            using (_unitOfWork)
            {


                try
                {
                        userRoleVM = await _unitOfWork.UserRoleRepository.getUserRolesDetailsByPrivilegeId(companyId, privilegeIds);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return userRoleVM;
        }


        public async Task<UserRoleVM> UpdateUserRolesDetailsByUserRoleId(UserRoleVM userRoleVM)
        {
            UserRoleVM userRoleVm = new UserRoleVM();
           
                   

            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                      userRoleVm = await _unitOfWork.UserRoleRepository.UpdateUserRolesDetailsByUserRoleId(userRoleVM);
                   
                                    int index = UserRoleServices.userRoleVM.ToList().FindIndex(m => m.RoleId == userRoleVM.RoleId);
                                    if (index >= 0)
                                    {
                                        UserRoleServices.userRoleVM.RemoveAt(index);

                                    }
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }

            return userRoleVM;
        }

        public async Task<UserRoleVM> UpdateUserRolesDetailsByUserId(UserRoleVM userRoleVM)
        {
            UserRoleVM userRoleVm = new UserRoleVM();
           

            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    userRoleVM = await _unitOfWork.UserRoleRepository.UpdateUserRolesDetailsByUserId(userRoleVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }


            return userRoleVM;
        }

        public async Task<IEnumerable<UserBranchVm>> UpdateUserBranchDetailsByUserId(IEnumerable<UserBranchVm> userBranchVms)
        {
            IEnumerable<UserBranchVm> userBranchVMs = new List<UserBranchVm>();
            IEnumerable<UserBranchVm> tempUserBranchVMs = new List<UserBranchVm>();

            

                   
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                         tempUserBranchVMs= await _unitOfWork.UserRoleRepository.DeleteUserBranchDetailsByUserId(userBranchVms.ElementAt(0));
                                            for(int i=0;i<userBranchVms.Count();i++)
                                            {
                                                userBranchVMs = await _unitOfWork.UserRoleRepository.UpdateUserBranchDetailsByUserId(userBranchVms.ElementAt(i));

                                            }
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }

            return userBranchVMs;
        }

        public async Task<UserRoleVM> UpdateApplicationUserPrivilegeDetailsByUserId(int userId, string privilegesId)
        {
            UserRoleVM userRoleVM = new UserRoleVM();
          
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                        userRoleVM = await _unitOfWork.UserRoleRepository.UpdateApplicationUserPrivilegeDetailsByUserId(userId,privilegesId);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return userRoleVM;
        }

        public async Task<int> UpdateUserRolePrivilegeSettings(int privilegeId, int status,string roleIds)
        {
          
            int a = 0;
            
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                await _unitOfWork.UserRoleRepository.UpdateUserRolePrivilegeSettings(privilegeId, status, roleIds);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return a;
        }

        public async Task<IEnumerable<UserRolePrivilegeSettingsVM>> getUserPrivilegeDetails()
        {
            IEnumerable<UserRolePrivilegeSettingsVM> userRolePrivilegeSettingsVMs;

          
            using (_unitOfWork)
            {


                try
                {
                userRolePrivilegeSettingsVMs = await _unitOfWork.UserRoleRepository.getUserPrivilegeDetails();

                    
                }
                catch (Exception ex)
                {
                  
                    throw new Exception(ex.Message);

                }
            }

            return userRolePrivilegeSettingsVMs;
        }

        public async Task<IEnumerable<UserRoleVM>> GetUserPrivilegeDetailsByUserId(int userId)
        {
           IEnumerable <UserRoleVM> userRoleVM ;
           
            using (_unitOfWork)
            {


                try
                {
                userRoleVM = await _unitOfWork.UserRoleRepository.GetUserPrivilegeDetailsByUserId(userId);

                   
                }
                catch (Exception ex)
                {
                   
                    throw new Exception(ex.Message);

                }
            }

            return userRoleVM;
        }

        public async Task<IEnumerable<UserBranchVm>> GetUserBranchDetailsByuserId(int userId, int businessProcessId)
        {
            IEnumerable<UserBranchVm> userBranchVm;
           
            using (_unitOfWork)
            {


                try
                {
                   
                userBranchVm = await _unitOfWork.UserRoleRepository.GetUserBranchDetailsByuserId(userId,businessProcessId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return userBranchVm;
        }

        public async Task<IEnumerable<ModuleVM>> GetModules()
        {
            IEnumerable<ModuleVM> modules;

            using (_unitOfWork)
            {
                try
                {
                    modules = await _unitOfWork.UserRoleRepository.GetModules();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return modules;
        }

        // --------------JEWELLERY -------------------/////////////

        public async Task<UserRoleVm> AddUserRoleDetails(UserRoleVm userRole)
        {
            UserRoleVm userRoles = new UserRoleVm();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    userRoles = await _unitOfWork.UserRoleRepository.AddUserRoleDetails(userRole);
                    _unitOfWork.CommitTransaction();

                }catch(Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return userRoles;
        }

        public async Task<UserRoleVm> UpdateUserRoleDetails(UserRoleVm userRole)
        {
            UserRoleVm userRoles = new UserRoleVm();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    userRoles = await _unitOfWork.UserRoleRepository.UpdateUserRoleDetails(userRole);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return userRoles;
        }

        public async Task<UserRoleVm> DeleteUserRoleDetails(int id)
        {
            UserRoleVm userRoleVm = new UserRoleVm();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    userRoleVm = await _unitOfWork.UserRoleRepository.DeleteUserRoleDetails(id);
                    _unitOfWork.CommitTransaction();

                }catch(Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }

            return userRoleVm;
        }

        public async  Task<IEnumerable<UserRoleVm>> GetAllUserRoleDetails()
        {
            IEnumerable<UserRoleVm> userRoleVm;
            
            using (_unitOfWork)
            {
                try
                {
                    userRoleVm = await _unitOfWork.UserRoleRepository.GetAllUserRoleDetails();

                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return userRoleVm;
        }

        public async Task<UserRoleVm> GetUserRoleDetail(int id)
        {
            UserRoleVm userRoleVm = new UserRoleVm();

            using (_unitOfWork)
            {
                try
                {
                    userRoleVm = await _unitOfWork.UserRoleRepository.GetUserRoleDetail(id);

                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return userRoleVm;
        }

    }
}

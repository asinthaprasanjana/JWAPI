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
   public class PageSettingRepository : DBContext,IPageSettingRepository 
    {
        public async Task<ApplicationPageVM> AddNewApplicationPagesAsync(ApplicationPageVM applicationPageVM)
        {
            ApplicationPageVM applicationPageVm = new ApplicationPageVM();
            try
            {
                var dynamicParam = new DynamicParameters();
                dynamicParam.Add("@PageName", applicationPageVM.PageName);
                dynamicParam.Add("@RouterLink", applicationPageVM.RouterLink);
                dynamicParam.Add("@Icon", applicationPageVM.Icon);
                dynamicParam.Add("@PriorityNo", applicationPageVM.PriorityNo);
                dynamicParam.Add("@IsMainMenu", applicationPageVM.IsMainMenu);
                dynamicParam.Add("@MainMenuId", applicationPageVM.MainMenuId);
                dynamicParam.Add("@ExpirationDate", applicationPageVM.ExpirationDate);
                dynamicParam.Add("@IsActive", applicationPageVM.IsActive);
                applicationPageVm = await dbConnection.QuerySingleOrDefaultAsync<ApplicationPageVM>("msd.AddApplicationPage", dynamicParam, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return applicationPageVm;
        }

        public async Task<ApplicationPageVM> UpdateSelectedPage(ApplicationPageVM applicationPageVM)
        {
            ApplicationPageVM applicationPageVm = new ApplicationPageVM();
            try
            {
                var dynamicParam = new DynamicParameters();
                dynamicParam.Add("@PageId", applicationPageVM.PageId);
                dynamicParam.Add("@PageName", applicationPageVM.PageName);
                dynamicParam.Add("@RouterLink", applicationPageVM.RouterLink);
                dynamicParam.Add("@Icon", applicationPageVM.Icon);
                dynamicParam.Add("@IsMainMenu", applicationPageVM.IsMainMenu);
                dynamicParam.Add("@MainMenuId", applicationPageVM.MainMenuId);
                dynamicParam.Add("@PriorityNo", applicationPageVM.PriorityNo);
                dynamicParam.Add("@IsActive", applicationPageVM.IsActive);
                dynamicParam.Add("@ExpirationDate", applicationPageVM.ExpirationDate);

                applicationPageVm = await dbConnection.QuerySingleOrDefaultAsync<ApplicationPageVM>("msd.UpdateSelectedPage", dynamicParam, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return applicationPageVm;
        }
    }
}

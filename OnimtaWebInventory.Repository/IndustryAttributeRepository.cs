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
    public class IndustryAttributeRepository : DBContext, IIndustryAttributeRepository
    {
        public async Task<IndustryVM> AddIndustryAttributeDetails(IndustryVM industryVM)
        {
            IndustryVM industryVm = new IndustryVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("Name", industryVM.Name);
                dynamicParameterlist.Add("Level1", industryVM.Level1);
                dynamicParameterlist.Add("Level2", industryVM.Level2);
                dynamicParameterlist.Add("Level3", industryVM.Level3);
                dynamicParameterlist.Add("Level4", industryVM.Level4);
                dynamicParameterlist.Add("Level5", industryVM.Level5);
                industryVM = await dbConnection.QuerySingleOrDefaultAsync<IndustryVM>("msd.AddIndustry", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return industryVM;
        }

        public async Task<IEnumerable<IndustryVM>> GetAllIndustryAttributeDetails()
        {
            IEnumerable<IndustryVM> industryVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                industryVM = await dbConnection.QueryAsync<IndustryVM>("msd.GetAllIndustries", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return industryVM;
        }

        public async Task<IEnumerable<IndustryNameVM>> GetIndustryName()
        {
            IEnumerable<IndustryNameVM> industryNameVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                industryNameVM = await dbConnection.QueryAsync<IndustryNameVM>("msd.GetIndustryName", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return industryNameVM;
        }

        public async Task<IndustryVM> UpdateIndustryAttributeDetails(IndustryVM industryVM)
        {
            IndustryVM industryVm = new IndustryVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", industryVM.id);
                dynamicParameterlist.Add("@Name", industryVM.Name);
                industryVM = await dbConnection.QuerySingleOrDefaultAsync<IndustryVM>("msd.UpdateIndustry", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return industryVM;
        }
    }
}

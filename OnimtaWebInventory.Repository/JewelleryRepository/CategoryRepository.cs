using Dapper;
using DBConnect;
using OnimtaWebInventory.Core.IRepository.IJewelleryRepository;
using OnimtaWebInventory.Models.Jewellery;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Repository.JewelleryRepository
{
    public class CategoryRepository : DBContext, ICategoryRepository
    {

        public async Task<IEnumerable<CategoryVM>> GetAllJewelleryCategoriesDesign()
        {
            IEnumerable<CategoryVM> categoryVm ;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                    categoryVm = await dbConnection.QueryAsync<CategoryVM>("msd.GetAllJewelleryCategoriesDesign", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return categoryVm;
        }

        public async Task<IEnumerable<CategoryVM>> GetAllJewelleryCategoriesItem()
        {
            IEnumerable<CategoryVM> categoryVm;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                categoryVm = await dbConnection.QueryAsync<CategoryVM>("msd.GetAllJewelleryCategoriesItem", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return categoryVm;
        }

        public async Task<IEnumerable<CategoryVM>> GetAllJewelleryCategoriesGem()
        {
            IEnumerable<CategoryVM> categoryVm;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                categoryVm = await dbConnection.QueryAsync<CategoryVM>("msd.GetAllJewelleryCategoriesGem", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return categoryVm;
        }

        public async Task<IEnumerable<CategoryVM>> GetAllJewelleryCategoriesMaterial()
        {
            IEnumerable<CategoryVM> categoryVm;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                categoryVm = await dbConnection.QueryAsync<CategoryVM>("msd.GetAllJewelleryCategoriesMaterial", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return categoryVm;
        }

        public async Task<CategoryVM> AddDesignCategoryDetails(CategoryVM categoryVM)
        {
            CategoryVM categoryVm = new CategoryVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Code", categoryVM.Code);
                dynamicParameterlist.Add("@Name", categoryVM.Name);
                dynamicParameterlist.Add("@IsDeleted", categoryVM.IsDeleted);
                categoryVm = await dbConnection.QuerySingleOrDefaultAsync<CategoryVM>("msd.AddDesignCategoryDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return categoryVm;
        }

        public async Task<CategoryVM> AddGemCategoryDetails(CategoryVM categoryVM)
        {
            CategoryVM categoryVm = new CategoryVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Code", categoryVM.Code);
                dynamicParameterlist.Add("@Name", categoryVM.Name);
                dynamicParameterlist.Add("@IsDeleted", categoryVM.IsDeleted);
                categoryVm = await dbConnection.QuerySingleOrDefaultAsync<CategoryVM>("msd.AddGemCategoryDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return categoryVm;
        }

        public async Task<CategoryVM> AddItemCategoryDetails(CategoryVM categoryVM)
        {
            CategoryVM categoryVm = new CategoryVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Code", categoryVM.Code);
                dynamicParameterlist.Add("@Name", categoryVM.Name);
                dynamicParameterlist.Add("@IsDeleted", categoryVM.IsDeleted);
                categoryVm = await dbConnection.QuerySingleOrDefaultAsync<CategoryVM>("msd.AddItemCategoryDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return categoryVm;
        }

        public async Task<CategoryVM> AddMaterialCategoryDetails(CategoryVM categoryVM)
        {
            CategoryVM categoryVm = new CategoryVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Code", categoryVM.Code);
                dynamicParameterlist.Add("@Name", categoryVM.Name);
                dynamicParameterlist.Add("@IsDeleted", categoryVM.IsDeleted);
                categoryVm = await dbConnection.QuerySingleOrDefaultAsync<CategoryVM>("msd.AddMaterialCategoryDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return categoryVm;
        }

        public async Task<CategoryVM> DeleteDesignCategoryDetails(int id)
        {
            CategoryVM categoryVm = new CategoryVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@DesignId",id);
                categoryVm = await dbConnection.QuerySingleOrDefaultAsync<CategoryVM>("msd.DeleteDesignCategoryDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return categoryVm;
        }

        public async Task<CategoryVM> DeleteGemCategoryDetails(int id)
        {
            CategoryVM categoryVm = new CategoryVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@GemId",id);
                categoryVm = await dbConnection.QuerySingleOrDefaultAsync<CategoryVM>("msd.DeleteGemCategoryDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return categoryVm;
        }

        public async Task<CategoryVM> DeleteItemCategoryDetails(int id)
        {
            CategoryVM categoryVm = new CategoryVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@ItemId", id);
                categoryVm = await dbConnection.QuerySingleOrDefaultAsync<CategoryVM>("msd.DeleteItemCategoryDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return categoryVm;
        }

        public async Task<CategoryVM> DeleteMaterialCategoryDetails(int id)
        {
            CategoryVM categoryVm = new CategoryVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@MaterialId",id);
                categoryVm = await dbConnection.QuerySingleOrDefaultAsync<CategoryVM>("msd.DeleteMaterialCategoryDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return categoryVm;
        }

    

        public async Task<CategoryVM> UpdateDesignCategoryDetails(CategoryVM categoryVM)
        {
            CategoryVM categoryVm = new CategoryVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", categoryVM.Id);
                dynamicParameterlist.Add("@Code", categoryVM.Code);
                dynamicParameterlist.Add("@Name", categoryVM.Name);
                dynamicParameterlist.Add("@IsDeleted", categoryVM.IsDeleted);
                categoryVm = await dbConnection.QuerySingleOrDefaultAsync<CategoryVM>("msd.UpdateDesignCategoryDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return categoryVm;
        }

        public async Task<CategoryVM> UpdateGemCategoryDetails(CategoryVM categoryVM)
        {
            CategoryVM categoryVm = new CategoryVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", categoryVM.Id);
                dynamicParameterlist.Add("@Code", categoryVM.Code);
                dynamicParameterlist.Add("@Name", categoryVM.Name);
                dynamicParameterlist.Add("@IsDeleted", categoryVM.IsDeleted);
                categoryVm = await dbConnection.QuerySingleOrDefaultAsync<CategoryVM>("msd.UpdateGemCategoryDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return categoryVm;
        }

        public async Task<CategoryVM> UpdateItemCategoryDetails(CategoryVM categoryVM)
        {
            CategoryVM categoryVm = new CategoryVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", categoryVM.Id);
                dynamicParameterlist.Add("@Code", categoryVM.Code);
                dynamicParameterlist.Add("@Name", categoryVM.Name);
                dynamicParameterlist.Add("@IsDeleted", categoryVM.IsDeleted);
                categoryVm = await dbConnection.QuerySingleOrDefaultAsync<CategoryVM>("msd.UpdateItemCategoryDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return categoryVm;
        }

        public async Task<CategoryVM> UpdateMaterialCategoryDetails(CategoryVM categoryVM)
        {
            CategoryVM categoryVm = new CategoryVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", categoryVM.Id);
                dynamicParameterlist.Add("@Code", categoryVM.Code);
                dynamicParameterlist.Add("@Name", categoryVM.Name);
                dynamicParameterlist.Add("@IsDeleted", categoryVM.IsDeleted);
                categoryVm = await dbConnection.QuerySingleOrDefaultAsync<CategoryVM>("msd.UpdateMaterialCategoryDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return categoryVm;
        }
    }
}

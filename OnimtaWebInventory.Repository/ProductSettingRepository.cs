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
using System.Transactions;

namespace OnimtaWebInventory.Repository
{
    public class ProductSettingRepository : DBContext, IProductSettingRepository
    {
        public async Task<CommonAttributesVM> AddcommonAttribute(CommonAttributesVM commonAttributes)
        {
            CommonAttributesVM CommonAttributes= new CommonAttributesVM();

            try
            {

                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var dynamicParameterlist = new DynamicParameters();
                    dynamicParameterlist.Add("@AttributeName", commonAttributes.AttributeName);
                    dynamicParameterlist.Add("@Type", commonAttributes.Type);
                    dynamicParameterlist.Add("@showAttribute", commonAttributes.ShowAttribute);

                    CommonAttributes = await dbConnection.QuerySingleOrDefaultAsync<CommonAttributesVM>("msd.AddCommonAttribute", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

                    if (commonAttributes.Data.Count() > 0)
                    {
                        foreach (CommonAttributesValuesVM value in commonAttributes.Data)
                        {
                            var dynamicparameterlist2 = new DynamicParameters();
                            dynamicparameterlist2.Add("@AttributeId", CommonAttributes.Id);
                            dynamicparameterlist2.Add("@value", value.Data);
                            CommonAttributes.Data = await dbConnection.QueryAsync<CommonAttributesValuesVM>("msd.addcommonattributedata", dynamicparameterlist2, _transaction, commandType: CommandType.StoredProcedure);

                        }
                    }

                    scope.Complete();
                    scope.Dispose();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return CommonAttributes;
        }

        public async Task<CommonGroupsVM> AddCommonGroup(CommonGroupsVM commonGroup)
        {
            CommonGroupsVM CommonGroup = new CommonGroupsVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@GroupName", commonGroup.GroupName);
                CommonGroup = await dbConnection.QuerySingleOrDefaultAsync<CommonGroupsVM>("msd.AddCommonGroup", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return CommonGroup;
        }

        public async Task<ProductLevelVM> AddProductLevel(ProductLevelVM ProductLevelVM)
        {
            ProductLevelVM productLevelVM = new ProductLevelVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@ParentLevelId", ProductLevelVM.ParentLevelId);
                dynamicParameterlist.Add("@Level", ProductLevelVM.Level);
                dynamicParameterlist.Add("@AttributeName", ProductLevelVM.AttributeName);
                dynamicParameterlist.Add("@LevelName", ProductLevelVM.LevelName);

                productLevelVM = await dbConnection.QuerySingleOrDefaultAsync<ProductLevelVM>("msd.AddProductLevel", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch(Exception ex){

                throw new Exception(ex.Message);
            }
            return productLevelVM;
        }

        public async Task<IEnumerable<IndustryVM>> GetAllIndustries()
        {
            IEnumerable<IndustryVM> industries;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                industries = await dbConnection.QueryAsync<IndustryVM>("msd.GetAllIndustries", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return industries;
        }

        public async Task<CommonAttributesVM> GetCommonAttributeById(int id)
        {
            CommonAttributesVM commonAttribute = new CommonAttributesVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@AttributeId", id);
                commonAttribute = await dbConnection.QueryFirstOrDefaultAsync<CommonAttributesVM>("msd.GetCommonAttributeByid", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                commonAttribute.Data = await dbConnection.QueryAsync<CommonAttributesValuesVM>("msd.GetCommonAttributeDataByAttributeId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return commonAttribute;
        }

        public async Task<IEnumerable<CommonAttributesValuesVM>> GetCommonAttributeData(int attributeId)
        {
            IEnumerable<CommonAttributesValuesVM> commonAttributesValues;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@AttributeId", attributeId);
                commonAttributesValues = await dbConnection.QueryAsync<CommonAttributesValuesVM>("msd.GetCommonAttributeData", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return commonAttributesValues;
        }

        public async Task<IEnumerable<CommonAttributesVM>> GetCommonAttributeDetails(int filter)
        {
            IEnumerable<CommonAttributesVM> commonAttributes;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@filter", filter);
                commonAttributes = await dbConnection.QueryAsync<CommonAttributesVM>("msd.GetCommonAttributesDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return commonAttributes;
        }

        public async Task<IEnumerable<CommonGroupsVM>> GetCommonGroups()
        {
            IEnumerable<CommonGroupsVM> commonGroups;

            try
            {
                commonGroups = await dbConnection.QueryAsync<CommonGroupsVM>("msd.GetCommonGroups", null, commandType: CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return commonGroups;
        }

        public async Task<IEnumerable<IndustryLevelVM>> GetIndustryProductLevel(int parentId, int level)
        {
            IEnumerable<IndustryLevelVM> industryLevels;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@ParentId", parentId);
                dynamicParameterlist.Add("@Level", level);
                industryLevels = await dbConnection.QueryAsync<IndustryLevelVM>("msd.GetIndustryProductLevel", dynamicParameterlist, commandType: CommandType.StoredProcedure);

                foreach (IndustryLevelVM value in industryLevels)
                {
                    value.Level = level;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return industryLevels;
        }

        public async Task<IEnumerable<ProductLevelVM>> GetProductLevelDetails(ProductLevelVM ProductLevelVM)

       {
           IEnumerable< ProductLevelVM> productLevelVM ;
            try
            {

                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@LevelNo", ProductLevelVM.Level);
                dynamicParameterlist.Add("@parentId", ProductLevelVM.ParentIds);
                productLevelVM = await dbConnection.QueryAsync<ProductLevelVM>("msd.GetProductLevelDetailsbyLevelId", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return productLevelVM;
        }

        public async Task<CommonAttributesVM> UpdateCommonAttribute(CommonAttributesVM commonAttributes)
        {
            CommonAttributesVM CommonAttributes = new CommonAttributesVM();

            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var dynamicParameterlist = new DynamicParameters();
                    dynamicParameterlist.Add("@Id", commonAttributes.Id);
                    dynamicParameterlist.Add("@AttributeName", commonAttributes.AttributeName);
                    dynamicParameterlist.Add("@Type", commonAttributes.Type);
                    dynamicParameterlist.Add("@showAttribute", commonAttributes.ShowAttribute);
                    CommonAttributes = await dbConnection.QuerySingleOrDefaultAsync<CommonAttributesVM>("msd.UpdateCommonAttributes", dynamicParameterlist, commandType: CommandType.StoredProcedure);

                    //Delete Attribute Data
                    var attributeId = new DynamicParameters();
                    attributeId.Add("@AttributeId", commonAttributes.Id);
                    await dbConnection.QuerySingleOrDefaultAsync<CommonAttributesVM>("msd.DeleteCommonAttributeData", attributeId, _transaction, commandType: CommandType.StoredProcedure);

                    //Adde new Data if any
                    if (commonAttributes.Data.Count() > 0)
                    {
                        foreach (CommonAttributesValuesVM value in commonAttributes.Data)
                        {
                            var data = new DynamicParameters();
                            data.Add("@AttributeId", commonAttributes.Id);
                            data.Add("@value", value.Data);
                             await dbConnection.QueryAsync<CommonAttributesValuesVM>("msd.UpdateCommonAttributeData", data, _transaction, commandType: CommandType.StoredProcedure);

                        }
                    }

                    scope.Complete();
                    scope.Dispose();
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return commonAttributes;
        }

        public async Task<CommonGroupsVM> UpdateCommonGroup(CommonGroupsVM group)
        {
            CommonGroupsVM commonGroup = new CommonGroupsVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", group.Id);
                dynamicParameterlist.Add("@GroupName", group.GroupName);
                dynamicParameterlist.Add("@Attributes", group.AttributeString);
                commonGroup = await dbConnection.QuerySingleOrDefaultAsync<CommonGroupsVM>("msd.UpdateCommonGroup", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return group;
        }

        public async Task<IndustryLevelVM> UpdateIndustryProductLevel(IndustryLevelVM Industry)
        {
            IndustryLevelVM industry = new IndustryLevelVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", Industry.id);
                dynamicParameterlist.Add("@Name", Industry.Name);
                dynamicParameterlist.Add("@level", Industry.Level);

                industry = await dbConnection.QuerySingleOrDefaultAsync<IndustryLevelVM>("msd.UpdateIndustryProductLevel", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return industry;
        }

        public async Task<IndustryLevelVM> AddIndustryProductLevel(IndustryLevelVM Industry)
        {
            IndustryLevelVM industry = new IndustryLevelVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Name", Industry.Name);
                dynamicParameterlist.Add("@level", Industry.Level);
                dynamicParameterlist.Add("@ParentId", Industry.ParentId);

                industry = await dbConnection.QuerySingleOrDefaultAsync<IndustryLevelVM>("msd.AddIndustryProductLevel", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return industry;
        }
    }
}

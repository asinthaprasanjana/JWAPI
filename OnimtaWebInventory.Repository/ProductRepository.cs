using Dapper;
using DBConnect;
using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Models;
//using OnimtaWebInventory.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Repository
{
    public class ProductRepository : DBContext, IProductRepository
    {
        //public IDbTransaction _transaction { get => _transaction; set => _transaction = value; }

        //public IDbConnection _connection;

        //IUnitOfWork unitOfWork = null;

        public ProductRepository()
        {
        }
        
        public async Task<PriceCategoryVM> AddPriceCategoryDetails(PriceCategoryVM priceCategoryVM)
        {
            PriceCategoryVM priceCategoryVm = new PriceCategoryVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CategoryName",priceCategoryVM.CategoryName);
                dynamicParameterlist.Add("@OrderId", priceCategoryVM.OrderId);
                dynamicParameterlist.Add("@CreatedUserId", priceCategoryVM.CreatedUserId);
                priceCategoryVM = await dbConnection.QuerySingleOrDefaultAsync<PriceCategoryVM>("msd.AddPriceCategoryDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return priceCategoryVM;
        }

        public async Task<PriceLevelVM> AddPriceLevelDetails(PriceLevelVM priceLevelVM)
        {
            PriceLevelVM priceLevelVm = new PriceLevelVM();

            try
            {

                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PriceLevelName", priceLevelVM.PriceLevelName);
                dynamicParameterlist.Add("@ProductId", priceLevelVM.ProductId);
                dynamicParameterlist.Add("@UserId", priceLevelVM.UserId);

                //priceLevelVm = await dbConnection.QueryFirstOrDefaultAsync<PriceLevelVM>("msd.AddProductPriceLevelDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                //priceLevelVm = await unitOfWork.Connection.QueryFirstOrDefaultAsync<PriceLevelVM>("msd.AddProductPriceLevelDetails", dynamicParameterlist,unitOfWork.Transaction, commandType: CommandType.StoredProcedure);
                priceLevelVm = await dbConnection.QueryFirstOrDefaultAsync<PriceLevelVM>("msd.AddProductPriceLevelDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return priceLevelVm;
        }

        public async Task<BasicProductDetailsVM> AddProductDetails(BasicProductDetailsVM basicProductDetails)
        {
            BasicProductDetailsVM basicProductDetailsVM = new BasicProductDetailsVM();
            try
            {

                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.AddDynamicParams(basicProductDetails);
                dynamicParameterlist.RemoveUnused = true;

                //basicProductDetailsVM = await dbConnection.QueryFirstOrDefaultAsync<BasicProductDetailsVM>("msd.AddProductDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                //basicProductDetailsVM = await unitOfWork.Connection.QueryFirstOrDefaultAsync<BasicProductDetailsVM>("msd.AddProductDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                basicProductDetailsVM = await dbConnection.QueryFirstOrDefaultAsync<BasicProductDetailsVM>("msd.AddProductDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return basicProductDetailsVM;
        }
        public async Task<PackSizeVM> AddProductPackSize(PackSizeVM packSizeVM)
        {
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.AddDynamicParams(packSizeVM);

                //packSizeVM = await dbConnection.QueryFirstOrDefaultAsync<PackSizeVM>("msd.AddProductPackSize", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                //packSizeVM = await unitOfWork.Connection.QueryFirstOrDefaultAsync<PackSizeVM>("msd.AddProductPackSize", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                packSizeVM = await dbConnection.QueryFirstOrDefaultAsync<PackSizeVM>("msd.AddProductPackSize", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return packSizeVM;
        }
        public async Task<IEnumerable<PriceCategoryVM> >GetPriceCategoryDetails()
        { 
            try
            {
                IEnumerable<PriceCategoryVM> priceCategoryVm;
                var dynamicParameterlist = new DynamicParameters();
                //priceCategoryVm = await dbConnection.QueryAsync<PriceCategoryVM>("stk.GetPriceCategoryDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                //priceCategoryVm = await unitOfWork.Connection.QueryAsync<PriceCategoryVM>("stk.GetPriceCategoryDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                priceCategoryVm = await dbConnection.QueryAsync<PriceCategoryVM>("stk.GetPriceCategoryDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                return priceCategoryVm;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
        }
        public async Task<IEnumerable<PriceLevelBasicDetailsVM>>GetPriceLevelDetails(int branchId, int productId,int productPriceLevelId,int ref3)
        {
            try
            {
                IEnumerable<PriceLevelBasicDetailsVM> priceLevelBasicDetailsVMs ;
                IEnumerable<BranchVM> branchVMs ;

                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@UserId", 1);
                dynamicParameterlist.Add("@ProductPriceLevelId", productPriceLevelId);
                dynamicParameterlist.Add("@ProductId", productId);
                dynamicParameterlist.Add("@BranchId", branchId);
                //priceLevelBasicDetailsVMs = await dbConnection.QueryAsync<PriceLevelBasicDetailsVM>("stk.GetPriceLevelDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                //priceLevelBasicDetailsVMs = await unitOfWork.Connection.QueryAsync<PriceLevelBasicDetailsVM>("stk.GetPriceLevelDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                priceLevelBasicDetailsVMs = await dbConnection.QueryAsync<PriceLevelBasicDetailsVM>("stk.GetPriceLevelDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                return priceLevelBasicDetailsVMs;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        public async Task<IEnumerable<BranchVM>> GetPriceLevelBranchDetails()
        {
            try
            {
                IEnumerable<PriceLevelBasicDetailsVM> priceLevelBasicDetailsVMs;
                IEnumerable<BranchVM> branchVMs;
                
                var dynamicParameterlist = new DynamicParameters();
                //dynamicParameterlist.Add("@UserId", 1);
                //dynamicParameterlist.Add("@PriceLevelId", 1);
                dynamicParameterlist.Add("@CompanyId", 1);
                //branchVMs = await dbConnection.QueryAsync<BranchVM>("msd.GetBranchDetailsByCompanyId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                //branchVMs = await unitOfWork.Connection.QueryAsync<BranchVM>("msd.GetBranchDetailsByCompanyId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                branchVMs = await dbConnection.QueryAsync<BranchVM>("msd.GetBranchDetailsByCompanyId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                return branchVMs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductVM> GetProductDetailsByProductId(int productId, int companyId)
        {
            ProductVM productVM = new ProductVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@ProductId",productId);
                dynamicParameterlist.Add("@CompanyId", companyId);
                productVM = await dbConnection.QuerySingleOrDefaultAsync<ProductVM>("GetProductDetailsByProductId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                productVM.BasicProductDetails = await dbConnection.QuerySingleOrDefaultAsync<BasicProductDetailsVM>("GetProductDetailsByProductId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productVM;
        }

        public async Task<IEnumerable<PurchaseOrderRequestItemsViewVm>> GetAllProductDetails()
        {
            IEnumerable<PurchaseOrderRequestItemsViewVm> productVM;
            try
            {
                //productVM = await dbConnection.QueryAsync<PurchaseOrderRequestItemsViewVm>("stk.GetAllSupplierItems", commandType: CommandType.StoredProcedure);
                //productVM = await unitOfWork.Connection.QueryAsync<PurchaseOrderRequestItemsViewVm>("stk.GetAllSupplierItems", commandType: CommandType.StoredProcedure);
                productVM = await dbConnection.QueryAsync<PurchaseOrderRequestItemsViewVm>("stk.GetAllSupplierItems", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productVM;
        }
        public async Task<IEnumerable<ProductVM>> GetProductAllDetails()
        {
            IEnumerable<ProductVM> productVM ;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                //dynamicParameterlist.Add();
                //productVM = await dbConnection.QueryAsync<ProductVM>("msd.GetProductAllDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                //productVM = await unitOfWork.Connection.QueryAsync<ProductVM>("msd.GetProductAllDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                productVM = await dbConnection.QueryAsync<ProductVM>("msd.GetProductAllDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productVM;

        }
        public async Task<ProductVM> GetProductDetailsById(int productId)
        {
            ProductVM productVM = new ProductVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@ProductId", productId);
                productVM = await dbConnection.QuerySingleOrDefaultAsync<ProductVM>("msd.GetProductDetailsById", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                productVM.BasicProductDetails = await dbConnection.QuerySingleOrDefaultAsync<BasicProductDetailsVM>("msd.GetProductDetailsById", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productVM;

        }
        public async Task<ProductVM> UpdateProductDetails(ProductVM productVM)
        {
            ProductVM productVm = new ProductVM();
            try
            {
               
                var dynamicParameterlist = new DynamicParameters();
                var productId = new DynamicParameters();
                productId.Add("@ProductId",productVM.ProductId);
                dynamicParameterlist.Add("@ProductId",productVM.ProductId);
                dynamicParameterlist.Add("@ProductGroupId", productVM.BasicProductDetails.ProductGroupId);
                dynamicParameterlist.Add("@ProductName", productVM.BasicProductDetails.ProductName);
                dynamicParameterlist.Add("@SKU", productVM.BasicProductDetails.Sku);
                dynamicParameterlist.Add("@ShortDescription", productVM.BasicProductDetails.ShortDescription);
                dynamicParameterlist.Add("@ProductDescription", productVM.BasicProductDetails.ProductDescription);
                dynamicParameterlist.Add("@ProductType", productVM.BasicProductDetails.ProductType);
                dynamicParameterlist.Add("@IsTradingProduct", productVM.BasicProductDetails.IsTradingProduct);
                dynamicParameterlist.Add("@CostingMethod", productVM.BasicProductDetails.CostingMethod);
                dynamicParameterlist.Add("@IncomeAccountId", productVM.IncomeAccountId);
                dynamicParameterlist.Add("@CogsAccountId", productVM.CogsAccountId);
                dynamicParameterlist.Add("@AssestsAccountId", productVM.AssestsAccountId);
                dynamicParameterlist.Add("@ReorderLevel", productVM.BasicProductDetails.ReorderLevel);
                dynamicParameterlist.Add("@UnitOfMeasure", productVM.BasicProductDetails.UnitOfMeasure);
                dynamicParameterlist.Add("@ReorderQty", productVM.BasicProductDetails.ReorderQty);
                dynamicParameterlist.Add("@IsExpireDateHandle", productVM.BasicProductDetails.isExpireDateHandle);
                dynamicParameterlist.Add("@isSerialNoHandle", productVM.BasicProductDetails.isSerialNoHandle);
                dynamicParameterlist.Add("@Industry", productVM.BasicProductDetails.Industry);
                dynamicParameterlist.Add("@LevelId01", productVM.BasicProductDetails.LevelId01);
                dynamicParameterlist.Add("@LevelId02", productVM.BasicProductDetails.LevelId02);
                dynamicParameterlist.Add("@LevelId03", productVM.BasicProductDetails.LevelId03);
                dynamicParameterlist.Add("@LevelId04", productVM.BasicProductDetails.LevelId04);
                dynamicParameterlist.Add("@LevelId05", productVM.BasicProductDetails.LevelId05);


                dynamicParameterlist.Add("@CreatedUserId", productVM.CreatedUserId);
                dynamicParameterlist.Add("@CompanyId", productVM.CompanyId);
                dynamicParameterlist.RemoveUnused = true;

                productVm = await dbConnection.QuerySingleOrDefaultAsync<ProductVM>("msd.UpdateProductDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

                //update PackSizeDetails

                await dbConnection.QuerySingleOrDefaultAsync<ProductVM>("msd.DeleteProductPackSizeByProductId", productId, _transaction, commandType: CommandType.StoredProcedure);
                foreach (PackSizeVM pack in productVM.PackSize)
                {
                    var packSizeDetails = new DynamicParameters();
                    packSizeDetails.Add("@PackSizeId", pack.PackSizeId);
                    packSizeDetails.Add("@PackSizeName", pack.PackSizeName);
                    packSizeDetails.Add("@PackQty", pack.PackQty);
                    
                    if (pack.PackSizeId == 0)
                    {
                        packSizeDetails.Add("@ProductId", productVM.ProductId);
                        packSizeDetails.Add("@CreatedUserId", productVM.CreatedUserId);
                        packSizeDetails.Add("@CompanyId", productVM.CompanyId);
                        packSizeDetails.Add("@IsDeleted", pack.IsDeleted);
                        await dbConnection.QueryFirstOrDefaultAsync<PackSizeVM>("msd.AddProductPackSize", packSizeDetails, _transaction, commandType: CommandType.StoredProcedure);
                    }
                    else
                    {
                        await dbConnection.QueryFirstOrDefaultAsync<PackSizeVM>("msd.UpdateProductPackSizeByPackSizeId", packSizeDetails, _transaction, commandType: CommandType.StoredProcedure);
                    }
                }
                await dbConnection.QuerySingleOrDefaultAsync<ProductVM>("msd.DeleteProductCheckingDetailsByProducId", productId, _transaction, commandType: CommandType.StoredProcedure);
             }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productVM;
        }
        public async Task<IEnumerable<PackSizeVM>> GetPackSizeDetailsByProductId(int productId)
        {
            IEnumerable<PackSizeVM> packSizeVM;

            try
            {
                DynamicParameters dynamicParameterList = new DynamicParameters();

                dynamicParameterList.Add("ProductId",productId);

                //packSizeVM = await dbConnection.QueryAsync<PackSizeVM>("stk.GetPackSizeDetailsByProductId",dynamicParameterList, commandType: CommandType.StoredProcedure);
                //packSizeVM = await unitOfWork.Connection.QueryAsync<PackSizeVM>("stk.GetPackSizeDetailsByProductId", dynamicParameterList, commandType: CommandType.StoredProcedure);
                packSizeVM = await dbConnection.QueryAsync<PackSizeVM>("msd.GetPackSizeDetailsByProductId", dynamicParameterList, commandType: CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return packSizeVM;
        }
        

        public async Task<CommonAttributesValuesVM> AddAttributeValues(CommonAttributesValuesVM commonAttributesValues)
        {
            CommonAttributesValuesVM commonAttributesValuesVM = new CommonAttributesValuesVM();

            try
            {
                DynamicParameters dynamicParameterList = new DynamicParameters();

                dynamicParameterList.Add("@ProductId", commonAttributesValues.ProductId);
                dynamicParameterList.Add("@AttributeId", commonAttributesValues.AttributeId);
                dynamicParameterList.Add("@Data", commonAttributesValues.Data);
                dynamicParameterList.Add("@DataId", commonAttributesValues.DataId);

                //commonAttributesValuesVM = await dbConnection.QuerySingleOrDefaultAsync<CommonAttributesValuesVM>("msd.AddCommonAttributeValues", dynamicParameterList, commandType: CommandType.StoredProcedure);
                //commonAttributesValuesVM = await unitOfWork.Connection.QuerySingleOrDefaultAsync<CommonAttributesValuesVM>("msd.AddCommonAttributeValues", dynamicParameterList, commandType: CommandType.StoredProcedure);
                commonAttributesValuesVM = await dbConnection.QuerySingleOrDefaultAsync<CommonAttributesValuesVM>("msd.AddCommonAttributeValues", dynamicParameterList, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return commonAttributesValuesVM;
        }

        public async Task<CheckingDetailsVM> AddCheckingDetails(int branchId,CheckingDetailsVM checkingDetails)
        {
            CheckingDetailsVM CheckingDetailsVM = new CheckingDetailsVM();
            try
            {
                DynamicParameters dynamicParameterList = new DynamicParameters();

                dynamicParameterList.Add("@ProductId", checkingDetails.ProductId);
                dynamicParameterList.Add("@ProductCheckingId", checkingDetails.ProductCheckingId);
                dynamicParameterList.Add("@BranchId", branchId);
                dynamicParameterList.Add("@CreatedUserId", checkingDetails.CreatedUserId);

                //CheckingDetailsVM = await dbConnection.QuerySingleOrDefaultAsync<CheckingDetailsVM>("msd_AddProductCheckingDetails", dynamicParameterList, commandType: CommandType.StoredProcedure);
                //CheckingDetailsVM = await unitOfWork.Connection.QuerySingleOrDefaultAsync<CheckingDetailsVM>("msd_AddProductCheckingDetails", dynamicParameterList, commandType: CommandType.StoredProcedure);
                CheckingDetailsVM = await dbConnection.QuerySingleOrDefaultAsync<CheckingDetailsVM>("msd.AddProductCheckingDetails", dynamicParameterList, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return CheckingDetailsVM;
        }

        public async  Task<IEnumerable<PriceLevelVM>> GetCompanyPriceLevelDetails(int ProductId)
        {
            IEnumerable<PriceLevelVM> priceLevelVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@ProductId", ProductId);
                //priceLevelVM = await dbConnection.QueryAsync<PriceLevelVM>("msd.GetProductPriceLevelByProductId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                //priceLevelVM = await unitOfWork.Connection.QueryAsync<PriceLevelVM>("msd.GetProductPriceLevelByProductId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                priceLevelVM = await dbConnection.QueryAsync<PriceLevelVM>("msd.GetProductPriceLevelByProductId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return priceLevelVM;
        }

        public async Task<PriceLevelVM> UpdatePriceLevelDetails(PriceLevelVM priceLevelVM)
        {
            PriceLevelVM priceLevelVm = new PriceLevelVM();

            try
            {

                for (int i = 0; i < priceLevelVM.NewPriceLevel.Count(); i++)
                {

                    var dynamicParameterlist = new DynamicParameters();
                    dynamicParameterlist.Add("@ProductId", priceLevelVM.NewPriceLevel.ElementAt(i).ProductId);
                    dynamicParameterlist.Add("@BranchId", priceLevelVM.NewPriceLevel.ElementAt(i).BranchId);
                    dynamicParameterlist.Add("@PackSizeId", priceLevelVM.NewPriceLevel.ElementAt(i).PackSizeId);
                    dynamicParameterlist.Add("@ProductPriceLevelId", priceLevelVM.NewPriceLevel.ElementAt(i).ProductPriceLevelId);
                    dynamicParameterlist.Add("@ProductId", priceLevelVM.NewPriceLevel.ElementAt(i).PriceTypeId);
                    dynamicParameterlist.Add("@ProductId", priceLevelVM.NewPriceLevel.ElementAt(i).ProductId);


                    //priceLevelVM = await dbConnection.QueryFirstOrDefaultAsync<PriceLevelVM>("msd.GetProductPriceLevelByProductId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                    //priceLevelVM = await unitOfWork.Connection.QueryFirstOrDefaultAsync<PriceLevelVM>("msd.GetProductPriceLevelByProductId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                    priceLevelVM = await dbConnection.QueryFirstOrDefaultAsync<PriceLevelVM>("msd.GetProductPriceLevelByProductId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return priceLevelVM;
        }

        public async Task<PriceLevelVM> AddPriceLevelItemsDetails(Data data)
        {
            PriceLevelVM priceLevelVM = new PriceLevelVM();
            try
            {
                     Data Data = new Data();
                          
                    var dynamicParameterlist = new DynamicParameters();
                    dynamicParameterlist.Add("@ProductPriceLevelId", data.ProductPriceLevelId);
                    dynamicParameterlist.Add("@ProductId", data.ProductId);
                    dynamicParameterlist.Add("@BranchId", data.BranchId);
                    dynamicParameterlist.Add("@PackSizeId", data.PackSizeId);
                    dynamicParameterlist.Add("@Price1", data.price1);
                    dynamicParameterlist.Add("@Price2", data.price2);
                    dynamicParameterlist.Add("@Price3", data.price3);
                    dynamicParameterlist.Add("@Price4", data.price4);
                    dynamicParameterlist.Add("@Price5", data.price5);
                    dynamicParameterlist.Add("@Price6", data.price6);
                    dynamicParameterlist.Add("@Price7", data.price7);
                    dynamicParameterlist.Add("@Price8", data.price8);
                    dynamicParameterlist.Add("@Price9", data.price9);
                    dynamicParameterlist.Add("@Price10", data.price10);

                //Data = await dbConnection.QueryFirstOrDefaultAsync<Data>("msd.AddProductPriceLevelItems", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                //Data = await unitOfWork.Connection.QueryFirstOrDefaultAsync<Data>("msd.AddProductPriceLevelItems", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                Data = await dbConnection.QueryFirstOrDefaultAsync<Data>("msd.AddProductPriceLevelItems", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return priceLevelVM;
        }

        public async Task<PriceLevelVM> UpdatePriceLevelItemsDetails(Data data)
        {
            PriceLevelVM priceLevelVM = new PriceLevelVM();
            try
            {
                Data Data = new Data();

                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@ProductPriceLevelId", data.ProductPriceLevelId);
                dynamicParameterlist.Add("@ProductId", data.ProductId);
                dynamicParameterlist.Add("@BranchId", data.BranchId);
                dynamicParameterlist.Add("@PackSizeId", data.PackSizeId);
                dynamicParameterlist.Add("@Price1", data.price1);
                dynamicParameterlist.Add("@Price2", data.price2);
                dynamicParameterlist.Add("@Price3", data.price3);
                dynamicParameterlist.Add("@Price4", data.price4);
                dynamicParameterlist.Add("@Price5", data.price5);
                dynamicParameterlist.Add("@Price6", data.price6);
                dynamicParameterlist.Add("@Price7", data.price7);
                dynamicParameterlist.Add("@Price8", data.price8);
                dynamicParameterlist.Add("@Price9", data.price9);
                dynamicParameterlist.Add("@Price10", data.price10);

                //Data = await dbConnection.QueryFirstOrDefaultAsync<Data>("msd.UpdateProductPriceLevelItems", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                //Data = await unitOfWork.Connection.QueryFirstOrDefaultAsync<Data>("msd.UpdateProductPriceLevelItems", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                Data = await dbConnection.QueryFirstOrDefaultAsync<Data>("msd.UpdateProductPriceLevelItems", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return priceLevelVM;
        }

        public async Task<IEnumerable<PriceLevelVM>> GetProductPriceByProductLevelId(Data data)
        {
            IEnumerable<PriceLevelVM> priceLevelVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@BranchId", data.BranchId);
                dynamicParameterlist.Add("@PackSizeId", data.PackSizeId);
                dynamicParameterlist.Add("@PriceCategory", data.PriceType);
                dynamicParameterlist.Add("@ProductId", data.ProductId);



                //priceLevelVM = await dbConnection.QueryAsync<PriceLevelVM>("msd.GetProductPriceByProductLevelId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                //priceLevelVM = await unitOfWork.Connection.QueryAsync<PriceLevelVM>("msd.GetProductPriceByProductLevelId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                priceLevelVM = await dbConnection.QueryAsync<PriceLevelVM>("msd.GetProductPriceByProductLevelId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return priceLevelVM;
        }

        public async Task<PriceCategoryVM> UpdatePriceCategoryDetails(PriceCategoryVM priceCategoryVM)
        {
            PriceCategoryVM priceCategoryVm = new PriceCategoryVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", priceCategoryVM.Id);
                dynamicParameterlist.Add("@CategoryName", priceCategoryVM.CategoryName);
                dynamicParameterlist.Add("@CreatedUserId", priceCategoryVM.CreatedUserId);

                priceCategoryVM = await dbConnection.QuerySingleOrDefaultAsync<PriceCategoryVM>("msd.UpdatePriceCategoryDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return priceCategoryVM;
        }

        public async Task<IEnumerable<ProductVM>> GetProducts(int pageNumber, int rowsPage)
        {
            IEnumerable<ProductVM> productVMs;
            try
            {
                DynamicParameters dynamicParameterList = new DynamicParameters();
                dynamicParameterList.Add("pageNumber", pageNumber);
                dynamicParameterList.Add("rowsPage", rowsPage);

                //productVMs = await dbConnection.QueryAsync<ProductVM>("msd.GetProducts", dynamicParameterList, commandType: CommandType.StoredProcedure);
                productVMs = await dbConnection.QueryAsync<ProductVM>("msd.GetProducts", dynamicParameterList, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productVMs;
        }

        public async Task<PriceCategoryVM> DeletePriceCategoryDetails(int id)
        {
            PriceCategoryVM priceCategoryVM = new PriceCategoryVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", id);
                priceCategoryVM = await dbConnection.QuerySingleOrDefaultAsync<PriceCategoryVM>("msd.DeletePriceCategoryDetails", dynamicParameterlist,_transaction, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return priceCategoryVM;
        }

        public async Task<IEnumerable<CheckingDetailsVM>> GetCheckingDetailsByProductId(int productId)
        {
            IEnumerable<CheckingDetailsVM> checkingDetails;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@ProductId", productId);
                checkingDetails = await dbConnection.QueryAsync<CheckingDetailsVM>("msd.GetProductCheckingDetailsByProducId", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return checkingDetails;
        }

        public async Task<ProductVM> DeleteProductByProductId(int productId)
        {
            ProductVM  product = new ProductVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@ProductId", productId);
                product = await dbConnection.QuerySingleOrDefaultAsync<ProductVM>("msd.DeleteProductByProductId", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }
    }
}

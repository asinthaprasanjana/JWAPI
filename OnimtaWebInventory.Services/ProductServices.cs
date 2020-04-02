
using Force.DeepCloner;
using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OnimtaWebInventory.Services
{
    public class ProductServices : IProductServices
    {
        IUnitOfWork _unitOfWork;


        public ProductServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<PriceCategoryVM> AddPriceCategoryDetails(PriceCategoryVM priceCategoryVM)
        {
            PriceCategoryVM priceCategoryVm = new PriceCategoryVM();
            try
            {
                using (_unitOfWork)
                {
                    _unitOfWork.BeginTransaction();
                    try
                    {
                        priceCategoryVm = await _unitOfWork.ProductRepository.AddPriceCategoryDetails(priceCategoryVM);

                        _unitOfWork.CommitTransaction();
                    }
                    catch(Exception ex)
                    {
                        _unitOfWork.RollbackTransaction();
                        throw ex;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return priceCategoryVM;
        }

        public async Task<PriceLevelVM> AddProductPriceLevelDetails(PriceLevelVM priceLevelVM)
        {
            PriceLevelVM priceLevelVm = new PriceLevelVM();
            Data data1 = new Data();
            try
            {
                using (_unitOfWork)
                {
                    _unitOfWork.BeginTransaction();
                    try
                    {
                        priceLevelVm = await _unitOfWork.ProductRepository.AddPriceLevelDetails(priceLevelVM);
                        int ProductPriceLevelId = priceLevelVm.Id;

                        for (int i = 0; i < priceLevelVM.NewPriceLevel.Count(); i++)
                        {

                            priceLevelVM.NewPriceLevel.ElementAt(i).ProductPriceLevelId = ProductPriceLevelId;
                            priceLevelVm = await _unitOfWork.ProductRepository.AddPriceLevelItemsDetails(priceLevelVM.NewPriceLevel.ElementAt(i));
                        }

                        _unitOfWork.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        _unitOfWork.RollbackTransaction();
                        throw ex;
                    }
                }                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return priceLevelVM;
        }

        public async Task<PriceLevelVM> UpdateProductPriceLevelDetails(PriceLevelVM priceLevelVM)
        {
            PriceLevelVM priceLevelVm = new PriceLevelVM();
            try
            {
                using (_unitOfWork)
                {
                    _unitOfWork.BeginTransaction();
                    try
                    {
                        for (int i = 0; i < priceLevelVM.NewPriceLevel.Count(); i++)
                        {

                            priceLevelVM.NewPriceLevel.ElementAt(i).ProductPriceLevelId = priceLevelVM.Id;
                            priceLevelVm = await _unitOfWork.ProductRepository.UpdatePriceLevelItemsDetails(priceLevelVM.NewPriceLevel.ElementAt(i));
                        }

                        _unitOfWork.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        _unitOfWork.RollbackTransaction();
                        throw ex;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return priceLevelVM;
        }


        public async Task<ProductVM> AddProductDetails(ProductVM productVM)
        {
            ProductVM productVm = new ProductVM();
            try
            {
                BasicProductDetailsVM BasicProductDetailsVM = productVM.BasicProductDetails.DeepClone();
                List<PackSizeVM> packSize = new List<PackSizeVM>();
                List<CheckingDetailsVM> checkDetails = new List<CheckingDetailsVM>();
                List<CommonAttributesValuesVM> commonAttributesValues = new List<CommonAttributesValuesVM>();

                using (_unitOfWork)
                {
                    _unitOfWork.BeginTransaction();
                    try
                    {
                        BasicProductDetailsVM = await _unitOfWork.ProductRepository.AddProductDetails(BasicProductDetailsVM);
                        productVM.ProductId = BasicProductDetailsVM.ProductId;


                        foreach (CommonAttributesValuesVM values in productVM.CommonAttributesValues)
                        {
                            if (values != null)
                            {
                                values.ProductId = BasicProductDetailsVM.ProductId;
                                CommonAttributesValuesVM newCommonAttributesValues = await _unitOfWork.ProductRepository.AddAttributeValues(values);

                                commonAttributesValues.Add(newCommonAttributesValues);
                            }
                        }

                        if (productVM.PackSize != null)
                        {
                            foreach (PackSizeVM item in productVM.PackSize)
                            {
                                item.ProductId = BasicProductDetailsVM.ProductId;
                                PackSizeVM newPackSizeVM = await _unitOfWork.ProductRepository.AddProductPackSize(item);
                                packSize.Add(newPackSizeVM);
                            }

                            productVM.PackSize = packSize.AsEnumerable();
                        }

                        if (productVM.ProductCheckingDetails != null)
                        {
                            foreach (CheckingDetailsVM CheckDetail in productVM.ProductCheckingDetails)
                            {
                                CheckDetail.ProductId = BasicProductDetailsVM.ProductId;
                                foreach (int branchId in CheckDetail.BranchIds)
                                {
                                    CheckingDetailsVM checkingDetail = await _unitOfWork.ProductRepository.AddCheckingDetails(branchId, CheckDetail);
                                }
                            }
                        }

                        _unitOfWork.CommitTransaction();

                    }
                    catch(Exception ex)
                    {
                        _unitOfWork.RollbackTransaction();
                        throw ex;
                    }
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productVM;
        }

        public async Task<IEnumerable<PriceCategoryVM>> GetPriceCategoryDetails()
        {
            IEnumerable<PriceCategoryVM> priceCategoryVM;
            try
            {
                using (_unitOfWork)
                {
                    priceCategoryVM = await _unitOfWork.ProductRepository.GetPriceCategoryDetails();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return priceCategoryVM;
        }

        public async Task<IEnumerable<PriceLevelVM>> GetPriceLevelDetails(int productId, int productPriceLevelId,int ref2)
        {
            IList<PriceLevelVM> priceLevelVM = new List<PriceLevelVM>();
            IEnumerable<PriceLevelBasicDetailsVM> priceLevelBasicDetailsVMs ;
            IEnumerable<BranchVM> branchVMs ;
            IEnumerable<PackSizeVM> packSizeVMs;
              
            try
            {
                using (_unitOfWork)
                {
                    packSizeVMs = await _unitOfWork.ProductRepository.GetPackSizeDetailsByProductId(productId);
                    branchVMs = await _unitOfWork.ProductRepository.GetPriceLevelBranchDetails();

                    for (int i = 0; i < branchVMs.Count(); i++)
                    {

                        PriceLevelVM priceLevelVM1 = new PriceLevelVM();
                        Data data = new Data();

                        IList<Data> datas = new List<Data>();

                        IList<Children> childrens = new List<Children>();
                        data.Name = branchVMs.ElementAt(i).BranchName;
                        data.BranchId = branchVMs.ElementAt(i).BranchId;
                        data.price1 = null;
                        data.price2 = null;
                        data.price3 = null;
                        data.price4 = null;
                        data.price5 = null;
                        data.price6 = null;
                        data.price7 = null;
                        data.price8 = null;
                        data.price9 = null;
                        data.price10 = null;

                        priceLevelVM1.Data = data;
                        priceLevelBasicDetailsVMs = await _unitOfWork.ProductRepository.GetPriceLevelDetails(branchVMs.ElementAt(i).BranchId, productId, productPriceLevelId, 0);

                        for (int x = 0; x < packSizeVMs.Count(); x++)
                        {
                            IEnumerable<PriceLevelBasicDetailsVM> priceLevelBasicDetailsVMs1;


                            Data data1 = new Data();
                            decimal[] prices = new decimal[10];
                            Children children = new Children();

                            int id = packSizeVMs.ElementAt(x).PackSizeId;
                            priceLevelBasicDetailsVMs1 = priceLevelBasicDetailsVMs.Where(el => el.PackSizeId == packSizeVMs.ElementAt(x).PackSizeId);
                            data1.Name = packSizeVMs.ElementAt(x).PackSizeName;
                            data1.BranchId = branchVMs.ElementAt(i).BranchId;
                            data1.PackSizeId = packSizeVMs.ElementAt(x).PackSizeId;
                            data1.ProductId = productId;
                            data1.ProductPriceLevelId = productPriceLevelId;


                            for (int y = 0; y < priceLevelBasicDetailsVMs1.Count(); y++)
                            {
                                prices[y] = priceLevelBasicDetailsVMs1.ElementAt(y).Price;
                            }
                            //data1.PriceTypeId =
                            data1.price1 = prices[0];
                            data1.price2 = prices[1];
                            data1.price3 = prices[2];
                            data1.price4 = prices[3];
                            data1.price5 = prices[4];
                            data1.price6 = prices[5];
                            data1.price7 = prices[6];
                            data1.price8 = prices[7];
                            data1.price9 = prices[8];
                            data1.price10 = prices[9];



                            children.Data = data1;
                            childrens.Add(children);


                        }

                        priceLevelVM1.Children = childrens;
                        priceLevelVM.Add(priceLevelVM1);

                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return priceLevelVM;
        }

        public async Task<ProductVM> GetProductDetailsByProductId(int productId, int companyId)
        {
            ProductVM productVM = new ProductVM();
            try
            {
                using (_unitOfWork)
                {
                    productVM = await _unitOfWork.ProductRepository.GetProductDetailsByProductId(productId, companyId);
                }
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
                using (_unitOfWork)
                {
                    productVM = await _unitOfWork.ProductRepository.GetAllProductDetails();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productVM;
        }

        public async Task<IEnumerable<ProductVM>> GetProductAllDetails()
        {
            IEnumerable<ProductVM> productVM;
            try
            {
                using (_unitOfWork)
                {
                    productVM = await _unitOfWork.ProductRepository.GetProductAllDetails();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productVM;
        }

        public async Task<ProductVM> GetProductDetailsById(int productId)
        {
            ProductVM productVM = new ProductVM();
            IEnumerable<PackSizeVM> packSizeVMs;
            try
            {
                using (_unitOfWork)
                {
                    productVM = await _unitOfWork.ProductRepository.GetProductDetailsById(productId);
                    productVM.PackSize = await _unitOfWork.ProductRepository.GetPackSizeDetailsByProductId(productId);
                    productVM.ProductCheckingDetails = await _unitOfWork.ProductRepository.GetCheckingDetailsByProductId(productId);
                }

            } catch (Exception ex)
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
                using (_unitOfWork)
                {
                    _unitOfWork.BeginTransaction();
                    try
                    {
                        productVM = await _unitOfWork.ProductRepository.UpdateProductDetails(productVM);
                        if (productVM.ProductCheckingDetails != null)
                        {
                            foreach (CheckingDetailsVM CheckDetail in productVM.ProductCheckingDetails)
                            {
                                foreach (int branchId in CheckDetail.BranchIds)
                                {
                                    CheckingDetailsVM checkingDetail = await _unitOfWork.ProductRepository.AddCheckingDetails(branchId, CheckDetail);
                                }
                            }
                        }
                        _unitOfWork.CommitTransaction();
                    }
                    catch(Exception ex)
                    {
                        _unitOfWork.RollbackTransaction();
                        throw ex;
                    }
                }

            } catch (Exception ex)
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
                using (_unitOfWork)
                {
                    packSizeVM = await _unitOfWork.ProductRepository.GetPackSizeDetailsByProductId(productId);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return packSizeVM;
        }

        public async Task<IEnumerable<ProductVM>> GetProducts(int pageNumber, int rowsPage)
        {
            IEnumerable<ProductVM> productVMs;
            try
            {
                //using (DalSession dalSession = new DalSession())
                using (_unitOfWork)
                {

                    productVMs = await _unitOfWork.ProductRepository.GetProducts(pageNumber, rowsPage);

                }
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productVMs;
        }

        public async Task<IEnumerable<PriceLevelVM>> GetCompanyPriceLevelDetails(int ProductId)
        {
            IEnumerable<PriceLevelVM> priceLevelVM;

            try
            {
                using (_unitOfWork)
                {
                    priceLevelVM = await _unitOfWork.ProductRepository.GetCompanyPriceLevelDetails(ProductId);
                }

            } catch(Exception ex)
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
                using (_unitOfWork)
                {
                    priceLevelVM = await _unitOfWork.ProductRepository.GetProductPriceByProductLevelId(data);
                }

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
                using (_unitOfWork)
                {
                    _unitOfWork.BeginTransaction();
                    try
                    {
                        priceCategoryVM = await _unitOfWork.ProductRepository.UpdatePriceCategoryDetails(priceCategoryVM);
                        _unitOfWork.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        _unitOfWork.RollbackTransaction();
                        throw ex;
                    }
                }

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return priceCategoryVM;
        }

        public async Task<PriceCategoryVM> DeletePriceCategoryDetails(int id)
        {
            PriceCategoryVM priceCategoryVM = new PriceCategoryVM();

            using (_unitOfWork)
            {
                try
                {
                    priceCategoryVM = await _unitOfWork.ProductRepository.DeletePriceCategoryDetails(id);

                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                return priceCategoryVM;
            }
        }

        public async Task<ProductVM> DeleteProductByProductId(int productId)
        {
            ProductVM product = new ProductVM();

            using (_unitOfWork)
            {
                try
                {
                    product = await _unitOfWork.ProductRepository.DeleteProductByProductId(productId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                return product;
            }
        }
    }
}

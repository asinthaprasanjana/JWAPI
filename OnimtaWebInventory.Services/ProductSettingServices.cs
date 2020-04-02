using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OnimtaWebInventory.Services
{
    public class ProductSettingServices : IProductSettingServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public ProductSettingServices( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CommonAttributesVM> AddCommonAttribute(CommonAttributesVM commonAttributes)
        {
            CommonAttributesVM CommonAttributes = new CommonAttributesVM();

            
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    CommonAttributes = await  _unitOfWork.ProductSettingRepository.AddcommonAttribute(commonAttributes);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return CommonAttributes;
        }

        public async Task<CommonGroupsVM> AddCommonGroup(CommonGroupsVM commonGroup)
        {
            CommonGroupsVM CommonGroup = new CommonGroupsVM();
           
               
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
           CommonGroup = await  _unitOfWork.ProductSettingRepository.AddCommonGroup(commonGroup);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }

            return CommonGroup;
            
        }

        public async Task<IEnumerable<ProductLevelVM>> AddProductLevel(IEnumerable<ProductLevelVM> ProductLevelVM)
        {
            ProductLevelVM productLevelVM = new ProductLevelVM();
            ProductLevelVM productLevelVM2 = new ProductLevelVM();
          
           
               
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();

                    for(int i = 0; i < ProductLevelVM.Count(); i++)
                    {
                        if(ProductLevelVM.ElementAt(i).Level == 1)
                        {
                            productLevelVM = await  _unitOfWork.ProductSettingRepository.AddProductLevel(ProductLevelVM.ElementAt(i));
                        }
                        else{
                            productLevelVM = ProductLevelVM.ElementAt(i);
                        }

                        if (ProductLevelVM.ElementAt(i).values.Count() != 0)
                        {
                            for (int j = 0; j < ProductLevelVM.ElementAt(i).values.Count(); j++)
                            {
                                ProductLevelVM.ElementAt(i).values.ElementAt(j).ParentLevelId = productLevelVM.Id;
                                ProductLevelVM.ElementAt(i).values.ElementAt(j).Level = productLevelVM.Level + 1;

                                productLevelVM2=await  _unitOfWork.ProductSettingRepository.AddProductLevel(ProductLevelVM.ElementAt(i).values.ElementAt(j));

                                ProductLevelVM.ElementAt(i).values.ElementAt(j).Id = productLevelVM2.Id;

                            }
                        }
                    }
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }

            return ProductLevelVM;
        }

        public async Task<IEnumerable<IndustryVM>> GetAllIndustries()
        {
            IEnumerable<IndustryVM> industries;
          
            using (_unitOfWork)
            {


                try
                {
                    //_unitOfWork.BeginTransaction();
                    industries = await _unitOfWork.ProductSettingRepository.GetAllIndustries();

                    //_unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    // _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }

            return industries;
        }

        public async Task<IEnumerable<CommonAttributesVM>> GetCommonAttributeById(CommonGroupsVM CommonGroup)
        {

            CommonAttributesVM commonAttributesReturn =new CommonAttributesVM();
            List<CommonAttributesVM> commonAttributes1 = new List<CommonAttributesVM>();
            CommonAttributesVM commonAttribute = new CommonAttributesVM();
           
               
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                          foreach (string id in CommonGroup.Attributes)
                        {
                 
                            commonAttribute = await  _unitOfWork.ProductSettingRepository.GetCommonAttributeById(Convert.ToInt32(id));
                            commonAttributes1.Add(commonAttribute);

                        }
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }

            return commonAttributes1;
        }

        public async Task<IEnumerable<CommonAttributesValuesVM>> GetCommonAttributeData(int attributeId)
        {
            IEnumerable<CommonAttributesValuesVM> commonAttributesValues;

            
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                commonAttributesValues = await  _unitOfWork.ProductSettingRepository.GetCommonAttributeData(attributeId);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }


            return commonAttributesValues;
        }

        public async Task<IEnumerable<CommonAttributesVM>> GetCommonAttributes(int filter)
        {
            IEnumerable<CommonAttributesVM> commonAttributes;

            

            using (_unitOfWork)
            {


                try
                {
                    //_unitOfWork.BeginTransaction();

                    commonAttributes = await  _unitOfWork.ProductSettingRepository.GetCommonAttributeDetails(filter);

                    for(int i = 0; commonAttributes.Count() > i; i++)
                    {
                        commonAttributes.ElementAt(i).Data = await  _unitOfWork.ProductSettingRepository.GetCommonAttributeData(commonAttributes.ElementAt(i).Id);
                    }
                    //_unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    //_unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }


            return commonAttributes;
        }

        public async Task<IEnumerable<CommonGroupsVM>> GetCommonGroups()
        {
            IEnumerable<CommonGroupsVM> commonGroups;
           
            using (_unitOfWork)
            {


                try
                {
                    //_unitOfWork.BeginTransaction();
                commonGroups = await  _unitOfWork.ProductSettingRepository.GetCommonGroups();

                    //_unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    //_unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return commonGroups;

        }

        public async Task<IEnumerable<IndustryLevelVM>> GetIndustryProductLevel(int parentId, int level)
        {
            IEnumerable<IndustryLevelVM> industrysLevls;
            
            using (_unitOfWork)
            {


                try
                {
                    //_unitOfWork.BeginTransaction();
                industrysLevls = await  _unitOfWork.ProductSettingRepository.GetIndustryProductLevel(parentId,level);

                    //_unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    //_unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return industrysLevls;
        }

        public async Task<IEnumerable<ProductLevelVM>> GetProductLevelDetails(ProductLevelVM ProductLevelVM)
        {
            IEnumerable<ProductLevelVM> productLevelVMs;

            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
            productLevelVMs = await  _unitOfWork.ProductSettingRepository.GetProductLevelDetails(ProductLevelVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return productLevelVMs;
        }

        public async Task<ProductLevelSummeryVM> GetProductLevelSummeryDetailsDetails(int companyId)
        {
            List<ProductLevelSummeryVM> productLevelSummeryVM = new List<ProductLevelSummeryVM>();
            ProductLevelSummeryVM ReturnproductLevelSummeryVM = new ProductLevelSummeryVM();
            List<ProductLevelSummeryVM> productLevel1SummeryVM = new List<ProductLevelSummeryVM>(10);
            IList<ProductLevelSummeryVM> productLevel2SummeryVM = new List<ProductLevelSummeryVM>();


            ProductLevelVM productLevelVM = new ProductLevelVM();
            IEnumerable<ProductLevelVM> productLevelVMs;
            IEnumerable<ProductLevelVM> productLevel1VMs;
            IEnumerable<ProductLevelVM> productLevel2VMs;


          
            
            productLevelVM.Level = -1;
            productLevelVM.ParentIds = "0";

            using (_unitOfWork)
            {


                try
                {
                    productLevelVMs = await  _unitOfWork.ProductSettingRepository.GetProductLevelDetails(productLevelVM);
                    ReturnproductLevelSummeryVM.Label = productLevelVMs.ElementAt(0).AttributeName;

                    productLevelVM.Level = -1;
                    productLevelVM.ParentIds = productLevelVMs.ElementAt(0).Id.ToString();


                    productLevel1VMs = await  _unitOfWork.ProductSettingRepository.GetProductLevelDetails(productLevelVM);

                    ReturnproductLevelSummeryVM.Children = new List<ProductLevelSummeryVM>();

                    for (int i = 0; i < productLevel1VMs.Count(); i++)
                    {

                        ProductLevelSummeryVM temp = new ProductLevelSummeryVM();
                        temp.Label = productLevel1VMs.ElementAt(i).AttributeName;
                        temp.Id = productLevel1VMs.ElementAt(i).Id;
                        productLevel2SummeryVM.Add(temp);
                        ReturnproductLevelSummeryVM.Children = productLevel2SummeryVM;

                    }


                    for (int y = 0; y < ReturnproductLevelSummeryVM.Children.Count(); y++)
                    {
                        int parentId = ReturnproductLevelSummeryVM.Children.ElementAt(y).Id;
                        productLevelVM.ParentIds = parentId.ToString();
                        productLevel2VMs = await  _unitOfWork.ProductSettingRepository.GetProductLevelDetails(productLevelVM);
                        IList<ProductLevelSummeryVM> productLevelTempSummeryVM = new List<ProductLevelSummeryVM>();


                        for (int a = 0; a < productLevel2VMs.Count(); a++)
                        {
                            ProductLevelSummeryVM temp1 = new ProductLevelSummeryVM();
                            temp1.Label = productLevel2VMs.ElementAt(a).AttributeName;
                            temp1.Id = productLevel2VMs.ElementAt(a).Id;

                            productLevelVM.ParentIds = temp1.Id.ToString();
                            IEnumerable<ProductLevelVM> productLevel3VMs;

                            productLevel3VMs = await  _unitOfWork.ProductSettingRepository.GetProductLevelDetails(productLevelVM);
                            IList<ProductLevelSummeryVM> productLevelTemp4SummeryVM = new List<ProductLevelSummeryVM>();

                            for (int l = 0; l < productLevel3VMs.Count(); l++)
                            {

                                try
                                {
                                    ProductLevelSummeryVM temp2 = new ProductLevelSummeryVM();
                                    IList<ProductLevelSummeryVM> productLevelTemp5SummeryVM = new List<ProductLevelSummeryVM>();

                                    temp2.Label = productLevel3VMs.ElementAt(l).AttributeName;
                                    temp2.Id = productLevel3VMs.ElementAt(l).Id;
                                    IEnumerable<ProductLevelVM> productLevel4VMs;
                                    productLevel4VMs = await  _unitOfWork.ProductSettingRepository.GetProductLevelDetails(productLevelVM);



                                    productLevelTemp4SummeryVM.Add(temp2);


                                }
                                catch (Exception ex)
                                {
                                    throw new Exception(ex.Message);
                                }
                            }

                            temp1.Children = productLevelTemp4SummeryVM;
                            productLevelTempSummeryVM.Add(temp1);

                        }
                        ReturnproductLevelSummeryVM.Children.ElementAt(y).Children = productLevelTempSummeryVM;
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

           
               
           

            return ReturnproductLevelSummeryVM;
        }

        public async Task<CommonAttributesVM> UpdateCommonAttributes(CommonAttributesVM commonAttributes)
        {
            CommonAttributesVM CommonAttributes = new CommonAttributesVM();

          
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    CommonAttributes = await  _unitOfWork.ProductSettingRepository.UpdateCommonAttribute(commonAttributes);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }


            return CommonAttributes;
        }

        public async Task<CommonGroupsVM> UpdateCommonGroup(CommonGroupsVM group)
        {
            CommonGroupsVM commonGroup = new CommonGroupsVM();
            
                   
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    commonGroup = await  _unitOfWork.ProductSettingRepository.UpdateCommonGroup(group);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }



            return group;
        }

        public async Task<IndustryLevelVM> UpdateIndustryProductLevel(IndustryLevelVM Industry)
        {
            IndustryLevelVM industry = new IndustryLevelVM();
            
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                industry = await  _unitOfWork.ProductSettingRepository.UpdateIndustryProductLevel(Industry);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return industry;
        }

        public async Task<IndustryLevelVM> AddIndustryProductLevel(IndustryLevelVM Industry)
        {
            IndustryLevelVM industry = new IndustryLevelVM();
            

            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                industry = await  _unitOfWork.ProductSettingRepository.AddIndustryProductLevel(Industry);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }

            return industry;
        }
    }
}

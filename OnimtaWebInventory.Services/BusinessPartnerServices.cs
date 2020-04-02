using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;

namespace OnimtaWebInventory.Services
{
    public class BusinessPartnerServices : IBusinessPartnerServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public static IList<BusinessPartnerVM> BusinessPartnerCachedDetail = new List<BusinessPartnerVM>();

        public BusinessPartnerServices( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BusinessPartnerVM> AddBusinessPartner(BusinessPartnerVM BusinessPartnerVM)
        {
           
                  BusinessPartnerVM AddBusinessPartner = new BusinessPartnerVM();

            using (_unitOfWork)
            {


                try
                {
                  AddBusinessPartner = await  _unitOfWork.BusinessPartnerRepository.AddBusinessPartner(BusinessPartnerVM);

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

                 
                  return AddBusinessPartner;
        }

        public async Task<BusinessPartnerVM> DeleteBusinessPartner(int businessPartnerId)
        {
            BusinessPartnerVM DeleteBusinessPartner = new BusinessPartnerVM();

            using (_unitOfWork)
            {


                try
                {
                   DeleteBusinessPartner = await  _unitOfWork.BusinessPartnerRepository.DeleteBusinessPartner(businessPartnerId);
                    int index = 0;
                                for (int i = 0; i < BusinessPartnerServices.BusinessPartnerCachedDetail.Count; i++)
                                {
                                    if (BusinessPartnerServices.BusinessPartnerCachedDetail[i].BusinessPartnerId == businessPartnerId)
                                    {
                                        index = i;
                                        BusinessPartnerServices.BusinessPartnerCachedDetail.RemoveAt(index);
                                        break;

                                    }

                                }
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

                 
               
            
           
            return DeleteBusinessPartner;
        }

        public async Task<IEnumerable<BankVM>> GetBusinessPartnerBanks()
        {
            IEnumerable<BankVM> bankVM;
            using (_unitOfWork)
            {


                try
                {
                   bankVM = await  _unitOfWork.BusinessPartnerRepository.GetBusinessPartnerBanks();

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
           
            return bankVM;
        }

        public async Task<IEnumerable< BusinessPartnerVM>> GetBusinessPartnerDetails( int businessPartnerTypeId,int companyId, int pageId,int isActive)
        {
            IEnumerable<BusinessPartnerVM> businessPartnerVM;

            using (_unitOfWork)
            {


                try
                {
                businessPartnerVM = await  _unitOfWork.BusinessPartnerRepository.GetBusinessPartnerDetails(businessPartnerTypeId, companyId,pageId,isActive);

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

           
            return businessPartnerVM;
        }
       
        public async Task<BusinessPartnerVM> GetBusinessPartnerDetailsByBspId(int businessPartnerId)
        {
            BusinessPartnerVM BusinessPartnerDetails = new BusinessPartnerVM();
           
                if (BusinessPartnerServices.BusinessPartnerCachedDetail.Count>0)
                {
                    int count = 0;

                    for (int i = 0; i < BusinessPartnerServices.BusinessPartnerCachedDetail.Count; i++)
                    {
                        if (BusinessPartnerServices.BusinessPartnerCachedDetail[i].BusinessPartnerId == businessPartnerId)
                        {
                            BusinessPartnerDetails = BusinessPartnerServices.BusinessPartnerCachedDetail[i];

                            return BusinessPartnerDetails;
                        }

                        count++;
                    }
                }

            using (_unitOfWork)
            {


                try
                {
                           BusinessPartnerDetails = await  _unitOfWork.BusinessPartnerRepository.GetBusinessPartnerDetailsByBspId(businessPartnerId);
                                BusinessPartnerServices.BusinessPartnerCachedDetail.Add(BusinessPartnerDetails);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

           
           
            return BusinessPartnerDetails;
        }
        public async Task<BusinessPartnerVM> UpdateBusinessPartner(BusinessPartnerVM businessPartnerVM)
        {
            int index = 0; ;
            BusinessPartnerVM businessPartnerVm = new BusinessPartnerVM();

            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();

                   businessPartnerVm = await  _unitOfWork.BusinessPartnerRepository.UpdateBusinessPartner(businessPartnerVM);
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();

                    throw new Exception(ex.Message);
                }
            }


            for (int i = 0; i < BusinessPartnerServices.BusinessPartnerCachedDetail.Count; i++)
            {
                if (BusinessPartnerServices.BusinessPartnerCachedDetail[i].BusinessPartnerId == businessPartnerVM.BusinessPartnerId)
                {
                    index = i;
                    BusinessPartnerServices.BusinessPartnerCachedDetail[i] = businessPartnerVM;
                    break;

                }

            }
            return businessPartnerVM;
        }

        public async Task<IEnumerable<BusinessPartnerVM>> GetBusinessPartnerDetailsByBSPName(string name, int businessPartnerTypeId)
        {
            IEnumerable<BusinessPartnerVM> businessPartnerVM;
            using (_unitOfWork)
            {


                try
                {
                  businessPartnerVM = await  _unitOfWork.BusinessPartnerRepository.GetBusinessPartnerDetailsByBSPName(name, businessPartnerTypeId);

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

           
            return businessPartnerVM;
        }

        public async Task<BusinessPartnerGroupVM> AddBusinessPartnerGroupDetails(BusinessPartnerGroupVM businessPartnerGroupVM)
        {
            BusinessPartnerGroupVM businessPartnerGroupVm = new BusinessPartnerGroupVM();

            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();

                    businessPartnerGroupVM = await  _unitOfWork.BusinessPartnerRepository.AddBusinessPartnerGroupDetails(businessPartnerGroupVM);
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();

                    throw new Exception(ex.Message);
                }
            }


            

            return businessPartnerGroupVM;
        }

        public async Task<IEnumerable<BusinessPartnerGroupVM>> GetAllBusinessPartnerGroupDetails()
        {
            IEnumerable<BusinessPartnerGroupVM> businessPartnerGroupVM;
            using (_unitOfWork)
            {


                try
                {
                  businessPartnerGroupVM = await  _unitOfWork.BusinessPartnerRepository.GetAllBusinessPartnerGroupDetails();

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }


            
            return businessPartnerGroupVM;
        }

        public async Task<BusinessPartnerGroupVM> UpdateBusinessPartnerGroupDetails(BusinessPartnerGroupVM businessPartnerGroupVM)
        {
            BusinessPartnerGroupVM businessPartnerGroupVm = new BusinessPartnerGroupVM();
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();

                    businessPartnerGroupVM = await  _unitOfWork.BusinessPartnerRepository.UpdateBusinessPartnerGroupDetails(businessPartnerGroupVM);
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();

                    throw new Exception(ex.Message);
                }
            }


           
            return businessPartnerGroupVM;
        }

        public async  Task<IEnumerable<BusinessPartnerGroupVM>> GetBusinessPartnerGroupDetailsByGroupId(int groupCode)
        {
            IEnumerable<BusinessPartnerGroupVM> businessPartnerGroupVM;
            using (_unitOfWork)
            {


                try
                {
                  businessPartnerGroupVM = await  _unitOfWork.BusinessPartnerRepository.GetBusinessPartnerGroupDetailsByGroupId(groupCode);

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }


           
            return businessPartnerGroupVM;
        }

        public async Task<IEnumerable<BusinessPartnerGroupVM>> GetBusinessPartnerGroupDetailsByBspTypeId(int bspTypeId)
        {
            IEnumerable<BusinessPartnerGroupVM> businessPartnerGroupVM;
            using (_unitOfWork)
            {


                try
                {
                   businessPartnerGroupVM = await  _unitOfWork.BusinessPartnerRepository.GetBusinessPartnerGroupDetailsByBspTypeId(bspTypeId);

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }


           
            return businessPartnerGroupVM;
        }

        public async Task<BusinessPartnerVM> UpdateBusinessPartnerCustomerStatus(int isActive, int businessPartnerId)
        {
            BusinessPartnerVM businessPartnerVM = new BusinessPartnerVM();

            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();

                    businessPartnerVM = await  _unitOfWork.BusinessPartnerRepository.UpdateBusinessPartnerCustomerStatus(isActive, businessPartnerId);
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();

                    throw new Exception(ex.Message);
                }
            }

            

            return businessPartnerVM;
        }

        public async  Task<BusinessPartnerVM> GetBusinessPartnerDetailsByMobileNumber(int mobileNo, int businessPartnerTypeId)
        {
            BusinessPartnerVM businessPartnerVM = new BusinessPartnerVM();

            using (_unitOfWork)
            {


                try
                {
                   businessPartnerVM = await  _unitOfWork.BusinessPartnerRepository.GetBusinessPartnerDetailsByMobileNumber(mobileNo, businessPartnerTypeId);

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

           

            return businessPartnerVM;
        }

        public async Task<BusinessPartnerGroupVM> DeleteBusinessPartnerGroupDetails(string groupCode)
        {
            BusinessPartnerGroupVM businessPartnerGroupVM = new BusinessPartnerGroupVM();

            using (_unitOfWork)
            {
                try
                {
                    businessPartnerGroupVM = await _unitOfWork.BusinessPartnerRepository.DeleteBusinessPartnerGroupDetails(groupCode);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return businessPartnerGroupVM;
        }
    }
}

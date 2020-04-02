using Microsoft.AspNetCore.Http;
using OnimtaWebInventory.Core.IServices.IJewelleryService;
using OnimtaWebInventory.Models.Jewellery;
using OnimtaWebInventory.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Services.JewelleryServices
{
    public class JewelleryProductServices : IJewelleryProductServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public JewelleryProductServices(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }

        public async Task<GoldRateVM> AddGoldRateDetail(GoldRateVM goldRateVM)
        {
            GoldRateVM goldRateVm = new GoldRateVM();
            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    goldRateVm = await _unitOfWork.JewelleryProductRepository.AddGoldRateDetail(goldRateVM);
                    _unitOfWork.CommitTransaction();

                }catch(Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return goldRateVm;
        }

        public async Task<JewelleryProductVM> AddJewelleryProduct(JewelleryProductVM jewelleryProduct)
        {
            JewelleryProductVM jewelleryProductVm = new JewelleryProductVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    jewelleryProductVm = await _unitOfWork.JewelleryProductRepository.AddJewelleryProduct(jewelleryProduct);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return jewelleryProductVm;
        }

        public async Task<JewelleryTransferVM> AddJewelleryTransfer(JewelleryTransferVM jewelleryTransfer)
        {
            JewelleryTransferVM jewelleryTransferProductVm = new JewelleryTransferVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    jewelleryTransfer = await _unitOfWork.JewelleryProductRepository.AddJewelleryTransfer(jewelleryTransfer);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return jewelleryTransfer;
        }

        public async Task<JewelleryTransferVM> CancellTransfer(JewelleryTransferVM Transfer)
        {
            JewelleryTransferVM transfer = new JewelleryTransferVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    transfer = await _unitOfWork.JewelleryProductRepository.cancellTransfer(Transfer);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return transfer;
        }



        public async Task<JewelleryProductVM> DeleteJewelleryProduct(int id)
        {
            JewelleryProductVM jewelleryProductVM = new JewelleryProductVM();
            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    jewelleryProductVM = await _unitOfWork.JewelleryProductRepository.DeleteJewelleryProduct(id);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return jewelleryProductVM;

        }

        public async Task<IEnumerable<GoldRateVM>> GetAllGoldRateDetails()
        {
            IEnumerable<GoldRateVM> goldRateVM;

            using (_unitOfWork)
            {
                try
                {
                    goldRateVM = await _unitOfWork.JewelleryProductRepository.GetAllGoldRateDetails();

                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return goldRateVM;
        }

      
        public async Task<IEnumerable<JewelleryProductVM>> GetAllJewelleryProductDetails(FilterVM Filter)
        {
            IEnumerable<JewelleryProductVM> jewelleryProductVM;

            using (_unitOfWork)
            {
                try
                {
                    jewelleryProductVM = await _unitOfWork.JewelleryProductRepository.GetAllJewelleryProductDetails(Filter);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return jewelleryProductVM;
        }

        public async Task<IEnumerable<JewelleryTransferVM>> GetAllJewelleryTransfers(FilterVM filter)
        {
            IEnumerable<JewelleryTransferVM> jewelleryTransferProductVM;

            using (_unitOfWork)
            {
                try
                {
                    jewelleryTransferProductVM = await _unitOfWork.JewelleryProductRepository.GetAllJewelleryTransfers(filter);

                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return jewelleryTransferProductVM;
        }

        public async Task<GoldRateVM> GetGoldRateDetailsByDate()
        {
            GoldRateVM goldRateVM = new GoldRateVM();

            using (_unitOfWork)
            {
                try
                {
                    goldRateVM = await _unitOfWork.JewelleryProductRepository.GetGoldRateDetailsByDate();


                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return goldRateVM;
        }

        public async Task<JewelleryProductVM> GetJewelleryProductDetailsById(int id)
        {
            JewelleryProductVM jewelleryProductVM = new JewelleryProductVM();

            using (_unitOfWork)
            {
                try
                {
                    jewelleryProductVM = await _unitOfWork.JewelleryProductRepository.GetJewelleryProductDetailsById(id);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return jewelleryProductVM;
        }

        public async Task<IEnumerable<JewelleryProductVM>> GetJewelleryProductLogByProductId(int id)
        {
            IEnumerable<JewelleryProductVM> jewelleryProductVM;

            using (_unitOfWork)
            {
                try
                {
                    jewelleryProductVM = await _unitOfWork.JewelleryProductRepository.GetJewelleryProductLogByProductId(id);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return jewelleryProductVM;
        }


        public async Task<JewelleryTransferVM> GetJewelleryTransferByTransferId(int TransferId)
        {
            JewelleryTransferVM jewelleryTransferProductVM = new JewelleryTransferVM();

            using (_unitOfWork)
            {
                try
                {
                    jewelleryTransferProductVM = await _unitOfWork.JewelleryProductRepository.GetJewelleryTransferByTransferId(TransferId);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return jewelleryTransferProductVM;

        }

        public async Task<GoldRateVM> GetReceiptNumber()
        {
            GoldRateVM goldRateVM = new GoldRateVM();

            using (_unitOfWork)
            {
                try
                {
                    goldRateVM = await _unitOfWork.JewelleryProductRepository.GetReceiptNumber();

                } catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return goldRateVM;
        }

        public async Task<IEnumerable<JewelleryProductVM>> ImportProductExcel(Boolean autoGenItemCode ,IFormFile file)
        {
            IEnumerable<JewelleryProductVM> jewelleryProductVM;

            try
            {
                using (_unitOfWork)
                {
                    _unitOfWork.BeginTransaction();
                    try
                    {
                        jewelleryProductVM = await _unitOfWork.JewelleryProductRepository.ImportProductExcel(autoGenItemCode,file);
                        
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

            return jewelleryProductVM;
        }

        public async Task<IEnumerable<JewelleryProductVM>> ImportProductExcelBarCode(IFormFile file)
        {
            IEnumerable<JewelleryProductVM> jewelleryProductVM;

            try
            {
                using (_unitOfWork)
                {
                    _unitOfWork.BeginTransaction();
                    try
                    {
                        jewelleryProductVM = await _unitOfWork.JewelleryProductRepository.ImportProductExcelBarCode(file);

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

            return jewelleryProductVM;
        }

        public async Task<IEnumerable<JewelleryProductVM>> JewelleryProductTransfer()
        {
            IEnumerable<JewelleryProductVM> jewelleryProductVM;

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    jewelleryProductVM = await _unitOfWork.JewelleryProductRepository.JewelleryProductTransfer();
                    _unitOfWork.CommitTransaction();

                }catch(Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return jewelleryProductVM;
        }

        public async Task<IEnumerable<JewelleryProductVM>> SearchJewelleryProductDetails(string itemCode, string description, int pageId)
        {
            IEnumerable<JewelleryProductVM> jewelleryProductVM;
            using (_unitOfWork)
            {
                try
                {
                    jewelleryProductVM = await _unitOfWork.JewelleryProductRepository.SearchJewelleryProductDetails(itemCode, description, pageId);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
           
            return jewelleryProductVM;
        }

        public async  Task<IEnumerable<JewelleryProductVM>> SearchJewelleryProductDetailsByItemCode(string itemCode, int pageId)
        {
             IEnumerable<JewelleryProductVM> jewelleryProductVM;
            using (_unitOfWork)
            {
                try
                {
                    jewelleryProductVM = await _unitOfWork.JewelleryProductRepository.SearchJewelleryProductDetailsByItemCode(itemCode, pageId);

                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return jewelleryProductVM;
        }

        public async Task<IEnumerable<JewelleryProductVM>> SearchJewelleryProductDetailsByItemCode_All(string itemCode, int pageId)
        {
            IEnumerable<JewelleryProductVM> jewelleryProductVM;
            using (_unitOfWork)
            {
                try
                {
                    jewelleryProductVM = await _unitOfWork.JewelleryProductRepository.SearchJewelleryProductDetailsByItemCode_All(itemCode, pageId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return jewelleryProductVM;
        }

        public async Task<GoldRateVM> UpdateGoldRateDetail(GoldRateVM goldRateVM)
        {
            GoldRateVM goldRateVm = new GoldRateVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    goldRateVm = await _unitOfWork.JewelleryProductRepository.UpdateGoldRateDetail(goldRateVM);
                    _unitOfWork.CommitTransaction();

                } catch(Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }

            return goldRateVm;
        }

        public async Task<JewelleryProductVM> UpdateJewelleryImage(int Id, bool Add)
        {
            JewelleryProductVM jewelleryProductVm = new JewelleryProductVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    jewelleryProductVm = await _unitOfWork.JewelleryProductRepository.UpdateJewelleryImage(Id,Add);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return jewelleryProductVm;
        }

        public async Task<JewelleryProductVM> UpdateJewelleryProductDetails(JewelleryProductVM jewelleryProductVM)
        {
            JewelleryProductVM jewelleryProductVm = new JewelleryProductVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    jewelleryProductVM = await _unitOfWork.JewelleryProductRepository.UpdateJewelleryProductDetails(jewelleryProductVM);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return jewelleryProductVM;
        }

        public async Task<TraySlotVM> UpdateTraySlotDetails(int trayId, int sectionId, int productId, int traySlot)
        {
            TraySlotVM traySlotVM = new TraySlotVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    traySlotVM = await _unitOfWork.JewelleryProductRepository.UpdateTraySlotDetails(trayId,sectionId,productId,traySlot);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return traySlotVM;
        }
    }
}
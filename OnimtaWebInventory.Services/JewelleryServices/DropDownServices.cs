using OnimtaWebInventory.Core.IServices.IJewelleryService;
using OnimtaWebInventory.Models.Jewellery;
using OnimtaWebInventory.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Services.JewelleryServices
{
    public class DropDownServices : IDropDownServices
    {
        private IUnitOfWork _unitOfWork;

        public DropDownServices(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }


        public async Task<DropDownVM> AddNewTrayDetails(DropDownVM dropDownVM)
        {
            DropDownVM dropDownVm = new DropDownVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    dropDownVM = await _unitOfWork.DropDownRepository.AddNewTrayDetails(dropDownVM);
                    _unitOfWork.CommitTransaction();

                } catch(Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }

            return dropDownVM;
        }

        public async Task<DropDownVM> AddSectionDetails(DropDownVM DropDown)
        {
            DropDownVM dropDownVM = new DropDownVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    dropDownVM = await _unitOfWork.DropDownRepository.AddSectionDetails(DropDown);
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }

            return dropDownVM;
        }

        public async Task<DropDownVM> AddTrayCategoryDetails(DropDownVM dropDownVM)
        {
            DropDownVM dropDownVm = new DropDownVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    dropDownVM = await _unitOfWork.DropDownRepository.AddTrayCategoryDetails(dropDownVM);
                    _unitOfWork.CommitTransaction();
                }catch(Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }

            return dropDownVM;
        }

        public async Task<DropDownVM> AddJewelleryUnitDetials(DropDownVM dropDownVM)
        {
            DropDownVM dropDownVm = new DropDownVM();
            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    dropDownVm = await _unitOfWork.DropDownRepository.AddJewelleryUnitDetials(dropDownVM);
                    _unitOfWork.CommitTransaction();

                }catch(Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return dropDownVm;
        }

        public async Task<DropDownVM> DeleteSectionDetailsById(int id)
        {
            DropDownVM dropDownVM = new DropDownVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    dropDownVM = await _unitOfWork.DropDownRepository.DeleteSectionDetailsById(id);
                    _unitOfWork.CommitTransaction();
                }catch(Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return dropDownVM;
        }

        public async Task<DropDownVM> DeleteTrayCategoryDetails(int id)
        {
            DropDownVM dropDownVM = new DropDownVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    dropDownVM = await _unitOfWork.DropDownRepository.DeleteTrayCategoryDetails(id);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }

            return dropDownVM;
        }

        public async Task<DropDownVM> DeleteTrayDetailsById(int id)
        {
            DropDownVM dropDownVM = new DropDownVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    dropDownVM = await _unitOfWork.DropDownRepository.DeleteTrayDetailsById(id);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return dropDownVM;
        }

        public async Task<DropDownVM> DeleteJewelleryUnitDetials(int id, string Type)
        {
            DropDownVM dropDownVM = new DropDownVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    dropDownVM = await _unitOfWork.DropDownRepository.DeleteJewelleryUnitDetials(id,Type);
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return dropDownVM;
        }

        public async Task<IEnumerable<DropDownVM>> GetAllSectionDetails()
        {
            IEnumerable<DropDownVM> dropDownVM;

            using (_unitOfWork)
            {
                try
                {
                    dropDownVM = await _unitOfWork.DropDownRepository.GetAllSectionDetails();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return dropDownVM;
        }

        public async Task<IEnumerable<DropDownVM>> GetAllTrayCategoryDetails()
        {
            IEnumerable<DropDownVM> dropDownVM;

            using (_unitOfWork)
            {
                try
                {
                    dropDownVM = await _unitOfWork.DropDownRepository.GetAllTrayCategoryDetails();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return dropDownVM;
        }

        public async Task<IEnumerable<DropDownVM>> GetAllTrayDetails()
        {
            IEnumerable<DropDownVM> dropDownVM;

            using (_unitOfWork)
            {
                try
                {
                    dropDownVM = await _unitOfWork.DropDownRepository.GetAllTrayDetails();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return dropDownVM;
        }

        public async Task<IEnumerable<DropDownVM>> GetAllJewelleryUnitDetials(string Type)
        {
            IEnumerable<DropDownVM> dropDownVM;

            using (_unitOfWork)
            {
                try
                {
                    dropDownVM = await _unitOfWork.DropDownRepository.GetAllJewelleryUnitDetials(Type);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return dropDownVM;
        }

        public async Task<IEnumerable<TraySlotVM>> GetAvailableSlot(int trayId)
        {
            IEnumerable<TraySlotVM> traySlotVM;

            using (_unitOfWork)
            {
                try
                {
                    traySlotVM = await _unitOfWork.DropDownRepository.GetAvailableSlot(trayId);

                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return traySlotVM;
        }

        public async Task<IEnumerable<DropDownVM>> GetBanks()
        {
            IEnumerable<DropDownVM> dropDownVM;

            using (_unitOfWork)
            {
                try
                {
                    dropDownVM = await _unitOfWork.DropDownRepository.GetBanks();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }

            return dropDownVM;
        }

        public async  Task<DropDownVM> GetTrayCategoryDetailsById(int id)
        {
            DropDownVM dropDownVM = new DropDownVM();

            using (_unitOfWork)
            {
                try
                {
                    dropDownVM = await _unitOfWork.DropDownRepository.GetTrayCategoryDetailsById(id);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return dropDownVM;
        }

        public async Task<IEnumerable<DropDownVM>> GetTrayDetailsBySectionId(int sectionId)
        {
            IEnumerable<DropDownVM> dropDownVM;

            using (_unitOfWork)
            {
                try
                {
                    dropDownVM = await _unitOfWork.DropDownRepository.GetTrayDetailsBySectionId(sectionId);

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }

            return dropDownVM;
        }

        public async Task<TraySlotVM> GetTraySlotDetailsBySlotCode(string slotCode)
        {
            TraySlotVM traySlotVM = new TraySlotVM();

            using (_unitOfWork)
            {
                try
                {
                    traySlotVM = await _unitOfWork.DropDownRepository.GetTraySlotDetailsBySlotCode(slotCode);

                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return traySlotVM;
        }

        public  async Task<TraySlotVM> GetTraySlotDetailsBySlotId(int id)
        {
            TraySlotVM traySlotVM = new TraySlotVM();

            using (_unitOfWork)
            {
                try
                {
                    traySlotVM = await _unitOfWork.DropDownRepository.GetTraySlotDetailsBySlotId(id);
               
                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return traySlotVM;
        }

        public async Task<DropDownVM> GetJewelleryUnitDetialsById(int id, string Type)
        {
            DropDownVM dropDownVM = new DropDownVM();

            using (_unitOfWork)
            {
                try
                {
                    dropDownVM = await _unitOfWork.DropDownRepository.GetJewelleryUnitDetialsById(id,Type);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return dropDownVM;
        }

        public async  Task<DropDownVM> UpdateSectionDetails(DropDownVM dropDownVM)
        {
            DropDownVM dropDownVm = new DropDownVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    dropDownVM = await _unitOfWork.DropDownRepository.UpdateSectionDetails(dropDownVM);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return dropDownVM;
        }

        public async Task<DropDownVM> UpdateTrayCategoryDetails(DropDownVM dropDownVM)
        {
            DropDownVM dropDownVm = new DropDownVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    dropDownVM = await _unitOfWork.DropDownRepository.UpdateTrayCategoryDetails(dropDownVM);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }

            return dropDownVM;
        }

        public async Task<DropDownVM> UpdateTrayDetails(DropDownVM dropDownVM)
        {
            DropDownVM dropDownVm = new DropDownVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    dropDownVm = await _unitOfWork.DropDownRepository.UpdateTrayDetails(dropDownVM);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return dropDownVm;
        }

        public async Task<DropDownVM> UpdateJewelleryUnitDetials(DropDownVM dropDownVM)
        {
            DropDownVM dropDownVm = new DropDownVM();
            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    dropDownVM = await _unitOfWork.DropDownRepository.UpdateJewelleryUnitDetials(dropDownVM);
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return dropDownVM;
        }

        public async Task<IEnumerable<DropDownVM>> GetAllCreditCards()
        {

            IEnumerable<DropDownVM> dropDownVM;

            using (_unitOfWork)
            {
                try
                {
                    dropDownVM = await _unitOfWork.DropDownRepository.GetAllCreditCards();

                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return dropDownVM;
        }
    }
}

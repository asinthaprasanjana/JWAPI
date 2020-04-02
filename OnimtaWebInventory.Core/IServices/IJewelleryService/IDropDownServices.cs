using OnimtaWebInventory.Models.Jewellery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace OnimtaWebInventory.Core.IServices.IJewelleryService
{
    public interface IDropDownServices
    {
        Task<DropDownVM> AddSectionDetails(DropDownVM DropDown);
        Task<DropDownVM> AddNewTrayDetails(DropDownVM dropDownVM);

        Task<IEnumerable<DropDownVM>> GetAllSectionDetails();
        Task<IEnumerable<DropDownVM>> GetTrayDetailsBySectionId(int sectionId);
        Task<IEnumerable<DropDownVM>> GetAllTrayDetails();

        Task<DropDownVM> UpdateSectionDetails(DropDownVM dropDownVM);
        Task<DropDownVM> UpdateTrayDetails(DropDownVM dropDownVM);

        Task<DropDownVM> DeleteSectionDetailsById(int id);
        Task<DropDownVM> DeleteTrayDetailsById(int id);

        Task<DropDownVM> AddTrayCategoryDetails(DropDownVM dropDownVM);
        Task<DropDownVM> UpdateTrayCategoryDetails(DropDownVM dropDownVM);
        Task<IEnumerable<DropDownVM>> GetAllTrayCategoryDetails();
        Task<DropDownVM> GetTrayCategoryDetailsById(int id);
        Task<DropDownVM> DeleteTrayCategoryDetails(int id);

        Task<TraySlotVM> GetTraySlotDetailsBySlotCode(string slotCode);
        Task<IEnumerable<TraySlotVM>> GetAvailableSlot(int trayId);
        Task<TraySlotVM> GetTraySlotDetailsBySlotId(int id);

        Task<DropDownVM> AddJewelleryUnitDetials(DropDownVM dropDownVM);
        Task<DropDownVM> UpdateJewelleryUnitDetials(DropDownVM dropDownVM);
        Task<DropDownVM> GetJewelleryUnitDetialsById(int id,string Type);
        Task<IEnumerable<DropDownVM>> GetAllJewelleryUnitDetials(string Type);
        Task<DropDownVM> DeleteJewelleryUnitDetials(int id, string Type);

        Task<IEnumerable<DropDownVM>> GetBanks();
        Task<IEnumerable<DropDownVM>> GetAllCreditCards();

    }
}

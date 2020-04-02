using OnimtaWebInventory.Models.Jewellery;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository.IJewelleryRepository
{
    public interface ICategoryRepository
    {

        Task<CategoryVM> AddItemCategoryDetails(CategoryVM categoryVM);
        Task<CategoryVM> UpdateItemCategoryDetails(CategoryVM categoryVM);
        Task<CategoryVM> DeleteItemCategoryDetails(int id);

        Task<CategoryVM> AddDesignCategoryDetails(CategoryVM categoryVM);
        Task<CategoryVM> UpdateDesignCategoryDetails(CategoryVM categoryVM);
        Task<CategoryVM> DeleteDesignCategoryDetails(int id);

        Task<CategoryVM> AddGemCategoryDetails(CategoryVM categoryVM);
        Task<CategoryVM> UpdateGemCategoryDetails(CategoryVM categoryVM);
        Task<CategoryVM> DeleteGemCategoryDetails(int id);

        Task<CategoryVM> AddMaterialCategoryDetails(CategoryVM categoryVM);
        Task<CategoryVM> UpdateMaterialCategoryDetails(CategoryVM categoryVM);
        Task<CategoryVM> DeleteMaterialCategoryDetails(int id);

        Task <IEnumerable<CategoryVM>> GetAllJewelleryCategoriesDesign();
        Task <IEnumerable<CategoryVM>> GetAllJewelleryCategoriesItem();
        Task <IEnumerable<CategoryVM>> GetAllJewelleryCategoriesGem();
        Task <IEnumerable<CategoryVM>> GetAllJewelleryCategoriesMaterial();

    }
}

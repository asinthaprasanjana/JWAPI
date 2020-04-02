using OnimtaWebInventory.Core.IServices.IJewelleryService;
using OnimtaWebInventory.Models.Jewellery;
using OnimtaWebInventory.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Services.JewelleryServices
{
    public class CategoryServices : ICategoryServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryServices(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }

        public async Task<IEnumerable<CategoryVM>> GetAllJewelleryCategoriesDesign()
        {
            IEnumerable<CategoryVM> categories;

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    categories = await _unitOfWork.CategoryRepository.GetAllJewelleryCategoriesDesign();
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return categories;
        }

        public async Task<IEnumerable<CategoryVM>> GetAllJewelleryCategoriesItem()
        {
            IEnumerable<CategoryVM> categories;

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    categories = await _unitOfWork.CategoryRepository.GetAllJewelleryCategoriesItem();
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return categories;
        }

        public async Task<IEnumerable<CategoryVM>> GetAllJewelleryCategoriesGem()
        {
            IEnumerable<CategoryVM> categories;

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    categories = await _unitOfWork.CategoryRepository.GetAllJewelleryCategoriesGem();
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return categories;
        }

        public async Task<IEnumerable<CategoryVM>> GetAllJewelleryCategoriesMaterial()
        {
            IEnumerable<CategoryVM> categories;

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    categories = await _unitOfWork.CategoryRepository.GetAllJewelleryCategoriesMaterial();
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return categories;
        }


        public async Task<CategoryVM> AddDesignCategoryDetails(CategoryVM categoryVM)
        {
            CategoryVM categoryVm = new CategoryVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    categoryVm = await _unitOfWork.CategoryRepository.AddDesignCategoryDetails(categoryVM);
                    _unitOfWork.CommitTransaction();

                }catch(Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return categoryVm;
        }

        public async Task<CategoryVM> AddGemCategoryDetails(CategoryVM categoryVM)
        {
            CategoryVM categoryVm = new CategoryVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    categoryVm = await _unitOfWork.CategoryRepository.AddGemCategoryDetails(categoryVM);
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return categoryVm;
        }

        public async Task<CategoryVM> AddItemCategoryDetails(CategoryVM categoryVM)
        {
            CategoryVM categoryVm = new CategoryVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    categoryVm = await _unitOfWork.CategoryRepository.AddItemCategoryDetails(categoryVM);
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return categoryVm;
        }

        public async Task<CategoryVM> AddMaterialCategoryDetails(CategoryVM categoryVM)
        {
            CategoryVM categoryVm = new CategoryVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    categoryVm = await _unitOfWork.CategoryRepository.AddMaterialCategoryDetails(categoryVM);
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return categoryVm;
        }

        public async Task<CategoryVM> DeleteDesignCategoryDetails(int id)
        {
            CategoryVM categoryVm = new CategoryVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    categoryVm = await _unitOfWork.CategoryRepository.DeleteDesignCategoryDetails(id);
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return categoryVm;
        }

        public async Task<CategoryVM> DeleteGemCategoryDetails(int id)
        {
            CategoryVM categoryVm = new CategoryVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    categoryVm = await _unitOfWork.CategoryRepository.DeleteGemCategoryDetails(id);
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return categoryVm;
        }

        public async Task<CategoryVM> DeleteItemCategoryDetails(int id)
        {
            CategoryVM categoryVm = new CategoryVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    categoryVm = await _unitOfWork.CategoryRepository.DeleteItemCategoryDetails(id);
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return categoryVm;
        }

        public async Task<CategoryVM> DeleteMaterialCategoryDetails(int id)
        {
            CategoryVM categoryVm = new CategoryVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    categoryVm = await _unitOfWork.CategoryRepository.DeleteMaterialCategoryDetails(id);
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return categoryVm;
        }


        public async Task<CategoryVM> UpdateDesignCategoryDetails(CategoryVM categoryVM)
        {
            CategoryVM categoryVm = new CategoryVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    categoryVm = await _unitOfWork.CategoryRepository.UpdateDesignCategoryDetails(categoryVM);
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return categoryVm;
        }

        public async Task<CategoryVM> UpdateGemCategoryDetails(CategoryVM categoryVM)
        {
            CategoryVM categoryVm = new CategoryVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    categoryVm = await _unitOfWork.CategoryRepository.UpdateGemCategoryDetails(categoryVM);
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return categoryVm;
        }

        public async Task<CategoryVM> UpdateItemCategoryDetails(CategoryVM categoryVM)
        {
            CategoryVM categoryVm = new CategoryVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    categoryVm = await _unitOfWork.CategoryRepository.UpdateItemCategoryDetails(categoryVM);
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return categoryVm;
        }

        public async Task<CategoryVM> UpdateMaterialCategoryDetails(CategoryVM categoryVM)
        {
            CategoryVM categoryVm = new CategoryVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    categoryVm = await _unitOfWork.CategoryRepository.UpdateMaterialCategoryDetails(categoryVM);
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return categoryVm;
        }
    }
}

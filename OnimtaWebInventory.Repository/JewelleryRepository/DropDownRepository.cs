using Dapper;
using DBConnect;
using OnimtaWebInventory.Core.IRepository.IJewelleryRepository;
using OnimtaWebInventory.Models.Jewellery;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Repository.JewelleryRepository
{
    public class DropDownRepository :DBContext, IDropDownRepository
    {
        public async Task<DropDownVM> AddNewTrayDetails(DropDownVM dropDownVM)
        {
            DropDownVM dropDownVm = new DropDownVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@SectionId", dropDownVM.SectionId);
                dynamicParameterlist.Add("@Name", dropDownVM.Name);
                dynamicParameterlist.Add("@Category", dropDownVM.Category);
                dynamicParameterlist.Add("@TrayIdName", dropDownVM.IdName);
                dynamicParameterlist.Add("@NumberOfItems", dropDownVM.numberOfItems);
                dropDownVM = await dbConnection.QuerySingleOrDefaultAsync<DropDownVM>("[msd].[AddNewTrayDetails]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dropDownVM;
        }

        public async Task<DropDownVM> AddSectionDetails(DropDownVM DropDown)
        {
            DropDownVM dropDownVM = new DropDownVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Name", DropDown.Name);
                dynamicParameterlist.Add("@sectionIdName", DropDown.IdName);
                dropDownVM = await dbConnection.QuerySingleOrDefaultAsync<DropDownVM>("[msd].[AddSectionDetails]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dropDownVM;
        }

        public async Task<DropDownVM> AddTrayCategoryDetails(DropDownVM dropDownVM)
        {

            DropDownVM dropDownVm = new DropDownVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Name", dropDownVM.Name);
                dropDownVM = await dbConnection.QuerySingleOrDefaultAsync<DropDownVM>("[msd].[AddTrayCategoryDetails]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dropDownVM;
        }

        public async Task<DropDownVM> AddJewelleryUnitDetials(DropDownVM dropDownVM)
        {
            DropDownVM dropDownVm = new DropDownVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Name", dropDownVM.Name);

                if (dropDownVM.Type == "UOM")// UOM is Unit Of Measure
                {
                    dropDownVM = await dbConnection.QuerySingleOrDefaultAsync<DropDownVM>("[msd].[AddUnitOfMeasureDetials]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

                }else if(dropDownVM.Type == "DC")//DC is Diamond Clarity
                {
                    dropDownVM = await dbConnection.QuerySingleOrDefaultAsync<DropDownVM>("[msd].[AddDiamondClarityDetails]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dropDownVM;
        }
        

        public async Task<DropDownVM> DeleteSectionDetailsById(int id)
        {
            DropDownVM dropDownVM = new DropDownVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", id);
                dropDownVM = await dbConnection.QuerySingleOrDefaultAsync<DropDownVM>("[msd].[DeleteSectionDetailsById]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dropDownVM;
        }

        public async Task<DropDownVM> DeleteTrayCategoryDetails(int id)
        {
            DropDownVM dropDownVM = new DropDownVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", id);
                dropDownVM = await dbConnection.QuerySingleOrDefaultAsync<DropDownVM>("[msd].[DeleteTrayCategoryDetails]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dropDownVM;
        }

        public async Task<DropDownVM> DeleteTrayDetailsById(int id)
        {
            DropDownVM dropDownVM = new DropDownVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", id);
                dropDownVM = await dbConnection.QuerySingleOrDefaultAsync<DropDownVM>("[msd].[DeleteTrayDetailsById]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dropDownVM;
        }

        public async Task<DropDownVM> DeleteJewelleryUnitDetials(int id, string Type)
        {
            DropDownVM dropDownVM = new DropDownVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", id);

                if(Type == "UOM")// UOM is Unit Of Measure
                {
                    dropDownVM = await dbConnection.QuerySingleOrDefaultAsync<DropDownVM>("[msd].[DeleteUnitOfMeasureDetials]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

                }else if (Type == "DC")//DC is Diamond Clarity
                {
                    dropDownVM = await dbConnection.QuerySingleOrDefaultAsync<DropDownVM>("[msd].[DeleteDiamondClarityDetails]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dropDownVM;
        }

        public async  Task<IEnumerable<DropDownVM>> GetAllSectionDetails()
        {
            IEnumerable<DropDownVM> dropDownVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dropDownVM = await dbConnection.QueryAsync<DropDownVM>("[msd].[GetAllSectionDetails]", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dropDownVM;
        }

        public async Task<IEnumerable<DropDownVM>> GetAllTrayCategoryDetails()
        {
            IEnumerable<DropDownVM> dropDownVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dropDownVM = await dbConnection.QueryAsync<DropDownVM>("[msd].[GetAllTrayCategoryDetails]", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dropDownVM;
        }

        public async  Task<IEnumerable<DropDownVM>> GetAllTrayDetails()
        {
            IEnumerable<DropDownVM> dropDownVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dropDownVM = await dbConnection.QueryAsync<DropDownVM>("[msd].[GetAllTrayDetails]", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dropDownVM;
        }

        public async Task<IEnumerable<DropDownVM>> GetAllJewelleryUnitDetials(string Type)
        {
            IEnumerable<DropDownVM> dropDown = null ;
            try
            {
                var dynamicParameterlist = new DynamicParameters();

                if (Type == "UOM")
                {
                    dropDown = await dbConnection.QueryAsync<DropDownVM>("[msd].[GetAllUnitOfMeasureDetials]", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                }
                else if (Type == "DC")
                {
                    dropDown = await dbConnection.QueryAsync<DropDownVM>("[msd].[GetAllDiamondClarityDetails]", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dropDown;
        }

        public async Task<IEnumerable<TraySlotVM>> GetAvailableSlot(int trayId)
        {
            IEnumerable<TraySlotVM> traySlotVM;
            try
            {
                var dynamicParaeterlist = new DynamicParameters();
                dynamicParaeterlist.Add("@TrayId", trayId);
                traySlotVM = await dbConnection.QueryAsync<TraySlotVM>("msd.GetAvailableSlot", dynamicParaeterlist, commandType: CommandType.StoredProcedure);
             
                 for(int i= 0; i < traySlotVM.Count(); i++)
                {
                    if (traySlotVM.ElementAt(i).ProductId != null)
                    {
                        var productId = new DynamicParameters();
                        productId.Add("@Id", traySlotVM.ElementAt(i).ProductId);
                        traySlotVM.ElementAt(i).Product = await dbConnection.QuerySingleOrDefaultAsync<JewelleryProductVM>("[msd].[GetJewelleryProductDetailsById]", productId, commandType: CommandType.StoredProcedure);

                    }
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return traySlotVM;
        }

        public async Task<IEnumerable<DropDownVM>> GetBanks()
        {
            IEnumerable<DropDownVM> dropDownVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dropDownVM = await dbConnection.QueryAsync<DropDownVM>("[inv].[GetBanks]", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dropDownVM;
        }

        public async Task<DropDownVM> GetTrayCategoryDetailsById(int id)
        {
            DropDownVM dropDownVM = new DropDownVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", id);
                dropDownVM = await dbConnection.QuerySingleOrDefaultAsync<DropDownVM>("[msd].[GetTrayCategoryDetailsById]", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dropDownVM;
        }

        public async Task<IEnumerable<DropDownVM>> GetTrayDetailsBySectionId(int sectionId)
        {
            IEnumerable<DropDownVM> dropDownVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@SectionId",sectionId);
                dropDownVM = await dbConnection.QueryAsync<DropDownVM>("[msd].[GetTrayDetailsBySectionId]", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dropDownVM;
        }

        public async Task<TraySlotVM> GetTraySlotDetailsBySlotCode(string slotCode)
        {
            TraySlotVM traySlotVM = new TraySlotVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@SlotCode", slotCode);
                traySlotVM = await dbConnection.QuerySingleOrDefaultAsync<TraySlotVM>("[msd].[GetTraySlotDetailsBySlotCode]", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return traySlotVM;
        }

        public async Task<TraySlotVM> GetTraySlotDetailsBySlotId(int id)
        {
            TraySlotVM traySlotVM = new TraySlotVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", id);
                traySlotVM = await dbConnection.QuerySingleOrDefaultAsync<TraySlotVM>("msd.GetTraySlotDetailsBySlotId", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return traySlotVM;
        }

        public async Task<DropDownVM> GetJewelleryUnitDetialsById(int id, string Type)
        {
            DropDownVM dropDownVM = new DropDownVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", id);

                if(Type == "UOM")
                {
                    dropDownVM = await dbConnection.QuerySingleOrDefaultAsync<DropDownVM>("[msd].[GetUnitOfMeasureDetialsById]", dynamicParameterlist, commandType: CommandType.StoredProcedure);

                }else if (Type == "DC")
                {
                    dropDownVM = await dbConnection.QuerySingleOrDefaultAsync<DropDownVM>("[msd].[GetDiamondClarityDetailsById]", dynamicParameterlist, commandType: CommandType.StoredProcedure);

                }

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dropDownVM;
        }

        public async Task<DropDownVM> UpdateSectionDetails(DropDownVM dropDownVM)
        {
            DropDownVM dropDownVm = new DropDownVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", dropDownVM.Id);
                dynamicParameterlist.Add("@Name", dropDownVM.Name);
                dynamicParameterlist.Add("@SectionIdName", dropDownVM.IdName);
                dynamicParameterlist.Add("@IsDeleted", dropDownVM.IsDeleted);
                dropDownVM = await dbConnection.QuerySingleOrDefaultAsync<DropDownVM>("[msd].[UpdateSectionDetails]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dropDownVM;
        }

        public async Task<DropDownVM> UpdateTrayCategoryDetails(DropDownVM dropDownVM)
        {
            DropDownVM dropDownVm = new DropDownVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", dropDownVM.Id);
                dynamicParameterlist.Add("@Name", dropDownVM.Name);
                dropDownVm = await dbConnection.QuerySingleOrDefaultAsync<DropDownVM>("[msd].[UpdateTrayCategoryDetails]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dropDownVm;
        }

        public async Task<DropDownVM> UpdateTrayDetails(DropDownVM dropDownVM)
        {
            DropDownVM dropDownVm = new DropDownVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", dropDownVM.Id);
                dynamicParameterlist.Add("@Name", dropDownVM.Name);
                dynamicParameterlist.Add("@Category", dropDownVM.Category);
                dynamicParameterlist.Add("@TrayIdName", dropDownVM.IdName);
                dynamicParameterlist.Add("@IsActive", dropDownVM.IsActive);
                dynamicParameterlist.Add("@NumberOfItems", dropDownVM.numberOfItems);
                dynamicParameterlist.Add("@IsDeleted", dropDownVM.IsDeleted);
                dropDownVm = await dbConnection.QuerySingleOrDefaultAsync<DropDownVM>("[msd].[UpdateTrayDetails]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dropDownVm;
        }

        public async Task<DropDownVM> UpdateJewelleryUnitDetials(DropDownVM dropDownVM)
        {
            DropDownVM dropDownVm = new DropDownVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", dropDownVM.Id);
                dynamicParameterlist.Add("@Name", dropDownVM.Name);

                if(dropDownVM.Type == "UOM")//UNIT OF MEASURE
                {
                    dropDownVm = await dbConnection.QuerySingleOrDefaultAsync<DropDownVM>("[msd].[UpdateUnitOfMeasureDetials]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

                } else if (dropDownVM.Type == "DC")// DIAMOND CLARITY
                {
                    dropDownVm = await dbConnection.QuerySingleOrDefaultAsync<DropDownVM>("[msd].[UpdateDiamondClarityDetails]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dropDownVm;
        }

        public async Task<IEnumerable<DropDownVM>> GetAllCreditCards()
        {
            IEnumerable<DropDownVM> dropDownVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dropDownVM = await dbConnection.QueryAsync<DropDownVM>("[msd].[GetAllCreditCards]", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dropDownVM;
        }
    }
}

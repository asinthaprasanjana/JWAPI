using Dapper;
using DBConnect;
using OnimtaWebInventory.Core.IRepository.IJewelleryRepository;
using OnimtaWebInventory.Models.Jewellery;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using IronXL;
using System.Linq;
using Microsoft.AspNetCore.Http;
using ExcelDataReader;
using System.IO;


namespace OnimtaWebInventory.Repository.JewelleryRepository
{
    public class JewelleryProductRepository : DBContext, IJewelleryProductRepository
    {
        public async Task<GoldRateVM> AddGoldRateDetail(GoldRateVM goldRateVM)
        {
            GoldRateVM goldRateVm = new GoldRateVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Rate",goldRateVM.Rate);
                goldRateVm = await dbConnection.QuerySingleOrDefaultAsync<GoldRateVM>("[msd].[AddGoldRateDetail]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return goldRateVm;
        }

        public async Task<JewelleryProductVM> AddJewelleryProduct(JewelleryProductVM jewelleryProduct)
        {
            JewelleryProductVM jewelleryProductVm = new JewelleryProductVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
               // dynamicParameterlist.Add("@Id", jewelleryProduct.Id);
                dynamicParameterlist.Add("@Standard", jewelleryProduct.Standard);
                dynamicParameterlist.Add("@Category", jewelleryProduct.Category);
                dynamicParameterlist.Add("@SubCategory", jewelleryProduct.SubCategory);
                dynamicParameterlist.Add("@Supplier", jewelleryProduct.Supplier);
                dynamicParameterlist.Add("@Brand", jewelleryProduct.Brand);
                dynamicParameterlist.Add("@ItemCode", jewelleryProduct.ItemCode);
                dynamicParameterlist.Add("@MadeIn", jewelleryProduct.MadeIn);
                dynamicParameterlist.Add("@Description", jewelleryProduct.Description);
                dynamicParameterlist.Add("@Section", jewelleryProduct.Section);
                dynamicParameterlist.Add("@Tray", jewelleryProduct.Tray);
                dynamicParameterlist.Add("@BillDescription", jewelleryProduct.BillDescription);
                dynamicParameterlist.Add("@DesignCode", jewelleryProduct.DesignCode);
                dynamicParameterlist.Add("@UOM", jewelleryProduct.uom);
                dynamicParameterlist.Add("@GoldWeight", jewelleryProduct.GoldWeight);
                dynamicParameterlist.Add("@Material", jewelleryProduct.Material);
                dynamicParameterlist.Add("@ConsiderStoneWeight", jewelleryProduct.ConsiderStoneWeight);
                dynamicParameterlist.Add("@CostPrice", jewelleryProduct.CostPrice);
                dynamicParameterlist.Add("@SellingPrice", jewelleryProduct.SellingPrice);
                dynamicParameterlist.Add("@MinimumPrice", jewelleryProduct.MinimumPrice);
                dynamicParameterlist.Add("@StoneWeight", jewelleryProduct.StoneWeight);
                dynamicParameterlist.Add("@DiamondWeight", jewelleryProduct.DiamondWeight);
                dynamicParameterlist.Add("@CentreStoneWeight", jewelleryProduct.CentreStoneWeight);
                dynamicParameterlist.Add("@DiamondClarity", jewelleryProduct.DiamondClarity);
                dynamicParameterlist.Add("@CreatedUserId", jewelleryProduct.CreatedUserId);
                dynamicParameterlist.Add("@CostCode", jewelleryProduct.CostCode);
                dynamicParameterlist.Add("@AutoGenItemCode", jewelleryProduct.AutoGenItemCode);
             //   dynamicParameterlist.Add("@AutoGenItemCode", jewelleryProduct.AutoGenItemCode);
                dynamicParameterlist.Add("@Margin", jewelleryProduct.Margin);

                jewelleryProductVm = await dbConnection.QuerySingleOrDefaultAsync<JewelleryProductVM>("[msd].[AddJewelleryProduct]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

               

                //string serverWebRoot1 = @"E:\Jethro\JethroApi\ImageBackups";
                //string newPath1 = Path.Combine(serverWebRoot1, folderName);
                //if (!Directory.Exists(newPath1))
                //{
                //    Directory.CreateDirectory(newPath1);
                //}
                //if (file.Length > 0)
                //{
                //    string fullPath = Path.Combine(newPath1, fileName);
                //    using (var stream = new FileStream(fullPath, FileMode.Create))
                //    {
                //        file.CopyTo(stream);
                //    }
                //}

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return jewelleryProductVm;
        }

        public async Task<JewelleryTransferVM> AddJewelleryTransfer(JewelleryTransferVM  transfer)
        {
            JewelleryTransferVM Transfer = new JewelleryTransferVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Remarks", transfer.Remarks);
                dynamicParameterlist.Add("@UserId", transfer.UserId);
                Transfer = await dbConnection.QuerySingleOrDefaultAsync<JewelleryTransferVM>("[msd].[AddJewelleryTransfer]", dynamicParameterlist,_transaction, commandType: CommandType.StoredProcedure);

                foreach(JewelleryTransferProductsVM product in transfer.Products)
                {
                    var productParameters = new DynamicParameters();
                    productParameters.Add("@Product", product.Product);
                    productParameters.Add("@TransferId", Transfer.Id);
                    await dbConnection.QuerySingleOrDefaultAsync<JewelleryTransferProductsVM>("[msd].[AddJewelleryTransferProduct]", productParameters, _transaction, commandType: CommandType.StoredProcedure);
                }

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Transfer;
        }

        public async Task<JewelleryTransferVM> cancellTransfer(JewelleryTransferVM transfer)
        {
            JewelleryTransferVM Transfer = new JewelleryTransferVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@TransferId", transfer.Id);
                Transfer = await dbConnection.QuerySingleOrDefaultAsync<JewelleryTransferVM>("[msd].[CancelJewelleryTransfer]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

                //foreach (JewelleryTransferProductsVM product in transfer.Products)
                //{
                //    var productParameters = new DynamicParameters();
                //    productParameters.Add("@Product", product.Product);
                //    productParameters.Add("@TransferId", Transfer.Id);
                //    await dbConnection.QuerySingleOrDefaultAsync<JewelleryTransferProductsVM>("[msd].[CancelJewelleryTransferProducts]", productParameters, _transaction, commandType: CommandType.StoredProcedure);
                //}

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Transfer;
        }



        public async Task<JewelleryProductVM> DeleteJewelleryProduct(int id)
        {
            JewelleryProductVM jewelleryProductVM = new JewelleryProductVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", id);
                jewelleryProductVM = await dbConnection.QuerySingleOrDefaultAsync<JewelleryProductVM>("[msd].[DeleteJewelleryProduct]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return jewelleryProductVM;
        }

        public async Task<IEnumerable<GoldRateVM>> GetAllGoldRateDetails()
        {
            IEnumerable<GoldRateVM> goldRateVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                goldRateVM = await dbConnection.QueryAsync<GoldRateVM>("[msd].[GetAllGoldRateDetails]", dynamicParameterlist, commandType: CommandType.StoredProcedure);
          
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return goldRateVM;
        }

        public async Task<IEnumerable<JewelleryProductVM>> GetAllJewelleryProductDetails(FilterVM filter)
        {
            IEnumerable<JewelleryProductVM> jewelleryProductVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PageId",filter.pageId);
                dynamicParameterlist.Add("@Keyword",filter.keyword);
                dynamicParameterlist.Add("@SortDirection",filter.sortDirection);
                dynamicParameterlist.Add("@SortActive",filter.sortActive);
                dynamicParameterlist.Add("@Limit",filter.limit);
                dynamicParameterlist.Add("@FilterActive",filter.FilterActive);
                dynamicParameterlist.Add("@FilterValue",filter.FilterValue);
                jewelleryProductVM = await dbConnection.QueryAsync<JewelleryProductVM>("[msd].[GetAllJewelleryProductDetails]", dynamicParameterlist, commandType: CommandType.StoredProcedure);

                for(int i =0; i < jewelleryProductVM.Count(); i++)
                {
                    var subCategoryId = new DynamicParameters();
                    subCategoryId.Add("@Id", jewelleryProductVM.ElementAt(i).SubCategory);
                    jewelleryProductVM.ElementAt(i).SubCategoryObj = await dbConnection.QuerySingleOrDefaultAsync<CategoryVM>("[msd].[GetJewelleryCategoryById_design]", subCategoryId, commandType: CommandType.StoredProcedure);

                    var categoryId = new DynamicParameters();
                    categoryId.Add("@Id", jewelleryProductVM.ElementAt(i).Category);
                    jewelleryProductVM.ElementAt(i).CategoryObj = await dbConnection.QuerySingleOrDefaultAsync<CategoryVM>("[msd].[GetJewelleryCategoryById_item]", categoryId, commandType: CommandType.StoredProcedure);

                    var materialId = new DynamicParameters();
                    materialId.Add("@Id", jewelleryProductVM.ElementAt(i).Material);
                    jewelleryProductVM.ElementAt(i).MaterialObj = await dbConnection.QuerySingleOrDefaultAsync<CategoryVM>("[msd].[GetJewelleryCategoryById_material]", materialId, commandType: CommandType.StoredProcedure);
                }

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return jewelleryProductVM;
        }

        public async Task<IEnumerable<JewelleryTransferVM>> GetAllJewelleryTransfers(FilterVM filter)
        {
            IEnumerable<JewelleryTransferVM> jewelleryTransferProductVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PageId", filter.pageId);
                dynamicParameterlist.Add("@Keyword", filter.keyword);
                dynamicParameterlist.Add("@SortDirection", filter.sortDirection);
                dynamicParameterlist.Add("@SortActive", filter.sortActive);
                dynamicParameterlist.Add("@Limit", filter.limit);
                dynamicParameterlist.Add("@FilterActive", filter.FilterActive);
                dynamicParameterlist.Add("@FilterValue", filter.FilterValue);
                jewelleryTransferProductVM = await dbConnection.QueryAsync<JewelleryTransferVM>("[msd].[GetAllJewelleryTransfers]", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return jewelleryTransferProductVM;
        }

        public async Task<GoldRateVM> GetGoldRateDetailsByDate()
        {
            GoldRateVM goldRateVM = new GoldRateVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                goldRateVM = await dbConnection.QuerySingleOrDefaultAsync<GoldRateVM>("[msd].[GetGoldRateDetailsByDate]", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return goldRateVM;
        }

        public async Task<JewelleryProductVM> GetJewelleryProductDetailsById(int id)
        {
           
     
            JewelleryProductVM jewelleryProductVM = new JewelleryProductVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", id);
                jewelleryProductVM = await dbConnection.QuerySingleOrDefaultAsync<JewelleryProductVM>("[msd].[GetJewelleryProductDetailsById]", dynamicParameterlist, commandType: CommandType.StoredProcedure);

                var subCategoryId = new DynamicParameters();
                subCategoryId.Add("@Id", jewelleryProductVM.SubCategory);
                jewelleryProductVM.SubCategoryObj = await dbConnection.QuerySingleOrDefaultAsync<CategoryVM>("[msd].[GetJewelleryCategoryById_design]", subCategoryId, commandType: CommandType.StoredProcedure);

                var categoryId = new DynamicParameters();
                categoryId.Add("@Id", jewelleryProductVM.Category);
                jewelleryProductVM.CategoryObj = await dbConnection.QuerySingleOrDefaultAsync<CategoryVM>("[msd].[GetJewelleryCategoryById_item]", categoryId, commandType: CommandType.StoredProcedure);

                var materialId = new DynamicParameters();
                materialId.Add("@Id", jewelleryProductVM.Material);
                jewelleryProductVM.MaterialObj = await dbConnection.QuerySingleOrDefaultAsync<CategoryVM>("[msd].[GetJewelleryCategoryById_material]", materialId, commandType: CommandType.StoredProcedure);

                //var gemId = new DynamicParameters();
                //materialId.Add("@Id", jewelleryProductVM.Gem);
                //jewelleryProductVM.GemObj = await dbConnection.QuerySingleOrDefaultAsync<CategoryVM>("[msd].[GetJewelleryCategoryById_gem]", categoryId, commandType: CommandType.StoredProcedure);


                var sectionId = new DynamicParameters();
                sectionId.Add("@Id", jewelleryProductVM.Section);
                jewelleryProductVM.SectionObj = await dbConnection.QuerySingleOrDefaultAsync<DropDownVM>("[msd].[GetSectionDetailsById]", sectionId, commandType: CommandType.StoredProcedure);

                var trayId = new DynamicParameters();
                trayId.Add("@Id", jewelleryProductVM.Tray);
                jewelleryProductVM.TrayObj = await dbConnection.QuerySingleOrDefaultAsync<DropDownVM>("[msd].[GetTrayDetailsById]", trayId, commandType: CommandType.StoredProcedure);

             
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return jewelleryProductVM;
        }

        public async Task<IEnumerable<JewelleryProductVM>> GetJewelleryProductLogByProductId(int id)
        {
                IEnumerable<JewelleryProductVM> jewelleryProductVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@ProductId", id);
                jewelleryProductVM = await dbConnection.QueryAsync<JewelleryProductVM>("msd.GetJewelleryProductLogByProductId", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return jewelleryProductVM;
        }

        public async Task<JewelleryTransferVM> GetJewelleryTransferByTransferId(int TransferId)
        {
            JewelleryTransferVM Transfer = new JewelleryTransferVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", TransferId);
                Transfer = await dbConnection.QuerySingleOrDefaultAsync<JewelleryTransferVM>("[msd].[GetJewelleryTransferById]", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                Transfer.Products = await dbConnection.QueryAsync<JewelleryTransferProductsVM>("[msd].[GetJewelleryTransferProductsByTransferId]", dynamicParameterlist, commandType: CommandType.StoredProcedure);

                for(int i =0; i < Transfer.Products.Count(); i++)
                {
                    var para = new DynamicParameters();
                    para.Add("@Id", Transfer.Products.ElementAt(i).Product);
                    Transfer.Products.ElementAt(i).ProductObj = await dbConnection.QuerySingleOrDefaultAsync<JewelleryProductVM>("[msd].[GetJewelleryProductDetailsById]", para, commandType: CommandType.StoredProcedure);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Transfer;
        }

        public async Task<GoldRateVM> GetReceiptNumber()
        {
            GoldRateVM goldRateVM = new GoldRateVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                goldRateVM = await dbConnection.QuerySingleOrDefaultAsync<GoldRateVM>("[msd].[GetReceiptNumber]", dynamicParameterlist, commandType: CommandType.StoredProcedure);
           
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return goldRateVM;
        }

        public Task<JewelleryProductVM> ImportExcel(JewelleryProductVM jewelleryProductVM)
        {
            throw new NotImplementedException();
        }

        public async Task <IEnumerable<JewelleryProductVM>> ImportProductExcel(Boolean autoGenItemCode,IFormFile file)
        {

            List<JewelleryProductVM> jewelleries = new List<JewelleryProductVM>();
            List<JewelleryProductVM> existingJewelleries = new List<JewelleryProductVM>();
            List<JewelleryProductVM> returnJewelleries = new List<JewelleryProductVM>();
            List<JewelleryProductVM> NewJewelleries = new List<JewelleryProductVM>();
            List<JewelleryProductVM> NoCategoryJewellery = new List<JewelleryProductVM>();
            List<JewelleryProductVM> ExistInExcelJewellery = new List<JewelleryProductVM>();

            try
            {
                Stream stream = file.OpenReadStream();
                IExcelDataReader reader = null;

                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                DataSet excelRecords = reader.AsDataSet();
                reader.Close();
                var finalRecords = excelRecords.Tables[0];
                for (int i = 1; i < finalRecords.Rows.Count; i++)
                {

                    JewelleryProductVM jewellery = new JewelleryProductVM();
                    var dynamicParameterlist = new DynamicParameters();
                    int categoryId = 0, designId = 0, materialId = 0,count=0;

                   if(!autoGenItemCode) {
                        dynamicParameterlist.Add("@ItemCode", finalRecords.Rows[i][0].ToString());
                        count = await dbConnection.QuerySingleOrDefaultAsync<int>("[msd].[SearchDuplicateItemCode]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
                    }

                    { //item Code Extraction
                        var dynamicCode = new DynamicParameters();
                        dynamicCode.Add("@CategoryType", "item");
                        dynamicCode.Add("@Code", finalRecords.Rows[i][2].ToString());
                        categoryId = await dbConnection.QuerySingleOrDefaultAsync<int>("[msd].[GetCatergoryIdByCode]", dynamicCode, _transaction, commandType: CommandType.StoredProcedure);
                    }
                    { //design Code Extraction (AKA Subcategory)
                        var dynamicCode = new DynamicParameters();
                        dynamicCode.Add("@CategoryType", "design");
                        dynamicCode.Add("@Code", finalRecords.Rows[i][3].ToString());
                        designId = await dbConnection.QuerySingleOrDefaultAsync<int>("[msd].[GetCatergoryIdByCode]", dynamicCode, _transaction, commandType: CommandType.StoredProcedure);
                    }
                    { //design Code Extraction (AKA Subcategory)
                        var dynamicCode = new DynamicParameters();
                        dynamicCode.Add("@CategoryType", "material");
                        dynamicCode.Add("@Code", finalRecords.Rows[i][19].ToString());
                        materialId = await dbConnection.QuerySingleOrDefaultAsync<int>("[msd].[GetCatergoryIdByCode]", dynamicCode, _transaction, commandType: CommandType.StoredProcedure);
                    }


                    jewellery.ItemCode = finalRecords.Rows[i][0].ToString();
                    jewellery.Standard = finalRecords.Rows[i][1].ToString();
                    jewellery.Category = categoryId;
                    jewellery.SubCategory = designId;
                    jewellery.Supplier = finalRecords.Rows[i][4].ToString();
                    jewellery.Brand = finalRecords.Rows[i][5].ToString();
                    jewellery.MadeIn = finalRecords.Rows[i][6].ToString();
                    jewellery.Description = finalRecords.Rows[i][7].ToString();
                    jewellery.BillDescription = finalRecords.Rows[i][8].ToString();
                    jewellery.Section = 0;
                    jewellery.Tray = 0;
                    jewellery.DesignCode =finalRecords.Rows[i][9].ToString();
                    jewellery.uom = finalRecords.Rows[i][10].ToString();
                    jewellery.GoldWeight = decimal.Parse(finalRecords.Rows[i][11].ToString());
                    jewellery.ConsiderStoneWeight = true;
                    jewellery.CostPrice = decimal.Parse(finalRecords.Rows[i][12].ToString());
                    jewellery.SellingPrice = decimal.Parse(finalRecords.Rows[i][13].ToString());
                    jewellery.MinimumPrice = decimal.Parse(finalRecords.Rows[i][14].ToString());
                    jewellery.StoneWeight = decimal.Parse(finalRecords.Rows[i][15].ToString());
                    jewellery.DiamondWeight = decimal.Parse(finalRecords.Rows[i][16].ToString());
                    jewellery.DiamondClarity = finalRecords.Rows[i][17].ToString();
                    var str = finalRecords.Rows[i][18].ToString();
                    jewellery.CentreStoneWeight = decimal.Parse(finalRecords.Rows[i][18].ToString());
                    jewellery.Margin = decimal.Parse(finalRecords.Rows[i][20].ToString());
                    jewellery.CostCode = finalRecords.Rows[i][21].ToString();
                    jewellery.Material = materialId;
                    jewellery.CreatedUserId = 0;
                    jewellery.Duplicates = true;

                    if (i > 1)
                    {
                        foreach (JewelleryProductVM product in jewelleries)
                        {
                            if (product.ItemCode == jewellery.ItemCode)
                            {
                                ExistInExcelJewellery.Add(jewellery);
                            }
                        }
                    }

                    jewelleries.Add(jewellery);

                    if(count != 0)
                    {
                        existingJewelleries.Add(jewellery);
                    }


                    if (categoryId == 0)
                    {
                        NoCategoryJewellery.Add(jewellery);
                    }

                }

                if(existingJewelleries.Count()== 0)
                {
                    if (NoCategoryJewellery.Count()>0 && autoGenItemCode)
                    {
                        returnJewelleries = NoCategoryJewellery;
                        returnJewelleries.ElementAt(0).Duplicates = false;
                        returnJewelleries.ElementAt(0).NoCategory = true;
                    }
                    else
                    {
                        if (ExistInExcelJewellery.Count() == 0)
                        {
                            for (int i = 0; i < jewelleries.Count(); i++)
                            {
                                JewelleryProductVM jewellery = new JewelleryProductVM();
                                var dynamicParameterlist1 = new DynamicParameters();
                                dynamicParameterlist1.Add("@ItemCode", jewelleries.ElementAt(i).ItemCode);
                                dynamicParameterlist1.Add("@Standard", jewelleries.ElementAt(i).Standard);
                                dynamicParameterlist1.Add("@Category", jewelleries.ElementAt(i).Category);
                                dynamicParameterlist1.Add("@SubCategory", jewelleries.ElementAt(i).SubCategory);
                                dynamicParameterlist1.Add("@Supplier", jewelleries.ElementAt(i).Supplier);
                                dynamicParameterlist1.Add("@Brand", jewelleries.ElementAt(i).Brand);
                                dynamicParameterlist1.Add("@MadeIn", jewelleries.ElementAt(i).MadeIn);
                                dynamicParameterlist1.Add("@Description", jewelleries.ElementAt(i).Description);
                                dynamicParameterlist1.Add("@BillDescription", jewelleries.ElementAt(i).BillDescription);

                                dynamicParameterlist1.Add("@Section", jewelleries.ElementAt(i).Section);
                                dynamicParameterlist1.Add("@Tray", jewelleries.ElementAt(i).Tray);

                                dynamicParameterlist1.Add("@DesignCode", jewelleries.ElementAt(i).DesignCode);
                                dynamicParameterlist1.Add("@UOM", jewelleries.ElementAt(i).uom);
                                dynamicParameterlist1.Add("@GoldWeight", jewelleries.ElementAt(i).GoldWeight);
                                dynamicParameterlist1.Add("@ConsiderStoneWeight", jewelleries.ElementAt(i).ConsiderStoneWeight);
                                dynamicParameterlist1.Add("@CostPrice", jewelleries.ElementAt(i).CostPrice);
                                dynamicParameterlist1.Add("@SellingPrice", jewelleries.ElementAt(i).SellingPrice);
                                dynamicParameterlist1.Add("@MinimumPrice", jewelleries.ElementAt(i).MinimumPrice);
                                dynamicParameterlist1.Add("@StoneWeight", jewelleries.ElementAt(i).StoneWeight);
                                dynamicParameterlist1.Add("@DiamondWeight", jewelleries.ElementAt(i).DiamondWeight);
                                dynamicParameterlist1.Add("@DiamondClarity", jewelleries.ElementAt(i).DiamondClarity);
                                dynamicParameterlist1.Add("@Material", jewelleries.ElementAt(i).Material);
                                dynamicParameterlist1.Add("@CentreStoneWeight", jewelleries.ElementAt(i).CentreStoneWeight);
                                dynamicParameterlist1.Add("@CreatedUserId", jewelleries.ElementAt(i).CreatedUserId);
                                dynamicParameterlist1.Add("@CostCode", jewelleries.ElementAt(i).CostCode);
                                dynamicParameterlist1.Add("@AutoGenItemCode", autoGenItemCode);
                                dynamicParameterlist1.Add("@Margin", jewelleries.ElementAt(i).Margin);

                                jewellery = await dbConnection.QuerySingleOrDefaultAsync<JewelleryProductVM>("[msd].[AddJewelleryProduct]", dynamicParameterlist1, _transaction, commandType: CommandType.StoredProcedure);

                                NewJewelleries.Add(jewellery);
                            }
                            returnJewelleries = NewJewelleries;
                            returnJewelleries.ElementAt(0).Duplicates = false;
                            returnJewelleries.ElementAt(0).NoCategory = false;
                            returnJewelleries.ElementAt(0).ExistInExcel = false;
                        }
                        else
                        {
                            returnJewelleries = ExistInExcelJewellery;
                            returnJewelleries.ElementAt(0).Duplicates = false;
                            returnJewelleries.ElementAt(0).NoCategory = false;
                            returnJewelleries.ElementAt(0).ExistInExcel = true;
                        }
                    }
                }
                else
                {
                    returnJewelleries = existingJewelleries;
                    returnJewelleries.ElementAt(0).Duplicates = true;
                    returnJewelleries.ElementAt(0).NoCategory = false;
                    returnJewelleries.ElementAt(0).ExistInExcel = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return returnJewelleries;
        }

        public async Task<IEnumerable<JewelleryProductVM>> ImportProductExcelBarCode(IFormFile file)
        {

            List<JewelleryProductVM> jewelleries = new List<JewelleryProductVM>();
            List<JewelleryProductVM> existingJewelleries = new List<JewelleryProductVM>();
            List<JewelleryProductVM> returnJewelleries = new List<JewelleryProductVM>();
            List<JewelleryProductVM> NewJewelleries = new List<JewelleryProductVM>();
            List<JewelleryProductVM> NoCategoryJewellery = new List<JewelleryProductVM>();
            List<JewelleryProductVM> ExistInExcelJewellery = new List<JewelleryProductVM>();

            try
            {
                Stream stream = file.OpenReadStream();
                IExcelDataReader reader = null;

                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                DataSet excelRecords = reader.AsDataSet();
                reader.Close();
                var finalRecords = excelRecords.Tables[0];
                for (int i = 1; i < finalRecords.Rows.Count; i++)
                {

                    JewelleryProductVM jewellery = new JewelleryProductVM();
                    var dynamicParameterlist = new DynamicParameters();
                    int count = 0;

                    dynamicParameterlist.Add("@ItemCode", finalRecords.Rows[i][0].ToString());
                    count = await dbConnection.QuerySingleOrDefaultAsync<int>("[msd].[SearchDuplicateItemCode]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

                    jewellery.ItemCode = finalRecords.Rows[i][0].ToString();
                    jewellery.Duplicates = true;

 

                    if (count > 0)
                    {
                        JewelleryProductVM jewellery1 = new JewelleryProductVM();
                        jewellery1 = await dbConnection.QuerySingleOrDefaultAsync<JewelleryProductVM>("msd.GetJewelleryProductDetailsByItemCode", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
                        jewellery = jewellery1;
                        jewelleries.Add(jewellery);
                    }
                    else
                    {
                        ExistInExcelJewellery.Add(jewellery); //if does not exist
                    }
                 }

                if(ExistInExcelJewellery.Count() > 0)
                {
                    returnJewelleries = ExistInExcelJewellery;
                    returnJewelleries.ElementAt(0).ExistInExcel = true;
                }
                else
                {
                    returnJewelleries = jewelleries;
                    returnJewelleries.ElementAt(0).ExistInExcel = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return returnJewelleries;
        }

        public async Task<IEnumerable<JewelleryProductVM>> JewelleryProductTransfer()
        {
            IEnumerable<JewelleryProductVM> jewelleryProductVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                jewelleryProductVM = await dbConnection.QueryAsync<JewelleryProductVM>("msd.JewelleryProductTransfer", dynamicParameterlist,_transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return jewelleryProductVM;
        }

        public async Task<IEnumerable<JewelleryProductVM>> SearchJewelleryProductDetails(string itemCode, string description, int pageId)
        {
            IEnumerable<JewelleryProductVM> jewelleryProductVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@ItemCode", itemCode);
                dynamicParameterlist.Add("@Description", description);
                dynamicParameterlist.Add("@PageId", pageId);

                jewelleryProductVM = await dbConnection.QueryAsync<JewelleryProductVM>("[msd].[SearchJewelleryProductDetails]", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return jewelleryProductVM;
        }

        public async Task<IEnumerable<JewelleryProductVM>> SearchJewelleryProductDetailsByItemCode(string itemCode, int pageId)
        {
            IEnumerable<JewelleryProductVM> jewelleryProductVM;

            try
            {
              var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@ItemCode", itemCode);
                dynamicParameterlist.Add("@PageId", pageId);
                jewelleryProductVM = await dbConnection.QueryAsync<JewelleryProductVM>("[msd].[SearchJewelleryProductDetailsByItemCode]", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return jewelleryProductVM;
        }

        public async Task<IEnumerable<JewelleryProductVM>> SearchJewelleryProductDetailsByItemCode_All(string itemCode, int pageId)
        {
            IEnumerable<JewelleryProductVM> jewelleryProductVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@ItemCode", itemCode);
                dynamicParameterlist.Add("@PageId", pageId);
                jewelleryProductVM = await dbConnection.QueryAsync<JewelleryProductVM>("[msd].[SearchJewelleryProductDetailsByItemCode_All]", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return jewelleryProductVM;
        }

        public async Task<GoldRateVM> UpdateGoldRateDetail(GoldRateVM goldRateVM)
        {
            GoldRateVM goldRateVm = new GoldRateVM();

            try
            {
                var dynamicParamterlist = new DynamicParameters();
                dynamicParamterlist.Add("@Id", goldRateVM.Id);
                dynamicParamterlist.Add("@Rate", goldRateVM.Rate);

                goldRateVm = await dbConnection.QuerySingleOrDefaultAsync<GoldRateVM>("[msd].[UpdateGoldRateDetail]", dynamicParamterlist,_transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return goldRateVm;
        }

        public async Task<JewelleryProductVM> UpdateJewelleryImage(int Id,Boolean Add)
        {
            JewelleryProductVM jewelleryProductVM = new JewelleryProductVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
               
                dynamicParameterlist.Add("@Id", Id);
                dynamicParameterlist.Add("@Add", Add);
                jewelleryProductVM = await dbConnection.QuerySingleOrDefaultAsync<JewelleryProductVM>("msd.UpdateJewelleryImage", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return jewelleryProductVM;
        }

        public async Task<JewelleryProductVM> UpdateJewelleryProductDetails(JewelleryProductVM jewelleryProductVM)
        {
            JewelleryProductVM jewelleryProductVm = new JewelleryProductVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", jewelleryProductVM.Id);
                dynamicParameterlist.Add("@Standard", jewelleryProductVM.Standard);
                dynamicParameterlist.Add("@Category", jewelleryProductVM.Category);
                dynamicParameterlist.Add("@SubCategory", jewelleryProductVM.SubCategory);
                dynamicParameterlist.Add("@Supplier", jewelleryProductVM.Supplier);
                dynamicParameterlist.Add("@Brand", jewelleryProductVM.Brand);
                dynamicParameterlist.Add("@ItemCode", jewelleryProductVM.ItemCode);
                dynamicParameterlist.Add("@MadeIn", jewelleryProductVM.MadeIn);
                dynamicParameterlist.Add("@Description", jewelleryProductVM.Description);
                dynamicParameterlist.Add("@Section", jewelleryProductVM.Section);
                dynamicParameterlist.Add("@Tray", jewelleryProductVM.Tray);
                dynamicParameterlist.Add("@BillDescription", jewelleryProductVM.BillDescription);
                dynamicParameterlist.Add("@DesignCode", jewelleryProductVM.DesignCode);
                dynamicParameterlist.Add("@UOM", jewelleryProductVM.uom);
                dynamicParameterlist.Add("@GoldWeight", jewelleryProductVM.GoldWeight);
                dynamicParameterlist.Add("@Material", jewelleryProductVM.Material);
                dynamicParameterlist.Add("@ConsiderStoneWeight", jewelleryProductVM.ConsiderStoneWeight);
                dynamicParameterlist.Add("@CostPrice", jewelleryProductVM.CostPrice);
                dynamicParameterlist.Add("@SellingPrice", jewelleryProductVM.SellingPrice);
                dynamicParameterlist.Add("@MinimumPrice", jewelleryProductVM.MinimumPrice);
                dynamicParameterlist.Add("@StoneWeight", jewelleryProductVM.StoneWeight);
                dynamicParameterlist.Add("@DiamondWeight", jewelleryProductVM.DiamondWeight);
                dynamicParameterlist.Add("@CentreStoneWeight", jewelleryProductVM.CentreStoneWeight);
                dynamicParameterlist.Add("@DiamondClarity", jewelleryProductVM.DiamondClarity);
                dynamicParameterlist.Add("@LastCreatedUserId", jewelleryProductVM.LastModifiedUserId);
                dynamicParameterlist.Add("@Margin", jewelleryProductVM.Margin);
                jewelleryProductVM = await dbConnection.QuerySingleOrDefaultAsync<JewelleryProductVM>("msd.UpdateJewelleryProductDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return jewelleryProductVM;
        }

        public async  Task<TraySlotVM> UpdateTraySlotDetails(int trayId, int sectionId, int productId, int traySlot)
        {
            TraySlotVM traySlotVM = new TraySlotVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@ProductId",productId);
                dynamicParameterlist.Add("@SectionId",sectionId);
                dynamicParameterlist.Add("@TrayId",trayId);
                dynamicParameterlist.Add("@TraySlot",traySlot);
                traySlotVM = await dbConnection.QuerySingleOrDefaultAsync<TraySlotVM>("[msd].[UpdateTraySlotDetails]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return traySlotVM;
        }
    }
}


 
 
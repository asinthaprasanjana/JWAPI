using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
    public interface IProductSettingServices
    {
        Task<CommonAttributesVM> AddCommonAttribute(CommonAttributesVM commonAttributes);
        Task<IEnumerable<CommonAttributesVM>> GetCommonAttributes(int filter);
        Task<IEnumerable<CommonAttributesValuesVM>> GetCommonAttributeData(int attributeId);
        Task<CommonAttributesVM> UpdateCommonAttributes(CommonAttributesVM commonAttribute);
        Task<IEnumerable<ProductLevelVM>> AddProductLevel(IEnumerable<ProductLevelVM> ProductLevelVM);

        Task<IEnumerable<ProductLevelVM>> GetProductLevelDetails(ProductLevelVM ProductLevelVM);
        Task<ProductLevelSummeryVM> GetProductLevelSummeryDetailsDetails(int companyId);
        Task<CommonGroupsVM> AddCommonGroup(CommonGroupsVM commonGroup);
        Task<IEnumerable<CommonGroupsVM>> GetCommonGroups();
        Task<IEnumerable<CommonAttributesVM>> GetCommonAttributeById(CommonGroupsVM group);

        Task<CommonGroupsVM> UpdateCommonGroup(CommonGroupsVM group);


        Task<IEnumerable<IndustryVM>> GetAllIndustries();
        Task<IEnumerable<IndustryLevelVM>> GetIndustryProductLevel(int parentId, int level);
        Task<IndustryLevelVM> UpdateIndustryProductLevel(IndustryLevelVM Industry);
        Task<IndustryLevelVM> AddIndustryProductLevel(IndustryLevelVM Industry);




    }
}

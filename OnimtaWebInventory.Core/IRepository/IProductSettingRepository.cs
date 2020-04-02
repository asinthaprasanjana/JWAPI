using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface IProductSettingRepository
    {
        Task<CommonAttributesVM> AddcommonAttribute(CommonAttributesVM commonAttributes);
        Task<IEnumerable<CommonAttributesVM>> GetCommonAttributeDetails(int filter);
        Task<IEnumerable<CommonAttributesValuesVM>> GetCommonAttributeData(int attributeId);
        Task<CommonAttributesVM> UpdateCommonAttribute(CommonAttributesVM commonAttributes);
        Task<ProductLevelVM> AddProductLevel(ProductLevelVM ProductLevelVM);
        Task<IEnumerable<ProductLevelVM>> GetProductLevelDetails(ProductLevelVM ProductLevelVM);
        Task<CommonGroupsVM> AddCommonGroup(CommonGroupsVM commonGroup);
        Task<IEnumerable<CommonGroupsVM>> GetCommonGroups();
        Task<CommonAttributesVM> GetCommonAttributeById(int id);
        Task<CommonGroupsVM> UpdateCommonGroup(CommonGroupsVM group);
        Task<IEnumerable<IndustryVM>> GetAllIndustries();
        Task<IEnumerable<IndustryLevelVM>> GetIndustryProductLevel(int parentId,int level);
        Task<IndustryLevelVM> UpdateIndustryProductLevel(IndustryLevelVM Industry);
        Task<IndustryLevelVM> AddIndustryProductLevel(IndustryLevelVM Industry);


    }
}

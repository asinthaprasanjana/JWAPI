using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
   public interface IIndustryAttributeRepository
    {
        Task<IndustryVM> AddIndustryAttributeDetails(IndustryVM industryVM);
        Task<IndustryVM> UpdateIndustryAttributeDetails(IndustryVM industryVM);
        Task<IEnumerable<IndustryVM>> GetAllIndustryAttributeDetails();
        Task<IEnumerable<IndustryNameVM>> GetIndustryName();

    }
}

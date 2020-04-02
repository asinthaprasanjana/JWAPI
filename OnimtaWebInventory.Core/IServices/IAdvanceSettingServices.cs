using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
    public interface IAdvanceSettingServices
    {
        Task<AdvanceSettingVM> UpdateAdvaneSettingDetails(AdvanceSettingVM advanceSettingVM);
        Task<IEnumerable<AdvanceSettingVM>> GetAllAdvaneSettingDetails();
        Task<AdvanceSettingVM> AddAdvaneSettingDetails(AdvanceSettingVM advanceSettingVM);

    }
}

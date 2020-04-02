using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
    public interface IPageSettingServices
    {
        Task<ApplicationPageVM> AddNewApplicationPagesAsync(ApplicationPageVM applicationPageVM);
        Task<ApplicationPageVM> UpdateSelectedPage(ApplicationPageVM applicationPageVM);

    }
}

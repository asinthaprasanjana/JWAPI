using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
  public  interface ISeasonServices
    {
        Task<SeasonVM> AddNewSeasonDetails(SeasonVM seasonVM);
        Task<SeasonVM> UpdateSeasonDetails(SeasonVM seasonVM);
        Task<IEnumerable<SeasonVM>> GetAllSeasonDetailsById(int id);
    }
}

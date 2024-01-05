using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoSystem.Shared;

namespace CasinoSystem.Services.Interfaces
{
    public interface IBonusService
    {
        BonusModel Get(int id);
        IQueryable<BonusModel> GetAll();
        Task AddAsync(BonusCreateModel user);
        Task<BonusModel> GetAsync(int id);
        Task RemoveAsync(int id);
        Task<bool> UpdateAsync(BonusModel user);
       
    }
}

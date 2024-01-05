using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasinoSystem.Data.Entities;
using CasinoSystem.Data.Repository.Interfaces;
using CasinoSystem.Services.Interfaces;
using CasinoSystem.Shared;

namespace CasinoSystem.Services.Services
{
    public class BonusService : IBonusService
    {
        private readonly IGenericRepository<Bonus> _genericRepository;
        private readonly IMapper _mapper;
        public BonusService(IGenericRepository<Bonus> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(BonusCreateModel model)
        {
            var data = _mapper.Map<Bonus>(model);
            await _genericRepository.InsertAsync(data);
            await _genericRepository.SaveAsync();
        }

        public BonusModel Get(int id)
        {
            var model = _genericRepository.GetById(id);
            if (model == null)
            {
                return null;
            }

            var data = _mapper.Map<BonusModel>(model);
            return data;
        }

        public IQueryable<BonusModel> GetAll()
        {
            var bonuses = _genericRepository.GetAll();

            if (bonuses == null)
                return null;

            var data = _mapper.Map<IQueryable<BonusModel>>(bonuses);

            return data;
        }
        public async Task<BonusModel> GetAsync(int id)
        {
            var model = await _genericRepository.GetByIdAsync(id);
            if (model == null)
            {
                return null;
            }

            var data = _mapper.Map<BonusModel>(model);
            return data;
        }

        public async Task RemoveAsync(int id)
        {
            await _genericRepository.DeleteAsync(id); ;
            await _genericRepository.SaveAsync();
        }

        public async Task<bool> UpdateAsync(BonusModel model)
        {
            var entity = await _genericRepository.GetByIdAsync(model.Id);

            if (entity == null)
                return false;

            entity.Name = model.Name;
            entity.Condition= model.Condition;
            entity.Amount = model.Amount;
            await _genericRepository.UpdateAsync(entity);
            await _genericRepository.SaveAsync();
            return true;
        }
    }
}

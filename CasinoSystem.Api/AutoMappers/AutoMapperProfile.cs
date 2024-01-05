using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasinoSystem.Data.Entities;
using CasinoSystem.Shared.Enums;
using CasinoSystem.Shared.Models;

namespace CasinoSystem.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserCreateModel, ApplicationUser>().ReverseMap();
            CreateMap<UserModel, ApplicationUser>().ReverseMap();

            CreateMap<BonusCreateModel, Bonus>().ReverseMap();
            CreateMap<BonusModel, Bonus>().ReverseMap();
            CreateMap<CreateRoleModel, Role>().ReverseMap();
        }
    }
}

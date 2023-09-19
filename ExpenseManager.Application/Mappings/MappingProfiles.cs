using AutoMapper;
using ExpenseManager.Application.Commands.CreateTransfer;
using ExpenseManager.Application.DTOS;
using ExpenseManager.Domain.Entities;
using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Application.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Setting, SettingDto>();
            CreateMap<SettingDto, Setting>();
            CreateMap<SavingGoal, SavingGoalDto>();
            CreateMap<SavingGoalDto, SavingGoal>();
            CreateMap<Stat, StatDto>();

            CreateMap<Transfer, TransferDto>()
                .ForMember(t => t.Category, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<Category, CategoryDto>();

            CreateMap<CreateTransferCommand, Transfer>();
            CreateMap<CategoryDto, Category>();
        }
    }
}

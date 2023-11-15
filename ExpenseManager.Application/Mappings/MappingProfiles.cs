using AutoMapper;
using ExpenseManager.Application.Commands.CreateCategory;
using ExpenseManager.Application.Commands.CreateTransfer;
using ExpenseManager.Application.Commands.EditCategory;
using ExpenseManager.Application.Commands.EditTransfer;
using ExpenseManager.Application.DTOS;
using ExpenseManager.Domain.Entities;
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
            CreateMap<CreateCategoryCommand, Category>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)); 

            CreateMap<CategoryDto, EditCategoryCommand>();
            CreateMap<TransferDto, EditTransferCommand>();

        }
    }
}

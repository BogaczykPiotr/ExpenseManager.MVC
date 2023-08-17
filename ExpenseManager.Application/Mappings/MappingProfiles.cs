using AutoMapper;
using ExpenseManager.Application.Commands.CreateTransfer;
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
            CreateMap<Transfer, TransferDto>();
            CreateMap<TransferDto, Transfer>();

        }
    }
}

using AutoMapper;
using ExpenseManager.Application.Commands.CreateCategory;
using ExpenseManager.Application.Commands.CreateTransfer;
using ExpenseManager.Application.Commands.EditCategory;
using ExpenseManager.Application.Commands.EditTransfer;
using ExpenseManager.Application.Commands.EditUser;
using ExpenseManager.Application.DTOS;
using ExpenseManager.Application.UserService;
using ExpenseManager.Domain.Entities;

namespace ExpenseManager.Application.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();


            CreateMap<Setting, SettingDto>();
            CreateMap<SettingDto, Setting>();
            CreateMap<SavingGoal, SavingGoalDto>();
            CreateMap<SavingGoalDto, SavingGoal>();
            CreateMap<Stat, StatDto>();
            CreateMap<Category, CategoryDto>();

            CreateMap<Transfer, TransferDto>()
                .ForMember(t => t.Category, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<ApplicationUser, UserDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.PhoneNumberConfirmed, opt => opt.MapFrom(src => src.PhoneNumberConfirmed))
            .ForMember(dest => dest.TwoFactorEnabled, opt => opt.MapFrom(src => src.TwoFactorEnabled));

            CreateMap<CreateTransferCommand, Transfer>();
            CreateMap<CreateCategoryCommand, Category>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<CategoryDto, EditCategoryCommand>();
            CreateMap<TransferDto, EditTransferCommand>();
            CreateMap<UserDto, EditUserCommand>();

        }
    }
}

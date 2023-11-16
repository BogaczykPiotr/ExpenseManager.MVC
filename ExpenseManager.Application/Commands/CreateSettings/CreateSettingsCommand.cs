using ExpenseManager.Application.DTOS;
using MediatR;

namespace ExpenseManager.Application.Commands.CreateSettings
{
    public class CreateSettingsCommand : SettingDto, IRequest
    {
    }
}

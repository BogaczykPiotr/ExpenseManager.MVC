using ExpenseManager.Application.DTOS;
using MediatR;

namespace ExpenseManager.Application.Queries.GetSettingValues
{
    public class GetSettingValuesQuery : IRequest<SettingDto>
    {
    }
}

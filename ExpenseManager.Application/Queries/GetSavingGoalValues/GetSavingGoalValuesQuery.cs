using ExpenseManager.Application.DTOS;
using MediatR;

namespace ExpenseManager.Application.Queries.GetSavingGoalValues
{
    public class GetSavingGoalValuesQuery : IRequest<IEnumerable<SavingGoalDto>>
    {
    }
}
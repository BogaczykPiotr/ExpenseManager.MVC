using ExpenseManager.Application.DTOS;
using MediatR;

namespace ExpenseManager.Application.Commands.CreateSavingGoal
{
    public class CreateSavingGoalCommand : SavingGoalDto, IRequest
    {
    }
}

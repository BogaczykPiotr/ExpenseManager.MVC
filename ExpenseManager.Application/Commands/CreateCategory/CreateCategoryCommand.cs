using ExpenseManager.Application.DTOS;
using MediatR;

namespace ExpenseManager.Application.Commands.CreateCategory
{
    public class CreateCategoryCommand : CategoryDto, IRequest
    {
    }
}

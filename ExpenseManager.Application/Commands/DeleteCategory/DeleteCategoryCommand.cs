using ExpenseManager.Application.DTOS;
using MediatR;

namespace ExpenseManager.Application.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : CategoryDto, IRequest
    {
    }
}

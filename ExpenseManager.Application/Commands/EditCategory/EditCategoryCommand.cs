using ExpenseManager.Application.DTOS;
using MediatR;

namespace ExpenseManager.Application.Commands.EditCategory
{
    public class EditCategoryCommand : CategoryDto, IRequest
    {
    }
}

using ExpenseManager.Application.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Application.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : CategoryDto, IRequest
    {
    }
}

using ExpenseManager.Application.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Application.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<CategoryDto>
    {
        public int Id { get; set; }
        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}

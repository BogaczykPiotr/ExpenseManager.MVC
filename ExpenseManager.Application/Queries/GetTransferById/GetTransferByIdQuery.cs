using ExpenseManager.Application.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Application.Queries.GetCategoryByName
{
    public class GetTransferByIdQuery : IRequest<TransferDto>
    {
        public string Id { get; set; }
        public GetTransferByIdQuery(string id)
        {
            Id = id;
        }
    }
}

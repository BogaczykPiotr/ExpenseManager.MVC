using ExpenseManager.Application.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Application.Queries.GetTransferById
{
    public class GetTransferByIdQuery : IRequest<TransferDto>
    {
        public int Id { get; set; }
        public GetTransferByIdQuery(int id)
        {
            Id = id;
        }
    }
}

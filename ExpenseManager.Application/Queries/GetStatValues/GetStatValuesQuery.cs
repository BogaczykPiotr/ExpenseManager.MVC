using ExpenseManager.Application.DTOS;
using ExpenseManager.Domain.Interfaces;
using MediatR;

namespace ExpenseManager.Application.Queries.GetStatValues
{
    public class GetStatValuesQuery : IRequest<StatDto>
    {
    }
}


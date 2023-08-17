using ExpenseManager.Application.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Application.Queries.GetSettingValues
{
    public class GetSettingValuesQuery : IRequest<SettingDto>
    {
    }
}

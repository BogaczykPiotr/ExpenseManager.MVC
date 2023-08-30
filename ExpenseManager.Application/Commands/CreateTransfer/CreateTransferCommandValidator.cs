using ExpenseManager.Application.DTOS;
using ExpenseManager.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Application.Commands.CreateTransfer
{
    public class CreateTransferCommandValidator : AbstractValidator<TransferDto>
    {
        public CreateTransferCommandValidator(IExpenseManagerRepository repository)
        {
            RuleFor(t => t.Value)
                .NotEmpty();

            RuleFor(t => t.Description)
                .MinimumLength(2).WithMessage("Details should have at least 2 characters");
        }
    }
}

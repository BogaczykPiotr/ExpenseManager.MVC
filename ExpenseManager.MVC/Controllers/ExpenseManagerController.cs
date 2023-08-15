using ExpenseManager.Application.Commands.CreateSavingGoal;
using ExpenseManager.Application.Commands.CreateTransfer;
using ExpenseManager.Application.DTOS;
using ExpenseManager.Application.Queries.GetAllTransfers;
using ExpenseManager.Application.Queries.GetSavingGoalValues;
using ExpenseManager.Application.Queries.GetStatValues;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.MVC.Controllers
{
    public class ExpenseManagerController : Controller
    {
        private readonly IMediator _mediator;
        public ExpenseManagerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Dashboard()
        {
            var stats = await _mediator.Send(new GetStatValuesQuery());

            return View(stats);
        }

        public async Task<IActionResult> Transfers()
        {
            var Transfers = await _mediator.Send(new GetAllTransfersQuery());
            return View(Transfers);
        }



        public async Task<IActionResult> Savings()
        {
            var viewModel = new SavingViewModel();
            viewModel.SavingGoalDtos = await _mediator.Send(new GetSavingGoalValuesQuery());

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Savings(CreateSavingGoalCommand command)
        {
            await _mediator.Send(command);
            var viewModel = new SavingViewModel();
            viewModel.CreateSavingGoalCommand = command;
            viewModel.SavingGoalDtos = await _mediator.Send(new GetSavingGoalValuesQuery());

            return View(viewModel);
        }



        public IActionResult Create()
        {
            return View();
        }





        [HttpPost]
        public async Task<IActionResult> Create(CreateTransferCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction(nameof(Transfers));

        }


        public IActionResult Settings()
        {
            return View(); //TODO
        }









    }







    public class SavingViewModel
    {
        public CreateSavingGoalCommand CreateSavingGoalCommand { get; set; }
        public IEnumerable<SavingGoalDto> SavingGoalDtos { get; set; }
    }
}
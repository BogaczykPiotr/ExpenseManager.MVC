using ExpenseManager.Application.Commands.CreateSavingGoal;
using ExpenseManager.Application.Commands.CreateSettings;
using ExpenseManager.Application.Commands.CreateTransfer;
using ExpenseManager.Application.DTOS;
using ExpenseManager.Application.Queries.GetAllTransfers;
using ExpenseManager.Application.Queries.GetSavingGoalValues;
using ExpenseManager.Application.Queries.GetSettingValues;
using ExpenseManager.Application.Queries.GetStatValues;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

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



        public async Task<IActionResult> Create()
        {
            var viewModel = new CreateViewModel();
            viewModel.TransferDto = await _mediator.Send(new GetAllTransfersQuery());
            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateTransferCommand command)
        {
            if(!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            var viewModel = new CreateViewModel();
            viewModel.CreateTransferCommand = command;
            viewModel.TransferDto = await _mediator.Send(new GetAllTransfersQuery());
            return RedirectToAction(nameof(Transfers));

        }

        public IActionResult Actions()
        {
            return View();
        }



        public async Task<IActionResult> Settings()
        {
            var viewModel = new SettingViewModel();
            viewModel.SettingsDto = await _mediator.Send(new GetSettingValuesQuery());
            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Settings(CreateSettingsCommand command)
        {
            var currentSettings = await _mediator.Send(new GetSettingValuesQuery());


            

            if (string.IsNullOrEmpty(command.Currency))
                command.Currency = currentSettings.Currency;

            if (string.IsNullOrEmpty(command.Language))
                command.Language = currentSettings.Language;

            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
            }


            var viewModel = new SettingViewModel();
            viewModel.CreateSavingGoalCommand = command;
            viewModel.SettingsDto = currentSettings;
            return RedirectToAction(nameof(Settings));

        }




    }






    public class CreateViewModel
    {
        public CreateTransferCommand CreateTransferCommand { get; set; }
        public IEnumerable<TransferDto> TransferDto { get; set; }
    }
    public class SavingViewModel
    {
        public CreateSavingGoalCommand CreateSavingGoalCommand { get; set; }
        public IEnumerable<SavingGoalDto> SavingGoalDtos { get; set; }
    }
    
    public class SettingViewModel
    {
        public CreateSettingsCommand CreateSavingGoalCommand { get; set; }
        public SettingDto SettingsDto { get; set; }
    }
    
}
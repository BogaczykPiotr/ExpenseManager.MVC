using ExpenseManager.Application.Commands.CreateSettings;
using ExpenseManager.Application.Queries.GetAllTransfers;
using ExpenseManager.Application.Queries.GetSettingValues;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.MVC.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly IMediator _mediator;
        public SettingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            await ViewLayoutData();
            var viewModel = new SettingViewModel();
            viewModel.SettingsDto = await _mediator.Send(new GetSettingValuesQuery());
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateSettingsCommand command)
        {
            var currentSettings = await _mediator.Send(new GetSettingValuesQuery());




            if (string.IsNullOrEmpty(command.Currency))
                command.Currency = currentSettings.Currency;

            if (string.IsNullOrEmpty(command.Language))
                command.Language = currentSettings.Language;

            if (command.NumberOfDisplayedActions == null)
            {
                command.NumberOfDisplayedActions = currentSettings.NumberOfDisplayedActions;
            }

            await _mediator.Send(command);


            var viewModel = new SettingViewModel();
            viewModel.CreateSavingGoalCommand = command;
            viewModel.SettingsDto = currentSettings;
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Profile()
        {
            ViewLayoutData();
            return View();
        }


        protected async Task ViewLayoutData()
        {
            ViewData["TransferDtos"] = await _mediator.Send(new GetAllTransfersQuery());
            ViewData["SettingsDto"] = await _mediator.Send(new GetSettingValuesQuery());
        }
    }
}

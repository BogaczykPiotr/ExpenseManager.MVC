using ExpenseManager.Application.Commands.CreateCategory;
using ExpenseManager.Application.Commands.CreateSavingGoal;
using ExpenseManager.Application.Commands.CreateSettings;
using ExpenseManager.Application.Commands.CreateTransfer;
using ExpenseManager.Application.DTOS;
using ExpenseManager.Application.Queries.GetAllTransfers;
using ExpenseManager.Application.Queries.GetCategories;
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
            await ViewLayoutData();
            var stats = await _mediator.Send(new GetStatValuesQuery());
            return View(stats);
        }

        public async Task<IActionResult> Transfers()
        {
            await ViewLayoutData();
            var Transfers = await _mediator.Send(new GetAllTransfersQuery());
            return View(Transfers);
        }



        public async Task<IActionResult> Savings()
        {
            await ViewLayoutData();
            var stats = await _mediator.Send(new GetStatValuesQuery());

            var viewModel = new SavingViewModel();
            viewModel.SavingGoalDtos = await _mediator.Send(new GetSavingGoalValuesQuery());

            ViewBag.Stats = stats;

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Savings(CreateSavingGoalCommand command)
        {
            await _mediator.Send(command);
            var viewModel = new SavingViewModel()
            {
                CreateSavingGoalCommand = command,
                SavingGoalDtos = await _mediator.Send(new GetSavingGoalValuesQuery())
            };
            return View(viewModel);
        }



        public async Task<IActionResult> Create()
        {
            await ViewLayoutData();
            ViewData["CategoryDtos"] = await _mediator.Send(new GetCategoriesQuery());
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateTransferCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction(nameof(Transfers));

        }

        public async Task<IActionResult> Actions()
        {
            await ViewLayoutData();
            var categories = await _mediator.Send(new GetCategoriesQuery());  // for category table update
            return View(categories);
        }

        public async Task<IActionResult> CreateNewCategory()
        {
            await ViewLayoutData();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewCategory(CreateCategoryCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction();
        }

        public async Task<IActionResult> CreateUpcomingAction()
        {
            await ViewLayoutData();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUpcomingAction(CreateTransferCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction(nameof(Actions));
        }

        public async Task<IActionResult> Settings()
        {
            await ViewLayoutData();
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

            if(command.NumberOfDisplayedActions == null)
            {
                command.NumberOfDisplayedActions = currentSettings.NumberOfDisplayedActions;
            }

            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
            }


            var viewModel = new SettingViewModel();
            viewModel.CreateSavingGoalCommand = command;
            viewModel.SettingsDto = currentSettings;
            return RedirectToAction(nameof(Settings));

        }


        protected async Task ViewLayoutData()
        {
            ViewData["TransferDtos"] = await _mediator.Send(new GetAllTransfersQuery());
            ViewData["SettingsDto"] = await _mediator.Send(new GetSettingValuesQuery());
        }

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
using AutoMapper;
using ExpenseManager.Application.Commands.AddUserInformation;
using ExpenseManager.Application.Commands.CreateCategory;
using ExpenseManager.Application.Commands.CreateSavingGoal;
using ExpenseManager.Application.Commands.CreateSettings;
using ExpenseManager.Application.Commands.CreateTransfer;
using ExpenseManager.Application.Commands.DeleteCategory;
using ExpenseManager.Application.Commands.DeleteTransfer;
using ExpenseManager.Application.Commands.EditCategory;
using ExpenseManager.Application.Commands.EditTransfer;
using ExpenseManager.Application.DTOS;
using ExpenseManager.Application.Queries.GetAllTransfers;
using ExpenseManager.Application.Queries.GetCategories;
using ExpenseManager.Application.Queries.GetCategoryById;
using ExpenseManager.Application.Queries.GetSavingGoalValues;
using ExpenseManager.Application.Queries.GetSettingValues;
using ExpenseManager.Application.Queries.GetStatValues;
using ExpenseManager.Application.Queries.GetTransferById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.MVC.Controllers
{
    public class ExpenseManagerController : Controller
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ExpenseManagerController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Dashboard()
        {
            await ViewLayoutData();
            var stats = await _mediator.Send(new GetStatValuesQuery());
            ViewData["TransferValues"] = await _mediator.Send(new GetAllTransfersQuery());
            ViewData["SavingGoalValues"] = await _mediator.Send(new GetSavingGoalValuesQuery());
            return View(stats);
        }
        [Authorize]
        public async Task<IActionResult> Transfers()
        {
            await ViewLayoutData();
            var Transfers = await _mediator.Send(new GetAllTransfersQuery());
            return View(Transfers);
        }
        [Authorize]
        public async Task<IActionResult> Savings()
        {
            await ViewLayoutData();
            var stats = await _mediator.Send(new GetStatValuesQuery());

            var viewModel = new SavingViewModel();
            viewModel.SavingGoalDtos = await _mediator.Send(new GetSavingGoalValuesQuery());

            ViewBag.Stats = stats;

            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Savings(CreateSavingGoalCommand command)
        {
            await ViewLayoutData();
            await _mediator.Send(command);
            var viewModel = new SavingViewModel()
            {
                CreateSavingGoalCommand = command,
                SavingGoalDtos = await _mediator.Send(new GetSavingGoalValuesQuery())
            };
            return View(viewModel);
        }


        [Authorize]
        public async Task<IActionResult> Create()
        {
            await ViewLayoutData();
            ViewData["CategoryDtos"] = await _mediator.Send(new GetCategoriesQuery());
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateTransferCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction(nameof(Transfers));

        }
        [Authorize]
        public async Task<IActionResult> Actions()
        {
            await ViewLayoutData();
            var categories = await _mediator.Send(new GetCategoriesQuery());  // for category table update
            return View(categories);
        }
        [Authorize]
        [Route("ExpenseManager/{Id}/Details")]
        public async Task<IActionResult> Details(int id)
        {
            await ViewLayoutData();
            var dto = await _mediator.Send(new GetTransferByIdQuery(id));
            return View(dto);
        }
        [Authorize]
        [Route("ExpenseManager/{Id}/EditTransfer")]
        public async Task<IActionResult> EditTransfer(int id)
        {
            await ViewLayoutData();
            var dto = await _mediator.Send(new GetTransferByIdQuery(id));

            EditTransferCommand model = _mapper.Map<EditTransferCommand>(dto);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [Route("ExpenseManager/{Id}/EditTransfer")]
        public async Task<IActionResult> EditTransfer(EditTransferCommand command, int id)
        {
            await ViewLayoutData();

            await _mediator.Send(command);
            return RedirectToAction(nameof(Transfers));

        }
        [Authorize]
        [Route("ExpenseManager/{Id}/EditCategory")]
        public async Task<IActionResult> Edit(int id)
        {
            await ViewLayoutData();
            var dto = await _mediator.Send(new GetCategoryByIdQuery(id));
            EditCategoryCommand model = _mapper.Map<EditCategoryCommand>(dto);

            return View(model);
            
        }
        [Authorize]
        [HttpPost]
        [Route("ExpenseManager/{Id}/EditCategory")]
        public async Task<IActionResult> Edit(EditCategoryCommand command, int id)
        {
            await ViewLayoutData();


            await _mediator.Send(command);
            return RedirectToAction(nameof(Actions));

        }
        [Authorize]
        public async Task<IActionResult> Login()
        {
            await ViewLayoutData();

            return View();
        } // New controller in future
        [Authorize]
        public async Task<IActionResult> CreateNewCategory()
        {
            await ViewLayoutData();
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateNewCategory(CreateCategoryCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction(nameof(Actions));
        }
        [Authorize]
        public async Task<IActionResult> CreateUpcomingAction()
        {
            await ViewLayoutData();
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateUpcomingAction(CreateTransferCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction(nameof(Actions));
        }
        [Authorize]
        [HttpPost]
        [Route("/ExpenseManager/DeleteTransfer/{id}")]
        public async Task<IActionResult> DeleteTransfer(int id)
        {
            await _mediator.Send(new DeleteTransferCommand { Id = id });

            return RedirectToAction(nameof(Transfers));
        }
        [Authorize]
        [HttpPost]
        [Route("/ExpenseManager/DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _mediator.Send(new DeleteCategoryCommand { Id = id });

            return RedirectToAction(nameof(Actions));
        }
        [Authorize]
        public async Task<IActionResult> Settings()
        {
            await ViewLayoutData();
            var viewModel = new SettingViewModel();
            viewModel.SettingsDto = await _mediator.Send(new GetSettingValuesQuery());
            return View(viewModel);
        }

        [Authorize]
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

                await _mediator.Send(command);


            var viewModel = new SettingViewModel();
            viewModel.CreateSavingGoalCommand = command;
            viewModel.SettingsDto = currentSettings;
            return RedirectToAction(nameof(Settings));

        }



        [Authorize]
        public async Task<IActionResult> Contact()
        {
            await ViewLayoutData();
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            await ViewLayoutData();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Profile(AddUserInformationCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction(nameof(Profile));
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
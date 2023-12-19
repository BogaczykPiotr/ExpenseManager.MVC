using AutoMapper;
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
    [Authorize]
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
            await ViewLayoutData();
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
        [Route("ExpenseManager/{Id}/Details")]
        public async Task<IActionResult> Details(int id)
        {
            await ViewLayoutData();
            var dto = await _mediator.Send(new GetTransferByIdQuery(id));
            return View(dto);
        }
        [Route("ExpenseManager/{Id}/EditTransfer")]
        public async Task<IActionResult> EditTransfer(int id)
        {
            await ViewLayoutData();
            var dto = await _mediator.Send(new GetTransferByIdQuery(id));

            EditTransferCommand model = _mapper.Map<EditTransferCommand>(dto);
            return View(model);
        }
        [HttpPost]
        [Route("ExpenseManager/{Id}/EditTransfer")]
        public async Task<IActionResult> EditTransfer(EditTransferCommand command, int id)
        {
            await ViewLayoutData();

            await _mediator.Send(command);
            return RedirectToAction(nameof(Transfers));

        }
        [Route("ExpenseManager/{Id}/EditCategory")]
        public async Task<IActionResult> Edit(int id)
        {
            await ViewLayoutData();
            var dto = await _mediator.Send(new GetCategoryByIdQuery(id));
            EditCategoryCommand model = _mapper.Map<EditCategoryCommand>(dto);

            return View(model);
            
        }
        [HttpPost]
        [Route("ExpenseManager/{Id}/EditCategory")]
        public async Task<IActionResult> Edit(EditCategoryCommand command, int id)
        {
            await ViewLayoutData();


            await _mediator.Send(command);
            return RedirectToAction(nameof(Actions));

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
            return RedirectToAction(nameof(Actions));
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
        [HttpPost]
        [Route("/ExpenseManager/DeleteTransfer/{id}")]
        public async Task<IActionResult> DeleteTransfer(int id)
        {
            await _mediator.Send(new DeleteTransferCommand { Id = id });

            return RedirectToAction(nameof(Transfers));
        }
        [HttpPost]
        [Route("/ExpenseManager/DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _mediator.Send(new DeleteCategoryCommand { Id = id });

            return RedirectToAction(nameof(Actions));
        }
        public async Task<IActionResult> Contact()
        {
            await ViewLayoutData();
            return View();
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
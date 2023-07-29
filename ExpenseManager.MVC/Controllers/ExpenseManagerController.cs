﻿using ExpenseManager.Application.Commands.CreateTransfer;
using ExpenseManager.Application.Queries.GetAllTransfers;
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

        public async Task<IActionResult> Transfers()
        {
            var Transfers = await _mediator.Send(new GetAllTransfersQuery());
            return View(Transfers);
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
    }
}

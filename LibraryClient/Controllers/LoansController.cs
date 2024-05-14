using LibraryClient.Models;
using LibraryClient.Models.ViewModels;
using LibraryClient.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryClient.Controllers;

public class LoansController(ApiService service) : Controller
{
    public async Task<IActionResult> Create(int id)
    {
        var books = await service.GetBooks();
        
        ViewBag.Books = new SelectList(books, "Id", "Title");

        var viewModel = new CreateLoanViewModel
        {
            CustomerId = id,
        };

        return View(viewModel);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateLoanViewModel viewModel)
    {
        if (!ModelState.IsValid) return View(viewModel);

        var success = await service.CreateLoan(viewModel);

        return RedirectToAction("Index", "Customers");
    }

    public async Task<IActionResult> Return(int id)
    {
        var success = await service.ReturnLoan(id);

        return RedirectToAction("Index", "Customers");
    }
}
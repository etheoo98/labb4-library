using LibraryClient.Models;
using LibraryClient.Models.ViewModels;
using LibraryClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryClient.Controllers;

public class CustomersController(ApiService service) : Controller
{
    public async Task<IActionResult> Index()
    {
        var customers = await service.GetAllCustomers();
        
        return View(customers);
    }
    
    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerViewModel viewModel)
    {
        if (!ModelState.IsValid) return View(viewModel);

        // TODO: Handle failed requests
        var success = await service.CreateCustomer(viewModel);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int id)
    {
        var customer = await service.GetCustomerById(id);
        var loans = await service.GetCustomerLoans(id);
    
        var viewModel = new CustomerLoansViewModel 
        {
            Customer = customer,
            Loans = loans
        };
    
        return View(viewModel);
    }
    
    public async Task<IActionResult> Edit(int id)
    {
        var customer = await service.GetCustomerById(id);
        
        var viewModel = new EditCustomerViewModel
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditCustomerViewModel viewModel)
    { 
        if (!ModelState.IsValid) return View(viewModel);
        
        var success = await service.UpdateCustomer(viewModel);
        
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var success = await service.DeleteCustomer(id);
        
        return RedirectToAction("Index");
    }
}
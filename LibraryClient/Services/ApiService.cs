using System.Text;
using LibraryClient.Models;
using System.Text.Json;
using LibraryClient.Models.ViewModels;

namespace LibraryClient.Services;

public class ApiService(IHttpClientFactory clientFactory)
{
    private readonly HttpClient _client = clientFactory.CreateClient("api-client");
    private const string ApiPrefix = "/api/v1";

    // Get all Customers
    public async Task<List<Customer>?> GetAllCustomers()
    {
        try
        {
            var response = await _client.GetAsync($"{ApiPrefix}/customers");

            if (!response.IsSuccessStatusCode) return null; // TODO: Do something when API is down
        
            var jsonString = await response.Content.ReadAsStringAsync();
            var customers = JsonSerializer.Deserialize<List<Customer>>(jsonString);
        
            return customers;
        }
        catch (Exception e)
        {
            return [];
        }
    }
    
    public async Task<Customer?> GetCustomerById(int id)
    {
        try
        {
            var response = await _client.GetAsync($"{ApiPrefix}/customers/{id}");

            if (!response.IsSuccessStatusCode) return null;

            var jsonString = await response.Content.ReadAsStringAsync();
            var customer = JsonSerializer.Deserialize<Customer>(jsonString);

            return customer;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<bool> UpdateCustomer(EditCustomerViewModel viewModel)
    {
        var id = viewModel.Id;
        var json = JsonSerializer.Serialize(viewModel);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PutAsync($"{ApiPrefix}/customers/{id}", content);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteCustomer(int id)
    {
        var response = await _client.DeleteAsync($"{ApiPrefix}/customers/{id}");

        return response.IsSuccessStatusCode;
    }

    public async Task<List<Loan>?> GetCustomerLoans(int id)
    {
        var response = await _client.GetAsync($"{ApiPrefix}/customers/{id}/loans");

        if (!response.IsSuccessStatusCode) return null;

        var jsonString = await response.Content.ReadAsStringAsync();
        var loans = JsonSerializer.Deserialize<List<Loan>>(jsonString);

        return loans;
    }

    public async Task<bool> CreateCustomer(CreateCustomerViewModel viewModel)
    {
        var json = JsonSerializer.Serialize(viewModel);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync($"{ApiPrefix}/customers", content);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> CreateLoan(CreateLoanViewModel viewModel)
    {
        var json = JsonSerializer.Serialize(viewModel);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync($"{ApiPrefix}/customers/loans", content);

        return response.IsSuccessStatusCode;
    }

    public async Task<IEnumerable<Book>?> GetBooks()
    {
        var response = await _client.GetAsync($"{ApiPrefix}/books");

        if (!response.IsSuccessStatusCode) return null;

        var jsonString = await response.Content.ReadAsStringAsync();
        var books = JsonSerializer.Deserialize<IEnumerable<Book>>(jsonString);

        return books;
    }

    public async Task<bool> ReturnLoan(int id)
    {
        var response = await _client.PutAsync($"{ApiPrefix}/loans/{id}/return", null);

        return response.IsSuccessStatusCode;
    }
}
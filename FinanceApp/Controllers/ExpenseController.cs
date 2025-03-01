using FinanceApp.Data;
using FinanceApp.Data.Services;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Controllers;

public class ExpenseController : Controller
{
    private readonly IExpenseService _expenseService;
    public ExpenseController(IExpenseService expenseService)
    {
        _expenseService = expenseService;
    }
    public async Task<IActionResult> Index()
    {
        var expenses = await _expenseService.GetAll();
        return View(expenses);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Expense expense)
    {
        if (!ModelState.IsValid) 
        {
            return View(expense);
        }

        await _expenseService.Add(expense);
        return RedirectToAction("Index");
    }
}

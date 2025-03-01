using FinanceApp.Data;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Controllers;

public class ExpenseController : Controller
{
    private readonly FinanceAppContext _context;
    public ExpenseController(FinanceAppContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        var expenses = await _context.Expenses.ToListAsync();
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

        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
}

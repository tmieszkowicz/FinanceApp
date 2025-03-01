using FinanceApp.Data;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.Controllers;

public class ExpenseController : Controller
{
    private readonly FinanceAppContext _context;
    public ExpenseController(FinanceAppContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var expenses = _context.Expenses.ToList();
        return View(expenses);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Expense expense)
    {
        if (!ModelState.IsValid) 
        {
            return View(expense);
        }

        _context.Expenses.Add(expense);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}

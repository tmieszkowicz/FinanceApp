using FinanceApp.Data;
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
}

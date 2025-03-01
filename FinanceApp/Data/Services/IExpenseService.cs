using FinanceApp.Models;

namespace FinanceApp.Data.Services;

public interface IExpenseService
{
    Task<IEnumerable<Expense>> GetAll();
    Task Add(Expense expense);
}

using Expenses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Data.Repository.IRepository
{
    public interface IExpensesRepository : IRepository<ExpensesModel>
    {
        IEnumerable<ExpensesModel> Search(string searchTerm);
        void Update(ExpensesModel obj);
    }
}

using Expenses.Data.Repostory;
using Expenses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Data.Repository
{
    public interface IExpensesRepository: IRepository<ExpensesModel>
    {
        void Update(ExpensesModel obj);
        void Save();
    }
}

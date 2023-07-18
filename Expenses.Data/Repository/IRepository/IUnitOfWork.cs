using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Data.Repository.IRepository
{
   
    public interface IUnitOfWork
    {
        IExpensesRepository Expenses { get; }
        ICategoryRepository Category { get; }
        void Save();
    }
}

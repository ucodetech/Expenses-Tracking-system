using Expenses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Data.Repository
{
    public class ExpensesRepository :Repository<ExpensesModel>, IExpensesRepository
    {
       private readonly TrackerDbContext _db;
        public ExpensesRepository(TrackerDbContext db) : base(db)
        {
            _db = db;
            
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(ExpensesModel obj)
        {
            _db.expenses.Update(obj);
        }
    }
}

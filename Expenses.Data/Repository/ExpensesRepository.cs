using Expenses.Data.Repository.IRepository;
using Expenses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Data.Repository
{
    public class ExpensesRepository : Repository<ExpensesModel>, IExpensesRepository
    {
        private readonly TrackerDbContext _db;
        public ExpensesRepository(TrackerDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<ExpensesModel> Search(string searchTerm)
        {
            var searchString = _db.Expenses.Where(s=>s.Name.Contains(searchTerm)).ToList();
            return searchString;
        }

        public void Update(ExpensesModel obj)
        {
           _db.Update(obj);
        }
    }
}

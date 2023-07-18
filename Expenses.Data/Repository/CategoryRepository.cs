using Expenses.Data.Repository.IRepository;
using Expenses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly TrackerDbContext _db;
        public CategoryRepository(TrackerDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Category obj)
        {
           _db.Update(obj); 
        }
    }
}

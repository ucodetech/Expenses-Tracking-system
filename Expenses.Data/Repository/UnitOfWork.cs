using Expenses.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TrackerDbContext _db;
        public ITransactionRepository Transaction { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public UnitOfWork(TrackerDbContext db)
        {
            _db = db;
            Transaction = new TransactionRepository(_db);
            Category = new CategoryRepository(_db);
        }

      

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

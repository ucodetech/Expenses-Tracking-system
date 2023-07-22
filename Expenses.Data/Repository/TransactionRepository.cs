using Expenses.Data.Repository.IRepository;
using Expenses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Data.Repository
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        private readonly TrackerDbContext _db;
        public TransactionRepository(TrackerDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Transaction obj)
        {
           _db.Update(obj);
        }
    }
}

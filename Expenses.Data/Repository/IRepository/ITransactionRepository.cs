﻿using Expenses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Data.Repository.IRepository
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        void Update(Transaction obj);
    }
}

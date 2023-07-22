﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Data.Repository.IRepository
{
   
    public interface IUnitOfWork
    {
        ITransactionRepository Transaction { get; }
        ICategoryRepository Category { get; }
        void Save();
    }
}

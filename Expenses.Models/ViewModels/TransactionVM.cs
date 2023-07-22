using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Models.ViewModels
{
    public class TransactionVM
    {
        public Transaction Transaction { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}

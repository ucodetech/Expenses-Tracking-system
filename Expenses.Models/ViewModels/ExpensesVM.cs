using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Models.ViewModels
{
    public class ExpensesVM
    {
        public ExpensesModel ExpensesModel { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}

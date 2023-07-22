
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Expenses.Data;
using Expenses.Data.Repository;
using Expenses.Data.Repository.IRepository;
using Expenses.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EXpenses.Tracker
{
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TrackerDbContext _db;
        public DashboardController(TrackerDbContext db,IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _db = db;
        }
       
        public async Task<IActionResult> Index()
        {
          //last 7 days 
        //   if(InputStartDate != null && InputStartDate != null){
        //         InputStartDate = InputStartDate;
        //         InputEndDate = InputEndDate;

        //         return View(InputStartDate);
        //   }
         
            DateTime StartDate = DateTime.Today.AddDays(-6);
            DateTime EndDate = DateTime.Today;
          
         
         
        // List<Transaction> selectedTransactions = await _unitOfWork.Transaction.Get(u=>u.ExpenseDate >= StartDate && u.ExpenseDate <= EndDate, includeProperties:"Category").ToListAsync();
        List<Transaction> selectedTransactions = await _db.Transactions
                                            .Include(x=>x.Category)
                                            .Where(u=>u.ExpenseDate >= StartDate && u.ExpenseDate <= EndDate )
                                            .ToListAsync();
        var TotalIncome = selectedTransactions.Where(i=>i.Category.Type == "Income")
                                            .Sum(j => j.Amount);
          
            ViewBag.TotalIncome = TotalIncome.ToString("C0");
        //expense
         var TotalExpense = selectedTransactions.Where(i=>i.Category.Type == "Expense")
                                            .Sum(j => j.Amount);
            ViewBag.TotalExpense = TotalExpense.ToString("C0");

            ViewBag.TotalExpense = TotalExpense.ToString("C0");
           //balance
            var Balance = TotalIncome - TotalExpense;
            ViewBag.Balance = Balance.ToString("C0");

    //doughnutchat data
        ViewBag.DoughnutData = selectedTransactions.Where(i=>i.Category.Type == "Expense")
                                            .GroupBy(j=>j.Category.Id)
                                            .Select(k=> new {
                                                cateTitleWithIcon = k.First().Category.Icon+ " " + k.First().Category.Name,
                                                amount = k.Sum(j=>j.Amount),
                                                formattedAmount = k.Sum(j=>j.Amount).ToString("C0"),

                                            })
                                            .OrderByDescending(l=>l.amount)
                                            .ToList();

            //spline chart income vs expense
            // income
            List<SplineChartData> IncomeSummary = selectedTransactions
                                        .Where(i=>i.Category.Type=="Income")
                                        .GroupBy(j => j.ExpenseDate)
                                        .Select(k => new SplineChartData() 
                                        {
                                            day = k.First().ExpenseDate.ToString("dd-MMM"),
                                            income = Convert.ToInt32(k.Sum(l => l.Amount))
                                        })
                                        .ToList();
             // expense
            List<SplineChartData> ExpenseSummary = selectedTransactions
                                        .Where(i=>i.Category.Type=="Expense")
                                        .GroupBy(j => j.ExpenseDate)
                                        .Select(k => new SplineChartData() {
                                            day = k.First().ExpenseDate.ToString("dd-MMM"),
                                            expense = Convert.ToInt32(k.Sum(l => l.Amount))
                                        }).ToList();

            //combine income and expense
           string[] Last7Days = Enumerable.Range(0, 7)
                    .Select(i=> StartDate.AddDays(i).ToString("dd-MM")).ToArray(); 

            ViewBag.SplineChartData = from day in Last7Days
                                     join income in IncomeSummary on day equals income.day into dayIncomeJoined
                                     from income in dayIncomeJoined.DefaultIfEmpty()
                                     join expense in ExpenseSummary on day equals expense.day into expenseJoined
                                     from expense in expenseJoined.DefaultIfEmpty()
                                     select new {
                                        day = day,
                                        income = income == null ? 0 : income.income,
                                        expense = expense == null ? 0 : expense.expense
                                     };

                //recent transaction
            ViewBag.RecentTransactions = await _db.Transactions.Include(i=>i.Category).OrderByDescending(j=>j.ExpenseDate).Take(5).ToListAsync();

             return View();
        }

      
    }

    public class SplineChartData {
        public string day;
        public int income;
        public int expense;
    }
}
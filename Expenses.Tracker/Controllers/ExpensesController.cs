using Expenses.Data.Repository.IRepository;
using Expenses.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Expenses.Tracker.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ExpensesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            // to get all expenses it will be _unitOfWork.expenses.GetAll().ToList();
            // to get 1 expenses it will be _unitOfWork.expenses.Get(u=>u.Id==id).FirstOrDefault();

        }
        public IActionResult Index()
        {
           List<ExpensesModel> expensesObj = _unitOfWork.Expenses.GetAll(includeProperties:"Category").ToList();
            return View(expensesObj);
        }

      
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ExpensesModel> expenseObj = _unitOfWork.Expenses.GetAll(includeProperties:"Category").ToList();
            return Json(new { data = expenseObj });
        }
        #endregion

        public IActionResult Upsert(int? id)
        {
            ExpensesModel expenses = new();
            //get list of category using EF core projections
            IEnumerable<SelectListItem> categoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            if (id == null || id == 0)
            {
                return View(expenses);
            }
            else 
            {
                ExpensesModel expObj = _unitOfWork.Expenses.Get(u => u.Id == id);
                return View(expObj);
            }

        }

        [HttpPost]
        public IActionResult Upsert(ExpensesModel expenses)
        {


            if (expenses.Id == 0)
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Expenses.Add(expenses);
                    _unitOfWork.Save();
                    TempData["success"] = "Expense Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Error processing request check again!";
                    return View(expenses);
                }
            }
            else
            {
                _unitOfWork.Expenses.Update(expenses);
                _unitOfWork.Save();
                TempData["success"] = "Expense Updated Successfully";
                return RedirectToAction("Index");
            }

        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {

            if (id != null || id != 0)
            {
                ExpensesModel expId = _unitOfWork.Expenses.Get(u => u.Id == id);
                if (expId != null)
                {
                    _unitOfWork.Expenses.Remove(expId);
                    _unitOfWork.Save();
                    return Json(new { code = 1, msg = "Expense Deleted Successfully!" });
                }
                else
                {
                    return Json(new { code = 0, error = "Expense Not Found!" });
                }
            }
            return RedirectToAction("Index");

        }
    }
}

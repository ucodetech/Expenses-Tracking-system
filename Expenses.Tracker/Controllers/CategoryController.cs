using Expenses.Data.Repository.IRepository;
using Expenses.Models;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.Tracker.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            //get categories
            List<Category> categoryObj = _unitOfWork.Category.GetAll().ToList();

            return View(categoryObj);
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Category> categoryObj = _unitOfWork.Category.GetAll().ToList();
            return Json(new { data = categoryObj });
        }
        #endregion

        public IActionResult Upsert(int? id)
        {
            Category category = new();
            if (id == null || id == 0)
            {
                return View(category);
            }
            else
            {
                Category catObj = _unitOfWork.Category.Get(u => u.Id == id);
                return View(catObj);
            }
            
        }

        [HttpPost]
        public IActionResult Upsert(Category category)
        {
          
           
            if(category.Id == 0)
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Category.Add(category);
                    _unitOfWork.Save();
                    TempData["success"] = "Category Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
					TempData["error"] = "Error processing request check again!";
					return View(category);
                }
            }
            else
            {
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
       
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {

            if (id != null || id != 0)
            {
                Category catId = _unitOfWork.Category.Get(u => u.Id == id);
                if(catId != null)
                {
                    _unitOfWork.Category.Remove(catId);
                    _unitOfWork.Save();
                    return Json(new { code = 1, msg = "Category Deleted Successfully!" });
                }
                else
                {
                    return Json(new { code = 0, error = "Category Not Found!" }); 
                }
            }
            return RedirectToAction("Index");
           
        }
    }
}

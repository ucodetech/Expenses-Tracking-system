using Expenses.Data.Repository.IRepository;
using Expenses.Models;
using Expenses.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Expenses.Tracker.Controllers
{
    public class TransactionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public TransactionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            // to get all expenses it will be _unitOfWork.expenses.GetAll().ToList();
            // to get 1 expenses it will be _unitOfWork.expenses.Get(u=>u.Id==id).FirstOrDefault();

        }
        public IActionResult Index()
        {
           List<Transaction> transObj = _unitOfWork.Transaction.GetAll(includeProperties:"Category").ToList();
            return View(transObj);
        }

      
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Transaction> tranObj = _unitOfWork.Transaction.GetAll(includeProperties:"Category").ToList();
            return Json(new { data = tranObj });
        }
        #endregion

        public IActionResult Upsert(int? id)
        {
          
            //get list of category using EF core projections
           
           
                TransactionVM transactionVM = new() 
                {
                 CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    }),
                   Transaction = new Transaction()
                };
                 if(id==null || id==0){
                    //add
                       return View(transactionVM);
                 } 
                   else {
                    //update
                        transactionVM.Transaction = _unitOfWork.Transaction.Get(u => u.Id == id);
                        return View(transactionVM);
                    }
                     
                    
           

        }

        [HttpPost]
        public IActionResult Upsert(TransactionVM transactionVM)
        {

             if (ModelState.IsValid)
                {
                    if(transactionVM.Transaction.Id == 0){
                         _unitOfWork.Transaction.Add(transactionVM.Transaction);
                         TempData["success"] = "Transaction Created Successfully";
                    }else{
                        _unitOfWork.Transaction.Update(transactionVM.Transaction);
                        TempData["success"] = "Transaction Updated Successfully";
                    }
                    _unitOfWork.Save();
                    return RedirectToAction("Index");
                }
                else
                {
                    transactionVM.CategoryList = _unitOfWork.Category.GetAll().Select(u=>new SelectListItem{
                        Text = u.Name,
                        Value = u.Id.ToString()
                    });
                    TempData["error"] = "Error processing request check again!";
                    return View(transactionVM);
                }
           
               
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {

            if (id != null || id != 0)
            {
               Transaction expId = _unitOfWork.Transaction.Get(u => u.Id == id);
                if (expId != null)
                {
                    _unitOfWork.Transaction.Remove(expId);
                    _unitOfWork.Save();
                    return Json(new { code = 1, msg = "Transaction Deleted Successfully!" });
                }
                else
                {
                    return Json(new { code = 0, error = "Transaction Not Found!" });
                }
            }
            return RedirectToAction("Index");

        }
    }
}

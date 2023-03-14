using BLL.IRepository;
using DAL.DataModels;
using DAL.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Controllers
{
    public class StudentController : BaseController
    {
        public StudentController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public async Task<IActionResult> Index()
        {
            var viewModelList = (await _unitOfWork.StudentRepo.GetAllAsync(filter: m => m.IsActive == true)).Select(dataModel => new StudentViewModel
            {
                Id = dataModel.Id,
                Name = dataModel.Name,
                NID = dataModel.NID
            });
            return View(viewModelList);
        }

        public async Task<IActionResult> Details(Int64 id)
        {
            try
            {
                var dataModel = (await _unitOfWork.StudentRepo.GetAsync(id));
                if (dataModel != null)
                {
                    var viewModel = new StudentViewModel()
                    {
                        Id = dataModel.Id,
                        Name = dataModel.Name,
                        NID = dataModel.NID,
                    };
                    return View(viewModel);
                }
                else
                {
                    TempData["display_message"] = "Not found.";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception exception)
            {
                TempData["display_message"] = "Server Error.";
                var errorMessage = "";
                while (exception != null)
                {
                    errorMessage = errorMessage + exception.Message + " |";
                    exception = exception.InnerException;
                }
                TempData["hidden_message"] = "Error Message= " + errorMessage;
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _unitOfWork.StudentRepo.IsNIDExistAsync(viewModel))
                    {
                        TempData["display_message"] = "Already exist.";
                        return View(viewModel);
                    }
                    else
                    {
                        var dataModel = new Student();
                        dataModel.Name = viewModel.Name;
                        dataModel.NID = viewModel.NID;

                        await _unitOfWork.StudentRepo.AddAsync(dataModel);
                        await _unitOfWork.SaveAsync();

                        TempData["display_message"] = "Successfully added.";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return View(viewModel);
                }
            }
            catch (Exception exception)
            {
                TempData["display_message"] = "Server Error.";
                var errorMessage = "";
                while (exception != null)
                {
                    errorMessage = errorMessage + exception.Message + " |";
                    exception = exception.InnerException;
                }
                TempData["hidden_message"] = "Error Message= " + errorMessage;
                return View(viewModel);
            }
        }

        public async Task<IActionResult> Edit(Int64 id)
        {
            try
            {
                var dataModel = (await _unitOfWork.StudentRepo.GetAsync(id));
                if (dataModel != null)
                {
                    var viewModel = new StudentViewModel()
                    {
                        Id = dataModel.Id,
                        Name = dataModel.Name,
                        NID = dataModel.NID,
                    };
                    return View(viewModel);
                }
                else
                {
                    TempData["display_message"] = "Not found.";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception exception)
            {
                TempData["display_message"] = "Server Error.";
                var errorMessage = "";
                while (exception != null)
                {
                    errorMessage = errorMessage + exception.Message + " |";
                    exception = exception.InnerException;
                }
                TempData["hidden_message"] = "Error Message= " + errorMessage;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StudentViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid && viewModel.Id != 0)
                {
                    if (await _unitOfWork.StudentRepo.IsNIDExistAsync(viewModel))
                    {
                        TempData["display_message"] = "Already exist.";
                        return View(viewModel);
                    }
                    else
                    {
                        await _unitOfWork.StudentRepo.UpdateAsync(viewModel);
                        await _unitOfWork.SaveAsync();

                        TempData["display_message"] = "Successfull updated.";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    TempData["display_message"] = "Not found.";
                    return View(viewModel);
                }
            }
            catch (Exception exception)
            {
                TempData["display_message"] = "Server Error.";
                var errorMessage = "";
                while (exception != null)
                {
                    errorMessage = errorMessage + exception.Message + " |";
                    exception = exception.InnerException;
                }
                TempData["hidden_message"] = "Error Message= " + errorMessage;
                return View(viewModel);
            }
        }

        public async Task<IActionResult> Delete(Int64 id)
        {
            try
            {
                var dataModel = (await _unitOfWork.StudentRepo.GetAsync(id));
                if (dataModel != null)
                {
                    var viewModel = new StudentViewModel()
                    {
                        Id = dataModel.Id,
                        Name = dataModel.Name,
                        NID = dataModel.NID,
                    };
                    return View(viewModel);
                }
                else
                {
                    TempData["display_message"] = "Not found.";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception exception)
            {
                TempData["display_message"] = "Server Error.";
                var errorMessage = "";
                while (exception != null)
                {
                    errorMessage = errorMessage + exception.Message + " |";
                    exception = exception.InnerException;
                }
                TempData["hidden_message"] = "Error Message= " + errorMessage;
                return RedirectToAction("Index");
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int64 id)
        {
            try
            {
                var dataModel = await _unitOfWork.StudentRepo.GetAsync(id);
                if (dataModel != null)
                {
                    dataModel.IsActive = false;
                    await _unitOfWork.StudentRepo.DeleteAsync(id);
                    await _unitOfWork.SaveAsync();
                    TempData["display_message"] = "Successfully removed.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["display_message"] = "Not found.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception exception)
            {
                TempData["display_message"] = "Server Error.";
                var errorMessage = "";
                while (exception != null)
                {
                    errorMessage = errorMessage + exception.Message + " |";
                    exception = exception.InnerException;
                }
                TempData["hidden_message"] = "Error Message= " + errorMessage;
                return RedirectToAction("Index");
            }
        }
    }
}

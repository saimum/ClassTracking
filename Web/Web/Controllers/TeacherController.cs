using BLL.Repository;
using DAL.DataModels;
using DAL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class TeacherController : BaseController
    {
        //public TeacherController(IUnitOfWork unitOfWork) : base(unitOfWork)
        //{
        //}
        public TeacherController(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public async Task<IActionResult> Index()
        {
            var viewModelList = (await _unitOfWork.TeacherRepo.GetAllAsync(filter: m => m.IsActive == true, includeProperties: "ClassDataModel")).Select(TeacherDataModel => new TeacherViewModel
            {
                Id = TeacherDataModel.Id,
                Name = TeacherDataModel.Name,
                NID = TeacherDataModel.NID,
                ClassDataModel = TeacherDataModel.ClassDataModel,
            }).ToList();
            return View(viewModelList);
        }

        public async Task<IActionResult> Details(Int64 id)
        {
            try
            {
                var dataModel = (await _unitOfWork.TeacherRepo.GetAsync(id));
                if (dataModel != null)
                {
                    var viewModel = new TeacherViewModel()
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
        public async Task<IActionResult> Create(TeacherViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _unitOfWork.TeacherRepo.IsNIDExistAsync(viewModel))
                    {
                        TempData["display_message"] = "Already exist.";
                        return View(viewModel);
                    }
                    else
                    {
                        var dataModel = new Teacher();
                        dataModel.IsActive = true;
                        dataModel.Name = viewModel.Name;
                        dataModel.NID = viewModel.NID;

                        await _unitOfWork.TeacherRepo.AddAsync(dataModel);
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
                var dataModel = (await _unitOfWork.TeacherRepo.GetAsync(id));
                if (dataModel != null)
                {
                    var viewModel = new TeacherViewModel()
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
        public async Task<IActionResult> Edit(TeacherViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid && viewModel.Id != 0)
                {
                    if (await _unitOfWork.TeacherRepo.IsNIDExistAsync(viewModel))
                    {
                        TempData["display_message"] = "Already exist.";
                        return View(viewModel);
                    }
                    else
                    {
                        await _unitOfWork.TeacherRepo.UpdateAsync(viewModel);
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
                var dataModel = (await _unitOfWork.TeacherRepo.GetAsync(id));
                if (dataModel != null)
                {
                    var viewModel = new TeacherViewModel()
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
                var dataModel = await _unitOfWork.TeacherRepo.GetAsync(id);
                if (dataModel != null)
                {
                    dataModel.IsActive = false;
                    await _unitOfWork.TeacherRepo.DeleteAsync(id);
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
        public async Task<IActionResult> UnsetClass(Int64 id)
        {
            try
            {
                var dataModel = await _unitOfWork.TeacherRepo.GetAsync(id);
                if (dataModel != null)
                {
                    await _unitOfWork.TeacherRepo.UnsetClassAsync(id);
                    await _unitOfWork.SaveAsync();

                    return Json(new { status = true, display_message = "Assigned to Class successfully", hidden_message = "" });
                }
                else
                {
                    return Json(new { status = false, display_message = "Not Found", hidden_message = "" });
                }
            }
            catch (Exception exception)
            {
                var errorMessage = "";
                while (exception != null)
                {
                    errorMessage = errorMessage + exception.Message + " |";
                    exception = exception.InnerException;
                }
                return Json(new { status = true, display_message = "Server Error.", hidden_message = "Error Message= " + errorMessage });
            }
        }
    }
}

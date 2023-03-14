using BLL.IRepository;
using BLL.Repository;
using DAL.DataModels;
using DAL.ViewModels;
using DAL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    public class ClassDataModelController : BaseController
    {
        //public ClassDataModelController(IUnitOfWork unitOfWork) : base(unitOfWork)
        //{
        //}
        public ClassDataModelController(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public async Task<IActionResult> Index()
        {
            var viewModelList = (await _unitOfWork.ClassDataModelRepo.GetAllAsync()).Select(dataModel => new ClassViewModel
            {
                Id = dataModel.Id,
                Name = dataModel.Name,
                Standard = dataModel.Standard,
                MaxStudent = dataModel.MaxStudent
            });
            return View(viewModelList);
        }

        public async Task<IActionResult> Details(Int64 id)
        {
            try
            {
                var dataModel = (await _unitOfWork.ClassDataModelRepo.GetAsync(id));
                if (dataModel != null)
                {
                    var viewModel = new ClassViewModel()
                    {
                        Id = dataModel.Id,
                        Name = dataModel.Name,
                        Standard = dataModel.Standard,
                        MaxStudent = dataModel.MaxStudent
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
        public async Task<IActionResult> Create(ClassViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _unitOfWork.ClassDataModelRepo.IsNameExistAsync(viewModel))
                    {
                        TempData["display_message"] = "Already exist.";
                        return View(viewModel);
                    }
                    else
                    {
                        var dataModel = new ClassDataModel();
                        dataModel.Name = viewModel.Name;
                        dataModel.Standard = viewModel.Standard;
                        dataModel.MaxStudent = viewModel.MaxStudent;

                        await _unitOfWork.ClassDataModelRepo.AddAsync(dataModel);
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
                var dataModel = (await _unitOfWork.ClassDataModelRepo.GetAsync(id));
                if (dataModel != null)
                {
                    var viewModel = new ClassViewModel()
                    {
                        Id = dataModel.Id,
                        Name = dataModel.Name,
                        Standard = dataModel.Standard,
                        MaxStudent = dataModel.MaxStudent
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
        public async Task<IActionResult> Edit(ClassViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid && viewModel.Id != 0)
                {
                    if (await _unitOfWork.ClassDataModelRepo.IsNameExistAsync(viewModel))
                    {
                        TempData["display_message"] = "Already exist.";
                        return View(viewModel);
                    }
                    else
                    {
                        await _unitOfWork.ClassDataModelRepo.UpdateAsync(viewModel);
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

        public async Task<IActionResult> AssignStudents(Int64 id)
        {
            try
            {
                var classDataModel = (await _unitOfWork.ClassDataModelRepo.GetAsync(id));
                if (classDataModel != null)
                {
                    var classViewModel = new ClassViewModel()
                    {
                        Id = classDataModel.Id,
                        Name = classDataModel.Name,
                        Standard = classDataModel.Standard,
                        MaxStudent = classDataModel.MaxStudent
                    };
                    var studentViewModelList = (await _unitOfWork.StudentRepo.GetAllAsync(filter: m => m.IsActive == true, includeProperties: "ClassDataModel")).Select(studentDataModel => new StudentViewModel
                    {
                        Id = studentDataModel.Id,
                        Name = studentDataModel.Name,
                        NID = studentDataModel.NID,
                        ClassDataModel = studentDataModel.ClassDataModel,
                    }).ToList();

                    return View(new Tuple<ClassViewModel, List<StudentViewModel>>(classViewModel, studentViewModelList));
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

        public async Task<IActionResult> TryAssign(Int64 ClassId, Int64 StudentId)
        {
            try
            {
                //var classDataModel = (await _unitOfWork.ClassDataModelRepo.GetAsync(id));
                //if (classDataModel != null)
                //{
                //    var classViewModel = new ClassViewModel()
                //    {
                //        Id = classDataModel.Id,
                //        Name = classDataModel.Name,
                //        Standard = classDataModel.Standard,
                //        MaxStudent = classDataModel.MaxStudent
                //    };
                //    var studentViewModelList = (await _unitOfWork.StudentRepo.GetAllAsync(filter: m => m.IsActive == true, includeProperties: "ClassDataModel")).Select(studentDataModel => new StudentViewModel
                //    {
                //        Id = studentDataModel.Id,
                //        Name = studentDataModel.Name,
                //        NID = studentDataModel.NID,
                //        ClassDataModel = studentDataModel.ClassDataModel,
                //    }).ToList();

                //    return View(new Tuple<ClassViewModel, List<StudentViewModel>>(classViewModel, studentViewModelList));
                //}
                //else
                //{
                //    TempData["display_message"] = "Not found.";
                return RedirectToAction("Index");
                //}
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

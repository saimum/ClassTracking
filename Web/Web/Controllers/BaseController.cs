using BLL.IRepository;
using BLL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        //internal readonly IUnitOfWork _unitOfWork;
        //public BaseController(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

        internal readonly UnitOfWork _unitOfWork;
        public BaseController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}

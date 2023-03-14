using BLL.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        internal readonly IUnitOfWork _unitOfWork;

        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}

using DAL.DataModels;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IRepository
{
    public interface IClassDataModelRepo : IRepository<ClassDataModel>
    {
        Task UpdateAsync(ClassViewModel viewModel);
        //Task<bool> IsActiveExistAsync();
    }
}

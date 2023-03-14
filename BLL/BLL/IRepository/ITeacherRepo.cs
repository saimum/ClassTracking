using DAL.DataModels;
using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IRepository
{
    public interface ITeacherRepo : IRepository<Teacher>
    {
        Task UpdateAsync(TeacherViewModel viewModel);
        Task DeleteAsync(Int64 id);
        //Task<bool> IsNIDExistAsync(TeacherViewModel viewModel);
    }
}

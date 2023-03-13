using DAL.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IRepository
{
    public interface ITeacherRepo : IRepository<Teacher>
    {
        Task UpdateAsync(Teacher model);
        Task<bool> IsNIDExistAsync(Teacher model);
    }
}

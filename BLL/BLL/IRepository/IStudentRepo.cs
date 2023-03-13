using DAL.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IRepository
{
    public interface IStudentRepo : IRepository<Student>
    {
        Task UpdateAsync(Student model);
        Task<bool> IsNIDExistAsync(Student model);
    }
}

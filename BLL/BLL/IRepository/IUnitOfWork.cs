using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        public IClassDataModelRepo ClassDataModelRepo { get; }
        public IStudentRepo StudentRepo { get; }
        public ITeacherRepo TeacherRepo { get; }
        Task SaveAsync();
    }
}

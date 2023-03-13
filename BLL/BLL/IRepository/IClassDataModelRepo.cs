using DAL.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IRepository
{
    public interface ClassDataModelRepo : IRepository<ClassDataModel>
    {
        Task UpdateAsync(ClassDataModel model);
        Task<bool> IsActiveExistAsync();
    }
}

using BLL.IRepository;
using DAL.DataModels;
using DAL.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository
{
    public class ClassDataModelRepo : Repository<ClassDataModel>, IClassDataModelRepo
    {
        private readonly ApplicationDbContext _db;
        public ClassDataModelRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task UpdateAsync(ClassViewModel viewModel)
        {
            var dataObj = await _db.ClassDataModels.FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if (dataObj != null)
            {
                dataObj.Name = viewModel.Name;
                dataObj.Standard = viewModel.Standard;
                dataObj.MaxStudent = viewModel.MaxStudent;
            }
        }
        public async Task<bool> IsNameExistAsync(ClassViewModel viewModel)
        {
            var dataObjCheck = false;
            if (viewModel.Id == 0)
            {
                dataObjCheck = await _db.ClassDataModels.AnyAsync(x => x.Name == viewModel.Name);
            }
            else
            {
                dataObjCheck = await _db.ClassDataModels.AnyAsync(x => x.Name == viewModel.Name && x.Id != viewModel.Id);
            }
            return dataObjCheck;
        }
    }
}

using DAL.DataModels;
using BLL.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ViewModels;

namespace BLL.Repository
{
    public class TeacherRepo : Repository<Teacher>, ITeacherRepo
    {
        private readonly ApplicationDbContext _db;
        public TeacherRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task UpdateAsync(TeacherViewModel viewModel)
        {
            var dataObj = await _db.Teachers.FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if (dataObj != null)
            {
                dataObj.Name = viewModel.Name;
                dataObj.NID = viewModel.NID;
            }
        }
        public async Task DeleteAsync(Int64 id)
        {
            var dataObj = await _db.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (dataObj != null)
            {
                dataObj.IsActive = false;
            }
        }
        public async Task<bool> IsNIDExistAsync(TeacherViewModel viewModel)
        {
            var dataObjCheck = false;
            if (viewModel.Id == 0)
            {
                dataObjCheck = await _db.Teachers.AnyAsync(x => x.NID == viewModel.NID);
            }
            else
            {
                dataObjCheck = await _db.Teachers.AnyAsync(x => x.NID == viewModel.NID && x.Id != viewModel.Id);
            }
            return dataObjCheck;
        }
    }
}


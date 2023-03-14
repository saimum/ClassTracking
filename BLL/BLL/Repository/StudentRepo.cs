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
    public class StudentRepo : Repository<Student>, IStudentRepo
    {
        private readonly ApplicationDbContext _db;
        public StudentRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task UpdateAsync(StudentViewModel viewModel)
        {
            var dataObj = await _db.Students.FirstOrDefaultAsync(x => x.Id == viewModel.Id);
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
        public async Task<bool> IsNIDExistAsync(StudentViewModel viewModel)
        {
            var dataObjCheck = false;
            if (viewModel.Id == 0)
            {
                dataObjCheck = await _db.Students.AnyAsync(x => x.NID == viewModel.NID);
            }
            else
            {
                dataObjCheck = await _db.Students.AnyAsync(x => x.NID == viewModel.NID && x.Id != viewModel.Id);
            }
            return dataObjCheck;
        }
    }
}


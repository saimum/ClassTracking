using DAL.DataModels;
using BLL.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository
{
    public class TeacherRepo : Repository<Teacher>, ITeacherRepo
    {
        private readonly ApplicationDbContext _db;
        public TeacherRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task UpdateAsync(Teacher model)
        {
            var dataObj = await _db.Teachers.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (dataObj != null)
            {
                dataObj.Name = model.Name;
                dataObj.NID = model.NID;
            }
        }
        public async Task<bool> IsNIDExistAsync(Teacher model)
        {
            var dataObjCheck = false;
            if (model.Id == 0)
            {
                dataObjCheck = await _db.Teachers.AnyAsync(x => x.NID == model.NID);
            }
            else
            {
                dataObjCheck = await _db.Teachers.AnyAsync(x => x.NID == model.NID && x.Id != model.Id);
            }
            return dataObjCheck;
        }
    }
}


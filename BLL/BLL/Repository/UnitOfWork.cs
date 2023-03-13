using BLL.IRepository;
using DAL.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository
{
    //internal class UnitOfWork
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ClassDataModelRepo = new ClassDataModelRepo(db);
            StudentRepo = new StudentRepo(db);
            TeacherRepo = new TeacherRepo(db);
        }
        private readonly ApplicationDbContext _db;
        public IClassDataModelRepo ClassDataModelRepo { get; private set; }
        public IStudentRepo StudentRepo { get; private set; }
        public ITeacherRepo TeacherRepo { get; private set; }

        public async void Dispose()
        {
            await _db.DisposeAsync();
        }
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}

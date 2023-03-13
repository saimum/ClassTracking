﻿using BLL.IRepository;
using DAL.DataModels;
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
        public async Task UpdateAsync(ClassDataModel model)
        {
            var dataObj = await _db.ClassDataModels.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (dataObj != null)
            {
                dataObj.Name = model.Name;
            }
        }
    }
}

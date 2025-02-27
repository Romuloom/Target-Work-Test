﻿using Cadastro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Cadastro.Infrastructure.Data.Common
{
    public class EfRepository<T> where T : BaseModel
    {
        protected readonly RegisterContext _dbContext;

        public EfRepository(RegisterContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual void Delete(int id)
        {
            var entity = Get(id);
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public virtual T Get(int id)
        {
            var keyValues = new object[] { id };
            return _dbContext.Set<T>().Find(keyValues);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public virtual void Insert(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}

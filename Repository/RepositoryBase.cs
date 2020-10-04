using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository
{
        public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
        {
            protected DataContext DataContext { get; set; }
            public RepositoryBase(DataContext dataContext)
            {
                DataContext = dataContext;
            }
            public IQueryable<T> GetAll()
            {
                return DataContext.Set<T>().AsNoTracking();
            }
            public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
            {
                return DataContext.Set<T>().Where(expression).AsNoTracking();
            }
            public void Create(T entity)
            {
                DataContext.Set<T>().Add(entity);
            }
            public void Update(T entity)
            {
                DataContext.Set<T>().Update(entity);
            }
            public void Delete(T entity)
            {
                DataContext.Set<T>().Remove(entity);
            }
        }
    }

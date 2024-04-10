﻿using System.Linq.Expressions;

namespace CitasMedicas.Repository
{
    public interface IGenericRepository<T> where T:class
    {
        T GetById(long id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T,bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}

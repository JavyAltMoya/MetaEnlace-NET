using CitasMedicas.BBDD;
using CitasMedicas.Repository;
using System;
using System.Linq.Expressions;

namespace CitasMedicas.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CitasMedicasDB _context;
        public GenericRepository(CitasMedicasDB context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(long id)
        {
            var findentity = _context.Set<T>().Find(id);
            if (findentity == null)
                throw new Exception("No se ha encontrado la entidad!");

            return findentity;
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}

using DbEmployees.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DbEmployees.Repositories
{
    public class EmployeeRepositoryImpl : IEmployeeRepository, IDisposable
    {
        //TODO: obtenemos la instancia de la base de datos
        private readonly DbContextManager _dbContextManager = DbContextManager.GetContextForCurrentEnvironment();

       

        public EmployeeEntity GetBy(Expression<Func<EmployeeEntity, bool>> filter)
        {
            var result = _dbContextManager.EmployeeEntity.Where(filter).FirstOrDefault(); //si no encuentra coincidencias retorna null
            return result;
        }

        public ICollection<EmployeeEntity> GetList(Expression<Func<EmployeeEntity, bool>> filter = null, Func<IQueryable<EmployeeEntity>, IOrderedQueryable<EmployeeEntity>> orderBy = null)
        {
            IQueryable<EmployeeEntity> query = _dbContextManager.EmployeeEntity;
           

            if (filter != null)
            {
                query = query.Where(filter);

            }

            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }



        [DebuggerStepThrough]
        public void Dispose()
        {
            dispose(true);
        }


        protected virtual void dispose(bool disposing)
        {
            if (!disposing) return;
            if (_dbContextManager != null)
                _dbContextManager.Dispose();
        }

        ~EmployeeRepositoryImpl()
        {
            dispose(false);
        }
    }
}

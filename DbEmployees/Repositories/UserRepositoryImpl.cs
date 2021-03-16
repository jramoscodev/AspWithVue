using DbEmployees.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;


namespace DbEmployees.Repositories
{
    public class UserRepositoryImpl : IUserRepository, IDisposable
    {
        //TODO: obtenemos la instancia de la base de datos
        private readonly DbContextManager _dbContextManager = DbContextManager.GetContextForCurrentEnvironment();

       


        //retorna un unico objeto del tipo UserEntity segun la busqueda enviada
        public UserEntity GetBy(Expression<Func<UserEntity, bool>> filter)
        {
            var result = _dbContextManager.UserEntity.Where(filter).FirstOrDefault(); //si no encuentra coincidencias retorna null
            return result;
        }

        public ICollection<UserEntity> GetListBy(Expression<Func<UserEntity, bool>> filter = null, Func<IQueryable<UserEntity>, IOrderedQueryable<UserEntity>> orderBy = null)
        {
            IQueryable<UserEntity> query = _dbContextManager.UserEntity;
          

            if (filter != null)
            {
                query = query.Where(filter);

            }

            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }



        /*
         TODO: esto lo que hace es que evita mantener en memoria algunas instancias no necesarias
         llama al garbage Collector para hacer limpieza 
         */

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

        ~UserRepositoryImpl()
        {
            dispose(false);
        }
    }
}

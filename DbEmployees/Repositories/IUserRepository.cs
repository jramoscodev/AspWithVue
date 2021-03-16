using DbEmployees.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DbEmployees.Repositories
{
    public interface IUserRepository
    {
        //TODO: se envia una expresion en los parametros para poder formar variedad de querys sin tener que repetir metodos
        ICollection<UserEntity> GetListBy(Expression<Func<UserEntity, bool>> filter = null, Func<IQueryable<UserEntity>, IOrderedQueryable<UserEntity>> orderBy = null);

        UserEntity GetBy(Expression<Func<UserEntity, bool>> filter);

        //aqui creamos los demas metodos a utlizar como update, delete, etc
    }
}

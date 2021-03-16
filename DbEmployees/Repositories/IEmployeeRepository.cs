using DbEmployees.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace DbEmployees.Repositories
{
    public interface IEmployeeRepository
    {
        ICollection<EmployeeEntity> GetList(Expression<Func<EmployeeEntity,bool>> filter=null, Func<IQueryable<EmployeeEntity>, IOrderedQueryable<EmployeeEntity>> orderBy = null);

        EmployeeEntity GetBy(Expression<Func<EmployeeEntity, bool>> filter);
    }
}

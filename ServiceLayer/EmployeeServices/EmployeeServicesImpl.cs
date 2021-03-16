using CommonDomain.ViewModels;
using DbEmployees.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.EmployeeServices
{
    public class EmployeeServicesImpl : IEmployeeServices
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeServicesImpl()
        {
            _employeeRepository = new EmployeeRepositoryImpl();
        }

        public ICollection<EmployeeViewModel> GetAllEmployees()
        {
            var result = new List<EmployeeViewModel>();
            var entity = _employeeRepository.GetList();//al no tener parametros obtiene todos
            result.AddRange(
                entity.Select(x => new EmployeeViewModel()
                {
                    Id = x.Id,
                    Nombre = x.CompleteName,
                    Sueldo = x.BaseSalary,
                    TipoEmpleado = x.TypeEmployeeEntity.Name
                }));



            return result;
        }

        public ICollection<EmployeeViewModel> GetEmployeesByType(int type)
        {
            throw new NotImplementedException();
        }

        public void SaveEmployee(EmployeeViewModel source)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(EmployeeViewModel source)
        {
            throw new NotImplementedException();
        }
    }
}

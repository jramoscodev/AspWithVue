using CommonDomain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.EmployeeServices
{
    public interface IEmployeeServices
    {
        ICollection<EmployeeViewModel> GetAllEmployees();
        ICollection<EmployeeViewModel> GetEmployeesByType(int type);

        void SaveEmployee(EmployeeViewModel source);

        void UpdateEmployee(EmployeeViewModel source);
    }
}

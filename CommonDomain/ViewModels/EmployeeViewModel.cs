using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDomain.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string TipoEmpleado { get; set; }
        public double Sueldo { get; set; }
    }
}

using CommonDomain.EmployeeDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbEmployees.Entities
{
    [Table("Empleados")]
    public class EmployeeEntity : Employee
    {
        [Key]
        public override int Id { get; set; }

        [Column(name:"NombreCompleto")]
        public override string CompleteName { get; set; }

        [Column(name:"SueldoBase")]
        public double BaseSalary { get; set; }

        [Column(name: "IdtipoEmpleado")]
        [ForeignKey("TypeEmployeeEntity")]
        public int TypeEmployeeId { get; set; }
        public override DateTime CreateAt { get; set; }

        [NotMapped]
        public override TypeEmployee TypeEmployee 
        {
            get => TypeEmployeeEntity;

            set
            {
                TypeEmployeeEntity = (TypeEmployeeEntity)value;
            }
        }


        public virtual TypeEmployeeEntity TypeEmployeeEntity { get; set; }


    }
}

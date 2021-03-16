using CommonDomain.EmployeeDomain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DbEmployees.Entities
{
    [Table("TipoEmpleados")]
    public class TypeEmployeeEntity : TypeEmployee
    {
        [Key]
        public override int Id { get; set; }

        [Column(name:"Nombre")]
        public override string Name { get; set; }

       
        public virtual ICollection<EmployeeEntity> EmployeeEntities { get; set; }
       
    }
}

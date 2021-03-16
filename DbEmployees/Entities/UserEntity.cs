using CommonDomain.UserDomain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DbEmployees.Entities
{
    [Table("Usuarios")]
    public class UserEntity : User
    {
        [Key]
        public override int Id { get; set; }
        [Column("Nombre")]
        public override string FirstName { get; set; }

        [Column("Apellido")]
        public override string LastName { get; set; }
        [Column("NombreUsuario")]
        public override string UserName { get; set; }
        [Column("Contrasena")]
        public string Password { get; set; }
        public override DateTime CreateAt { get; set; }
    }
}

namespace DbEmployees.Migrations
{
    using System;
    using System.Configuration;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DbEmployees.DbContextManager>
    {
        public Configuration()
        {
            var environment = ConfigurationManager.AppSettings["all.settings.environment"] ?? "none";
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = string.Format("{0}\\{1}", "Migrations", environment);
        }

        protected override void Seed(DbEmployees.DbContextManager context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //TODO:  Aqui se puede configurar parametros iniciales por ejemplo un usuario generico

            context.UserEntity.AddOrUpdate(x => x.Id,
                new Entities.UserEntity() { Id = 1, UserName = "test", 
                                            FirstName = "Test_Nombre", LastName ="Test_Apellido", 
                                            Password="123", CreateAt = DateTime.Now}

                );

            context.TypeEmployeeEntity.AddOrUpdate(x => x.Id,
                new Entities.TypeEmployeeEntity()
                {
                    Id = 1,
                    Name = "Por contrato"
                },
                 new Entities.TypeEmployeeEntity()
                 {
                     Id = 2,
                     Name = "Por Hora"
                 },
                  new Entities.TypeEmployeeEntity()
                  {
                      Id = 3,
                      Name = "Permanente"
                  }
                );

            context.EmployeeEntity.AddOrUpdate(x => x.Id,
                new Entities.EmployeeEntity()
                {
                   Id = 1,
                   CompleteName ="Carlos",
                   BaseSalary = 2500,
                   CreateAt = DateTime.Now,
                   TypeEmployeeId = 1
                },
                 new Entities.EmployeeEntity()
                 {
                     Id = 1,
                     CompleteName = "Luis",
                     BaseSalary = 5500,
                     CreateAt = DateTime.Now,
                     TypeEmployeeId = 2
                 },
                  new Entities.EmployeeEntity()
                  {
                      Id = 1,
                      CompleteName = "Pedro",
                      BaseSalary = 3500,
                      CreateAt = DateTime.Now,
                      TypeEmployeeId = 3
                  }
                );

        }
    }
}

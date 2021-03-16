using DbEmployees.Entities;
using System;
using System.Configuration;
using System.Data.Entity;

using System.Data.Entity.Infrastructure;

/*
 TODO: Administracion de Conexion a Base de Datos
 
  Clase DbContextFactory: patron factory para creacion de instancia de base de datos
  clase DbContextManager: clase que hereda de DbContext(EF) y crea un clase static para mantener una unica conexion a DB
 */



namespace DbEmployees
{
    public class DbContextFactory : IDbContextFactory<DbContextManager>
    {
        public virtual DbContextManager Create()
        {
            return DbContextManager.GetContextForCurrentEnvironment();
        }

    }
    public class DbContextManager : DbContext
    {
        private static readonly string currentEnvironment = null;
        private static readonly string currentDbConnection = null;
        private DbContextManager(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

            
        }

        public static DbContextManager GetContextForCurrentEnvironment()
        {
            //instancia de sqlServer.dll esto permite que no exista redundancia en dll
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            
            /*obtener la cadena de conexion de db, esto permite que en web.config podamos tener varias conexion de base de datos
             * por ejemplo produccion, desarrollo y local y con cambiar el valor de all.settings.environment 
             * dev = desarrollo
             * prod= produccion
             * local= ambiente local
             * 
             * en connectionStrings el nombre de las conexiones debe comenzar con loca.xxx o dev.xxx
             * ejemplo:
             * local.main.dBConnectionStringName
             * dev.main.dBConnectionStringName
             * prod.main.dBConnectionStringName
             
             */
            var environment = currentEnvironment ?? ConfigurationManager.AppSettings["all.settings.environment"] ?? string.Empty;
            var dbConnection = currentDbConnection ?? ConfigurationManager.AppSettings[environment + ".settings.database.main.dBConnectionStringName"] ?? string.Empty;
            if (string.IsNullOrWhiteSpace(dbConnection)) throw new Exception("Invalid dbConnection for environment (" + environment + ")");
            return new DbContextManager(dbConnection);

        }
        //Entities
        public virtual DbSet<UserEntity> UserEntity { get; set; }

        public virtual DbSet<EmployeeEntity> EmployeeEntity { get; set; }

        public virtual DbSet<TypeEmployeeEntity> TypeEmployeeEntity { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");

            //aqui hacemos mas configuraciones de firstcode cuando hay mas tablas y se tiene que hacer optimizaciones

            modelBuilder.Entity<EmployeeEntity>()
               .HasRequired(s => s.TypeEmployeeEntity)
               .WithMany(x => x.EmployeeEntities)
               .HasForeignKey(s => s.TypeEmployeeId)
               .WillCascadeOnDelete(false);


            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
           

        }
    }
}

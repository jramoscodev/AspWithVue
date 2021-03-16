using System;


namespace CommonDomain.EmployeeDomain
{
    public abstract class Employee
    {
        public abstract int Id { get; set; }
        public abstract string CompleteName { get; set; }
        public abstract DateTime CreateAt { get; set; }

        public abstract TypeEmployee TypeEmployee { get; set; }
    }
}

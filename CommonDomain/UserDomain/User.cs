using System;

namespace CommonDomain.UserDomain
{
    public abstract class User
    {
        public abstract int Id { get; set; }
        public abstract string FirstName { get; set; }
        public abstract string LastName { get; set; }
        public abstract string UserName { get; set; }
        public abstract DateTime CreateAt { get; set; }

    }
}

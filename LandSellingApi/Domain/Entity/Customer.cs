using System;


namespace Domain.Entity
{
    public class Customer : User
    {
        public Customer(Guid idLink) : base(idLink)
        {   
        }
    }
}

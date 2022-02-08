using System;

namespace Domain.Entity
{
    public class Admin : User
    {
        public Admin(Guid idLink) : base(idLink)
        {
        }
        public decimal Salary { get; set; }
    }
}

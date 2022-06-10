using Domain.Entity.Base;
using System;

namespace Domain.Entity
{
    public class Person : EntityBase
    {
        protected Person(Guid idLink)
        {
            IdLink = idLink;
        }

        public Guid IdLink { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

    }
}

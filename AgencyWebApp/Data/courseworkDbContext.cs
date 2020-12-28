using System;
using System.Data.Entity;
using AgencyIdentity.Models;

namespace AgencyIdentity.Data
{
    public partial class courseworkDbContext : DbContext
    {
        public courseworkDbContext()
            : base("name=AgencyConnectionString")
        {
        }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Policy> Policies { get; set; }
        public virtual DbSet<TypeOfInsurance> TypesOfInsurance { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace AgencyIdentity.Models
{
    public partial class TypeOfInsurance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Payment { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
    }
}

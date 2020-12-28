using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgencyIdentity.Models
{
    public partial class Policy
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        [Display(Name = "Register date")]
        public DateTime RegistredAt { get; set; }
        [Display(Name = "Finish date")]
        public DateTime Finish { get; set; }
        public int TypeOfInsuranceId { get; set; }

        public virtual Client Client { get; set; }
        public virtual TypeOfInsurance TypeOfInsurance { get; set; }

    }
}

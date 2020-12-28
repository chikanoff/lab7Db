using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace AgencyIdentity.Models
{
    public partial class Client
    {
        public Client()
        {
            Policies = new HashSet<Policy>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        [Display(Name = "Birth")]
        public DateTime DateOfBirth { get; set; }
        public string Adress { get; set; }
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
        public string Residence { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
    }
}

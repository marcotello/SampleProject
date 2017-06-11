using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Models
{
    public class CustomerViewModel
    {
        [Display(Name="Full Name")]
        public string ContactName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        public string CustomerId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSportsApp.Models
{
    public class TestDetail
    {
        [Key]
        public int AthleteId { get; set; }
        [Display(Name = "Name ")]
        public string AthleteName { get; set; }
        [Display(Name = "Test Id ")]
        public int TestId { get; set; }
        [Display(Name = "Distance (meter)")]
        public decimal Distance { get; set; }
        [Display(Name = "Fitness ranking ")]
        public string MyProperty { get; set; }
    }
}

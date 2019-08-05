using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSportsApp.Models
{
    public class Test
    {
        [Key]
        public int TestId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int NumOfParticipants { get; set; }
        [Display(Name = "Type")]
        public string TestType { get; set; }

    }
}

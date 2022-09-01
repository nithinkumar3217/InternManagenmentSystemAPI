using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternManagementSystem.Models
{
    public class InternWorkingHour
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int SNo { get; set; }

        [Required]
        public int InternId { get; set; }

        [DisplayName("Comp WorkHours In Month")]
        public int CompanyMonthlyWorkingHours { get; set; }

        [DisplayName("Intern WorkHours In Month")]
        public int InternMonthlyWorkingHours { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternManagementSystem.Models
{
    public class InternRecord
    {
        

        [Key]
        [Required]
        public int InternId { get; set; }

        [DisplayName("Intern Name")]
        [Required]
        [Column(TypeName = "nvarchar(25)")]
        public string InternName { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }

        public InternDesignation InternDesignation { get; set; }
        public int DesigntionId { get; set; }

        [Required]
        public int Status { get; set; }



    }
}

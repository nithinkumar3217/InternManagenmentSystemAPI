using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternManagementSystem.Models
{
    public class InternDesignation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int SNo { get; set; }

        [DisplayName("Designation Id")]
        [Required]
        public int DesignationId { get; set; }


        [DisplayName("Designation Name")]
        [Required]
        [Column(TypeName = "nvarchar(25)")]
        public string DesignationName { get; set; }

        [DisplayName("Department")]
        [Column(TypeName = "nvarchar(15)")]
        public string DepartMent { get; set; }
    }
}

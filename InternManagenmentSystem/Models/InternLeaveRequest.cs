using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternManagementSystem.Models
{
    public class InternLeaveRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int SNo { get; set; }

        [Required]
        public int InternId { get; set; }

        public string InternName { get; set; }

        [Required]
        [DisplayName("Leave Date")]
        public string LeaveDate { get; set; }

        [DisplayName("Leave Reason")]
        [Column(TypeName = "nvarchar(25)")] 
        public string LeaveReason { get; set; }

        [DisplayName("Leave Type")]
        [Column(TypeName = "nvarchar(25)")]
        public string LeaveType { get; set; }
    }
}

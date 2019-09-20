using System;
using System.ComponentModel.DataAnnotations;
using GHMS.DataModel.Models.Common;

namespace GHMS.DataModel.Models
{
    public class HospitalUserDetailsAudits : BaseAuditsDBModel
    {
        [Key]
        public Int64 Id { get; set; }
        [MaxLength(100)]
        [Required]
        public String FirstName { get; set; }
        [MaxLength(100)]
        public String MiddleName { get; set; }
        [MaxLength(100)]
        [Required]
        public String LastName { get; set; }
        public Int64 HospitalUserDetailsId { get; set; }
        public HospitalUserDetails HospitalUserDetails { get; set; }
    }
}

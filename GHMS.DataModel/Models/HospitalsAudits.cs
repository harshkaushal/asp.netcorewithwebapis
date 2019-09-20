using System;
using System.ComponentModel.DataAnnotations;
using GHMS.DataModel.Models.Common;

namespace GHMS.DataModel.Models
{
    public class HospitalsAudits : BaseAuditsDBModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        [Required]
        public String Name { get; set; }
        [MaxLength(10)]
        [Required]
        public String Code { get; set; }

        public int HospitalId { get; set; }
        public Hospitals Hospital { get; set; }
    }
}

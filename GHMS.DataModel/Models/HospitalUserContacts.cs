using System;
using System.ComponentModel.DataAnnotations;
using GHMS.DataModel.Models.Common;

namespace GHMS.DataModel.Models
{
    public class HospitalUserContacts : BaseDBModel
    {
        [Key]
        public Int64 Id { get; set; }

        public int HospitalUserDetailsId { get; set; }
        public HospitalUserDetails HospitalUserDetails { get; set; }
        [MaxLength(100)]
        [Required]
        public String Contact { get; set; }

        public int ContactTypesId { get; set; }
        public LuContactTypes ContactTypes { get; set; }

    }
}

using System;
using System.ComponentModel.DataAnnotations;
using GHMS.DataModel.Models.Common;

namespace GHMS.DataModel.Models
{
    public class LnkHospitalUserAddress : BaseDBModel
    {
        [Key]
        public Int64 Id { get; set; }
      
        public int HospitalUserDetailsId { get; set; }
        public HospitalUserDetails HospitalUserDetails { get; set; }

        public Int64 AddressId { get; set; }
        public Address Address { get; set; }

    }
}

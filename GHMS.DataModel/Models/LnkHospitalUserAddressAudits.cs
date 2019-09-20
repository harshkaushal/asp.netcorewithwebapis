using System;
using System.ComponentModel.DataAnnotations;
using GHMS.DataModel.Models.Common;

namespace GHMS.DataModel.Models
{
    public class LnkHospitalUserAddressAudits : BaseAuditsDBModel
    {
        [Key]
        public Int64 Id { get; set; }

        public int HospitalUserDetailsId { get; set; }
      
        public Int64 AddressId { get; set; }
        public Int64 LnkHospitalUserAddressId { get; set; }
        public LnkHospitalUserAddress LnkHospitalUserAddress { get; set; }
    }
}

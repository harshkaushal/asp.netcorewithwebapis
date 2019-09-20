using System;
using System.ComponentModel.DataAnnotations;
using GHMS.DataModel.Models.Common;

namespace GHMS.DataModel.Models
{
    public class AddressAudits : BaseAuditsDBModel
    {

        [Key]
        public   Int64 Id { get; set; }
        [MaxLength(200)]
        [Required]
        public string AddressLine1 { get; set; }
        [MaxLength(200)]
        public string AddressLine2 { get; set; }

        [MaxLength(6)]
        [Required]
        public string Zip { get; set; }
        [MaxLength(50)]
        [Required]
        public string City { get; set; }
        [MaxLength(50)]
        [Required]
        public string State { get; set; }
        [MaxLength(50)]
        [Required]
        public string Country { get; set; }
        public Int64 AddressId { get; set; }
        public Address Address { get; set; }
    }
}

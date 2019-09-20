using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using GHMS.DataModel.Models.Common;

namespace GHMS.DataModel.Models
{
    public class HospitalUserDetails:BaseDBModel
    {
        [Key]
        public Int64 Id { get; set; }
        [MaxLength(100)]
        public string AspNetUserId { get; set; }
        public ApplicationUser AspNetUser { get; set; }
        [MaxLength(100)]
        [Required]
        public String FirstName { get; set; }
        [MaxLength(100)]
        public String MiddleName { get; set; }
        [MaxLength(100)]
        [Required]
        public String LastName { get; set; }
       
    }
}

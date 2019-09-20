using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using GHMS.DataModel.Models.Common;

namespace GHMS.DataModel.Models
{
    public class Hospitals : BaseDBModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        [Required]
        public String Name { get; set; }
        [MaxLength(10)]
        [Required]
        public String Code { get; set; }
       
    }
}

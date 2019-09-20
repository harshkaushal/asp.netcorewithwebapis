using System;
using System.ComponentModel.DataAnnotations;
using GHMS.DataModel.Models.Common;

namespace GHMS.DataModel.Models
{
    public class LuContactTypes : BaseDBModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public String Name { get; set; }
        [MaxLength(500)]
        [Required]
        public String Description { get; set; }
    }
}

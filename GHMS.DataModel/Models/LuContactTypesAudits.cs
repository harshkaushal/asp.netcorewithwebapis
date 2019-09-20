using System;
using System.ComponentModel.DataAnnotations;
using GHMS.DataModel.Models.Common;

namespace GHMS.DataModel.Models
{
    public class LuContactTypesAudits : BaseAuditsDBModel
    {
        [Key]
        public Int64 Id { get; set; }
        [MaxLength(100)]
        [Required]
        public String Name { get; set; }
        [MaxLength(500)]
        [Required]
        public String Description { get; set; }

        public int ContactTypesId { get; set; }
        public LuContactTypes ContactTypes { get; set; }
    }
}

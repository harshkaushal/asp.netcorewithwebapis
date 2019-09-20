using System;
using System.ComponentModel.DataAnnotations;
using GHMS.DataModel.Models.Common;

namespace GHMS.DataModel.Models
{
    public class LuCities : BaseDBModel
    {
        [Key]
        public Int64 Id { get; set; }
       
        [MaxLength(100)]
        [Required]
        public String Name { get; set; }
        
        [MaxLength(100)]
        [Required]
        public String PostalCode { get; set; }
        public int StateId { get; set; }
        public LuStates State { get; set; }

    }
}

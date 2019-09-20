using System;
using System.ComponentModel.DataAnnotations;
using GHMS.DataModel.Models.Common;

namespace GHMS.DataModel.Models
{
    public class LuCitiesAudits : BaseAuditsDBModel
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
        public int CityId { get; set; }
        public LuCities City { get; set; }

    }
}

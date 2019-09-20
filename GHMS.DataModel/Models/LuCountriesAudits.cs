using System;
using System.ComponentModel.DataAnnotations;
using GHMS.DataModel.Models.Common;

namespace GHMS.DataModel.Models
{
    public class LuCountriesAudits : BaseAuditsDBModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public String Name { get; set; }
        [MaxLength(10)]
        [Required]
        public String Code { get; set; }
        public int CountryId { get; set; }
        public LuCountries Country { get; set; }
    }
}

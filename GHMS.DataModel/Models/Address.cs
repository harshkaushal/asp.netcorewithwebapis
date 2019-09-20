using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using GHMS.DataModel.Models.Common;

namespace GHMS.DataModel.Models
{
    public class Address:BaseDBModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        [Required]
        public string AddressLine1 { get; set; }
        [MaxLength(200)]
        public string AddressLine2 { get; set; }
        
        [MaxLength(6)]
        [Required]
        public string Zip { get; set; }
        
        public Int64 CityId { get; set; }
        public LuCities City { get; set; }
        public int StateId { get; set; }
        public LuStates State { get; set; }
        public int CountryId { get; set; }
        public LuCountries Country { get; set; }
    }
}

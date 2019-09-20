using GHMS.DataModel.Models.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GHMS.DataModel.Models.Common
{
    public class BaseDBModel
    {
        public string LastUpdateUserId { get; set; }
        public ApplicationUser LastUpdateUser { get; set; }

        //[DefaultValue(typeof(DateTime), DateTime.Now.ToString())]
        public DateTime LastUpdateDate { get; set; }
        [DefaultValue("true")]
        public bool IsActive { get; set; }
    }
    public class BaseDBModel_WithoutUserId
    {
        
        public DateTime LastUpdateDate { get; set; }
        [DefaultValue("true")]
        public bool IsActive { get; set; }
    }
    public class BaseAuditsDBModel
    {
 

        public string LastUpdateUserId { get; set; }
      
        //[DefaultValue(typeof(DateTime), DateTime.Now.ToString())]
        public DateTime LastUpdateDate { get; set; }
        [DefaultValue("true")]
        public bool IsActive { get; set; }
        public string ModifiedUserId { get; set; }
        public ApplicationUser ModifiedUser { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public class BaseAuditsDBModel_WithoutUserId
    {
        
        public DateTime LastUpdateDate { get; set; }
        [DefaultValue("true")]
        public bool IsActive { get; set; }
        public string ModifiedUserId { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}

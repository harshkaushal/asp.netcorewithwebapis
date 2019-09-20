using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GHMS.DataModel.Models
{
    public partial class Logs
    {
        [Key]
        public int Id { get; set; }

         
        public string Message { get; set; }

        public string MessageTemplate { get; set; }
        [MaxLength(128)]
        public string Project { get; set; }
        [MaxLength(128)]
        public string ControllerName { get; set; }
        [MaxLength(128)]
        public string ActionName { get; set; }
        [MaxLength(450)]
        public string AspNetUserId { get; set; }
      
        [MaxLength(128)]
        public string Level { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Exception { get; set; }
        [Column(TypeName = "xml")]
        public string Properties { get; set; }
        public string LogEvent { get; set; }
    }
}

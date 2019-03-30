using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logs.Models
{
   public class Logs
    {
        [Key]
        public int LogID { get; set; }
        public string Message { get; set; }
        public string TypeMessage { get; set; }
        public DateTime Date { get; set; }
    }
}

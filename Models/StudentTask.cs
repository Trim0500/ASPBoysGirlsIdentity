using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPBoysGirlsIdentity.Models
{
    [Table("StudentTask")]
    public class StudentTask
    {
        [Key]
        public int id { get; set; }
        public string desc { get; set; }
        public string loc { get; set; }
    }
}

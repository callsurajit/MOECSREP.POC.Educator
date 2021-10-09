using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MOECSREP.POC.Educator.Models
{
    public class Education
    {
        [Key]
        public int EducationID { get; set; }
        public int EducatorID { get; set; }
        public string College { get; set; }
        public string Degree { get; set; }
        public string YearCompleted { get; set; }       
    }
}

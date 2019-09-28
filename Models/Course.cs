using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfSpec.Models
{
    public class Course
    {
        [Display(Name="Номер курса")]
        public int CourseID { get; set; }

        [Display(Name= "Наименованbt курса")]
        public string Name { get; set; }
    }
}

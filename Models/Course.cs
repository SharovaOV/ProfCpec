using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfSpec.Models
{
    /// <summary>Курс </summary>
    public class Course
    {
        [Display(Name="Номер курса")]
        public int CourseID { get; set; }

        [Display(Name= "Наименованbt курса")]
        public string Name { get; set; }
        [Display(Name="Сыылка на курс")]
        public string LinkCourse { get; set; }

       public ICollection<CompetenceCourse> CompetenceCourses { get; set; }
        public ICollection<ApplicationCourse> ApplicationCourses { get; set; }

    }
}

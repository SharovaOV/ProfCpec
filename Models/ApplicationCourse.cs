using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfSpec.Models
{
    /// <summary>Заявка на прохождение курса</summary>
    public class ApplicationCourse
    {
        public int ApplicationCourseID { get; set; }
        [Display(Name = "Работник")]
        public int WorkerID { get; set; }
        [Display(Name = "Желаемый курс")]
        public int CourseID { get; set; }
        [Display(Name = "Состояние заявки")]
        public int StagesApplicationID { get; set; }

        public Worker Worker { get; set; }
        public Course Course { get; set; }
        public StagesApplication StagesApplication { get; set; }

    }
}

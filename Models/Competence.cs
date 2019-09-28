using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ProfSpec.Models
{
    public class Competence
    {
        public int CompetenceID { get; set; }
        [Display(Name="Наименование компетенции")]
        public string Name { get; set; }

        ICollection<CompetenceCourse> CompetenceCourses { get; set; }
        ICollection<CompetencePosition> CompetencePositions { get; set; }
        ICollection<CompetenceWorker> CompetenceWorkers { get; set; }
    }
}

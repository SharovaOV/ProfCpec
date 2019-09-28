using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ProfSpec.Models
{
    /// <summary>Компетенция </summary>
    public class Competence
    {
        public int CompetenceID { get; set; }
        [Display(Name="Наименование компетенции")]
        public string Name { get; set; }

        public ICollection<CompetenceCourse> CompetenceCourses { get; set; }
        public ICollection<CompetencePosition> CompetencePositions { get; set; }
        public ICollection<CompetenceWorker> CompetenceWorkers { get; set; }
    }
}

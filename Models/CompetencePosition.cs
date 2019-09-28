using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfSpec.Models
{
    public class CompetencePosition
    {
        [Display(Name = "Компетенция")]
        public int CompetenceID { get; set; }
        [Display(Name = "Позиция")]
        public int PositionID { get; set; }
        
        
        [Display(Name = "Уровень компетенции")]
        public int Level { get; set; }

        public Position Position { get; set; }
        public Competence Competence { get; set; }
    }
}

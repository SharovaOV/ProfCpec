using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfSpec.Models
{
    /// <summary>Переквалификация </summary>
    public class Reclassification
    {
        public int ReclassificationID { get; set; }
        [Display(Name = "Работник")]
        public int WorkerID { get; set; }
        [Display(Name = "Целевая позиция")]
        public int PositionID { get; set; }
        [Display(Name = "Стадия реализации")]
        public  int StagesRequalificationID { get; set; }
        [Display(Name = "Назначеный ментор")]
        public int ReclassificationMentor{ get; set; }
        

        public Worker Worker { get; set; }
        public Position Position { get; set; }
        public StagesRequalification StagesRequalification { get; set; }
        public ReclassificationMentor Mentor { get; set; }
    }
}

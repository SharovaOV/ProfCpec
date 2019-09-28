using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfSpec.Models
{
/// <summary>Заявка на переквалификацию </summary>
    public class ApplicationReclassification
    {
        public int ApplicationCourseID { get; set; }
        [Display(Name = "Работник")]
        public int WorkerID { get; set; }
        [Display(Name = "Желаемая позиция")]
        public int PositionID { get; set; }
        [Display(Name = "Состояние заявки")]
        public int StagesApplicationID { get; set; }

        public Worker Worker { get; set; }
        public Position  Position { get; set; }
        public StagesApplication StagesApplication { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfSpec.Models
{
    /// <summary>ЗПозиция </summary>
    public class Position
    {
       
        public int PositionID { get; set; }
        [Required]
        [Display(Name="Наименование позиции")]
        public string Name { get; set; }
        [Display(Name = "Рейтинг позиции")]
        public double Rating { get; set; }
        [Display(Name = "Оклад")]
        [Column(TypeName ="money")]
        public double SalaryRate { get; set; }
        [Display(Name = "Количество клеток")]
        public int Count { get; set; }
        [Display(Name = "Предпочтительность опыта волонтерской работы")]
        public bool Volunteerism { get; set; }
        public ICollection<CompetencePosition> competencePositions { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfSpec.Models
{
    /// <summary>ЗНаправление области знаний </summary>
    public class DirectionsOfTraining
    {
        [Key]
        public int DirectionsID { get; set; }
        [Display(Name="Наименование направления")]
        public string Name { get; set; }
    }
}

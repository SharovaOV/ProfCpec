using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfSpec.Models
{
    /// <summary>Стадия переквалификации</summary>
    public class StagesRequalification
    {
        public int StagesRequalificationID { get; set; }
        [Display(Name = "Состояние")]
        public string Name { get; set; }
    }
}

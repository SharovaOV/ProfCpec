using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfSpec.Models
{
    /// <summary>Стадия запроса сотрудника</summary>
    public class StagesApplication
    {
        public int StagesApplicationID { get; set; }
        [Display(Name = "Состояние")]
        public string Name { get; set; }
    }
}

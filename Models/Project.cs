using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfSpec.Models
{
    public class Project
    {
        public int ProjectID { get; set; }
        [Display(Name = "Наименование проекта")]
        public string Name { get; set; }
        [Display(Name = "Начальник проекта")]
        public int WorkerID { get; set; }


        public Worker Worker { get; set; }
    }
}

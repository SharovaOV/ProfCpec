using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfSpec.Models
{
    /// <summary>Интерес работника </summary>
    public class InterestWorker
    {
        public int InterestWorkerID { get; set; }
        [Display(Name ="Интерес")]
        public int InterestID { get; set; }
        [Display(Name = "Работник")]
        public int WorkerID { get; set; }

        public Interest Interest { get; set; }
        public Worker Worker { get; set; }
    }
}

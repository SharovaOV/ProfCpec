using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfSpec.Models
{
    /// <summary>Хобби работника</summary>
    public class HobbyWorker
    {
        public int HobbyWorkerID { get; set; }
        [Display(Name = "Работник")]
        public int WorkerID { get; set; }
        [Display(Name = "Хобби работника")]
        public int HobbyID { get; set; }
        public Worker Worker { get; set; }
        public Hobby Hobby { get; set; }
    }
}

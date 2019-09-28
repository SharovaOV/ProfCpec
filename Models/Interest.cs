using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfSpec.Models
{
    /// <summary>Интерес</summary>
    public class Interest
    {
        public int InterestID { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "Направление")]
        public int DirectionsOfTrainingID { get; set; }

        public DirectionsOfTraining DirectionsOfTraining { get; set; }
        public ICollection<InterestWorker> InterestsWorker { get; set; }
    }
}

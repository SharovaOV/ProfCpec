using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfSpec.Models
{/// <summary>Участник проекта </summary>
    public class ProjectWorker
    {
        public int ProjectWorkerID { get; set; }
        [Display(Name = "Проект")]
        public int ProjectID { get; set; }
        [Display(Name = "Участник проекта")]
        public int WorkerID { get; set; }
        [Display(Name = "Роль участника проекта")]
        public int RolOfProjectID { get; set; }

        public Project Project { get; set; }
        public Worker Worker { get; set; }
        public RolOfProject RolOfProject { get; set; }
    }
}

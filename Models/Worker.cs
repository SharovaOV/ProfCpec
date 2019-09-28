using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfSpec.Models
{
    public class Worker
    {
        public int ID { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Отчество")]
        public string SecondName { get; set; }
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.mm.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата начала работы в компании")]
        public DateTime StartData { get; set; }
        [Display(Name = "Занимаемая должность")]
        public int PositionID { get; set; }
        [Display(Name = "Степень вовлеченности в деятельность компании")]
        public int Involvement { get; set; }
        [Display(Name = "Направленность базового образования")]
        public int DirectionOfTrainingID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.mm.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата рождения")]
        public DateTime Birthday { get; set; }
        [Display(Name = "Участие в волонтерской деятельности")]
        public bool Volunteerism { get; set; }


        public Position Position { get; set; }
        public DirectionsOfTraining DirectionsOfTraining { get; set; }

        [Display(Name = "ФИО")]
        public string FullName
        {
            get
            {
                return Surname + " " + Name + " " + SecondName;
            }
        }

        public ICollection<CompetenceWorker> CompetenceWorkers { get; set; }
        public Project SupervisedProject { get; set; }

        public IComparable<Project> Projects { get; set; }





    }
}

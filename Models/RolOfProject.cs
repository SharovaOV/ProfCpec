using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfSpec.Models
{
    /// <summary>Роль в проекте</summary>
    public class RolOfProject
    {
        public int ID { get; set; }
        [Display(Name="Наименование роли")]
        public string Name { get; set; }
    }
}

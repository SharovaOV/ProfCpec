using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfSpec.Models
{
    public class Hobby
    {
        public int HobbyID { get; set; }
        [Display(Name="Название хобби")]
        public string Name { get; set; }
    }
}

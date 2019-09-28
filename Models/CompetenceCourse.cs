﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProfSpec.Models
{
    public class CompetenceCourse
    {
        [Display(Name = "Компетенция")]
        public int CompetenceID { get; set; }
        [Display(Name = "Курс")]
        public int CourseID { get; set; }
        [Display(Name = "Уровень компетенции")]
        public int Level { get; set; }
        public Course Course { get; set; }
        public Competence Competence { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfSpec.Models
{
    public class ReclassificationMentor
    {
        public int ID { get; set; }
        public int ReclassificationID { get; set; }
        public int WorkerID { get; set; }

        public Reclassification Reclassification { get; set; }
        public Worker Mentor { get; set; }
    }
}

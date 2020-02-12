using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class Traineeship
    {
        public int TraineeshipId { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal Prize { get; set; }
        public DateTime DateOfEnd { get; set; }
        public DateTime DateOfStart { get; set; }
        //Relation N-N With Pilot (A Trainnship can be followed by many pilots)
        public IList<PilotTraineeship> PilotTraineeships { get; set; }
        //Relation 1-N to Certificate ( a specific traineeship can only lean to one certificate)
        public int? CertificateId { get; set; }
        public Certificate Certificate { get; set; }

    }
}

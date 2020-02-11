using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class Traineeship
    {
        public int TraineeshipId { get; set; }
        public decimal Prize { get; set; }
        public DateTime DateOfEnd { get; set; }
        public DateTime DateOfStart { get; set; }
        public IList<PilotTraineeship> PilotTraineeships { get; set; }

    }
}

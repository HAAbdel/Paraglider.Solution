using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class PilotTraineeship
    {
        public int PilotId { get; set; }
        public Pilot Pilot { get; set; }

        [Required]
        public bool FollowExam { get; set; }

        public int TraineeshipId { get; set; }
        public Traineeship Traineeship { get; set; }
    }
}

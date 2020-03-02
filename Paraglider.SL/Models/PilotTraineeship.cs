using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class PilotTraineeship
    {
        //Properties
        [Required]
        public bool IsTreacher { get; set; }
        [Required]
        public bool FollowExam { get; set; }
        //Navigation properties And CompositKey
        public int PilotId { get; set; }
        public Pilot Pilot { get; set; }
        public int TraineeshipId { get; set; }
        public Traineeship Traineeship { get; set; }
    }
}

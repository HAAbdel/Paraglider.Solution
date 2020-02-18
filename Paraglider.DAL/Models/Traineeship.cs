using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class Traineeship
    {
        //Primary key
        public int TraineeshipId { get; set; }
        //Soft delete
        [Required]
        public bool IsActive { get; set; }
        //Properties
        public decimal Prize { get; set; }
        public DateTime DateOfEnd { get; set; }
        public DateTime DateOfStart { get; set; }
        //Navigation properties
        public IList<PilotTraineeship> PilotTraineeships { get; set; }
        public int? CertificateId { get; set; }
        public Certificate Certificate { get; set; }
        public int LevelId { get; set; }
        public Level Level { get; set; }

    }
}

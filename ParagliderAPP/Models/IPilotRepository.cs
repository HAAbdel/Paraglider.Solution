using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParagliderAPP.Models
{
    public interface IPilotRepository
    {
        IEnumerable<Pilot> GetPilotByName(String Name);

        IEnumerable<Pilot> GetAllPilot();
        IEnumerable<Pilot> GetPilotByID(int Id);
    }
}

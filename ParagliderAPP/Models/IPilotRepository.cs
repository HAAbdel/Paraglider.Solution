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
        Pilot GetPilot(string name);
        IEnumerable<Pilot> GetAllPilot();
    }
}

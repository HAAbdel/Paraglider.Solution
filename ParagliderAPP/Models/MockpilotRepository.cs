using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParagliderAPP.Models
{
    public class MockpilotRepository : IPilotRepository
    {
        private List<Pilot> _PilotList;
        public MockpilotRepository()
        {
            _PilotList = new List<Pilot>()
            {
                new Pilot() {PilotId =new Guid(), FirstName="yves",LastName="blavier",Email="yblavier@hotmail.com",PhoneNumber="0474082325",Weight = 70 }
            };
        }

        public IEnumerable<Pilot> GetAllPilot()
        {
            return _PilotList;
        }

        public Pilot GetPilot(Guid Id)
        {
            return _PilotList.FirstOrDefault(e => e.PilotId == Id);
        }

    }
}

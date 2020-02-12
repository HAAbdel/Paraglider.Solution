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
                new Pilot() {PilotId =1, FirstName="yves",LastName="blavier",Email="yblavier@hotmail.com",PhoneNumber="0474082325",Weight = 70 },
                 new Pilot() {PilotId =2, FirstName="Billy",LastName="Thekid",Email="Billythekid@hotmail.com",PhoneNumber="066666666",Weight = 69 },
                 new Pilot() {PilotId =2, FirstName="Bou",LastName="boule",Email="bouboule@hotmail.com",PhoneNumber="066666666",Weight = 69 }

            };
        }

        public IEnumerable<Pilot> GetAllPilot()
        {
            return _PilotList;
        }

    
 
       public IEnumerable<Pilot>GetPilotByName(string Name)
        {
            if (Name == null)
            {
                return _PilotList;
            }
            else
            {
              
                return _PilotList.FindAll(e => e.LastName.ToLower().Contains(Name.ToLower()));
            }
           
        }
    }
}

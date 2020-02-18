using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paraglider.sl
{
    public interface IPilotData 
    {
        IEnumerable<Pilot> GetAllPilots();
    }
    public class InMemoryPilotData : IPilotData
    {
        private readonly List<Pilot> _PilotList;

        public InMemoryPilotData()
        {
            _PilotList = new List<Pilot>()
            {
                new Pilot() {PilotId =1, FirstName="yves",LastName="blavier",Email="yblavier@hotmail.com",PhoneNumber="0474082325",Weight = 70 },
                 new Pilot() {PilotId =2, FirstName="Billy",LastName="Thekid",Email="Billythekid@hotmail.com",PhoneNumber="066666666",Weight = 69 },
                 new Pilot() {PilotId =3, FirstName="Bou",LastName="boule",Email="bouboule@hotmail.com",PhoneNumber="066666666",Weight = 69 }

            };
        }

  

        public IEnumerable<Pilot> GetAllPilots()
        {
            
        }
    }
}

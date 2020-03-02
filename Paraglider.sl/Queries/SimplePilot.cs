using Paraglider.DAL;
using Paraglider.DAL.Models;
using Paraglider.sl.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paraglider.sl.Queries
{
    public class SimplePilot
    {
        private readonly ParagliderContext _config;

        public SimplePilot( ParagliderContext config)
        {
            _config = config;
        }
        public IEnumerable<PilotDto> GetAllPilots()
        {
            var Pilots = _config.Pilots.Select(p => new PilotDto { FirstName = p.FirstName, LastName = p.LastName, Id = p.PilotId });

            return Pilots;
        }
        public IEnumerable<PilotDto> GetPilotByName(string SearchedName)
        {
            var Pilots = _config.Pilots.Select(p => new PilotDto 
                {
                    FirstName = p.FirstName, 
                    LastName = p.LastName, 
                    Id = p.PilotId 
                }).Where(p => p.LastName.Contains(SearchedName)||p.FirstName.Contains(SearchedName));

            return Pilots;
        }

    }
}

using Paraglider.DAL;
using Paraglider.sl.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paraglider.sl.Queries
{
    class DetailedPilot
    {
        private readonly ParagliderContext _config;

        public DetailedPilot(ParagliderContext config)
        {
            _config = config;
        }
        public IQueryable<PilotDetailDto> GetSpecific()
        {
            var Pilot = _config.Pilots.Select(p => new PilotDetailDto { Id = p.PilotId, FirstName = p.FirstName, LastName = p.LastName, PhoneNumber = p.PhoneNumber, Email = p.Email, Weight = p.Weight });
            return Pilot;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Paraglider.DAL;
using Paraglider.sl.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paraglider.sl.Queries
{
    class SimpleParaglider
    {
        private readonly ParagliderContext _context;

        public SimpleParaglider(ParagliderContext context)
        {
            _context = context;
        }
        public IEnumerable<ParagliderDTO> GetAllAvalableParagliders()
        {
            IEnumerable<ParagliderDTO> paragliders = _context.Paragliders.Select(p => new ParagliderDTO()
            {
                Id = p.ParagliderId,
                TotalHoursFlight = p.FlightHours,
                ParagliderModelName = p.ParagliderModel.ModelName,
                ParagliderModelId = p.ParagliderModelId
            });
            return paragliders;
        }
        public IEnumerable<ParagliderDTO> GetAllParagliders()
        {
            IEnumerable<ParagliderDTO> paragliders = _context.Paragliders.Select(p => new ParagliderDTO()
            {
                Id = p.ParagliderId,
                TotalHoursFlight = p.FlightHours,
                ParagliderModelName = p.ParagliderModel.ModelName,
                ParagliderModelId = p.ParagliderModelId
            }).IgnoreQueryFilters();
            return paragliders;
        }
    }
}

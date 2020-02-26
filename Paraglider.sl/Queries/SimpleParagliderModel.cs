using Paraglider.DAL;
using Paraglider.DAL.Models;
using Paraglider.sl.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paraglider.sl.Queries
{
    class SimpleParagliderModel
    {
        private readonly ParagliderContext _context;
        public SimpleParagliderModel(ParagliderContext context)
        {
            _context = context;
        }
        public IEnumerable<ParagliderModelDTO> GetAllAvalabelParagliderModels ()
        {
            var ParagliderModels = _context.ParagliderModels.Select(pc => new ParagliderModelDTO()
            {
                Id = pc.ParagliderModelId,
                ModelName = pc.ModelName,
                ModelType = pc.ModelType
            });

            return ParagliderModels;
        }
    }
}

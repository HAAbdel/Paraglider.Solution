using Paraglider.DAL;
using System;
using System.Collections.Generic;
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
        //public IEnumerable<DTOs.ParagliderDTO> GetAllAvalaibleParagliders()
        //{
        //    var Paragliders = _context.Paragliders
            
        //}
    }
}

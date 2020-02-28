using Paraglider.DAL;
using Paraglider.sl.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paraglider.sl.Queries
{
    public class DetailedParagliderModel
    {
        private readonly ParagliderContext _context;

        public DetailedParagliderModel(ParagliderContext context)
        {
            _context = context;
        }
        public ParagliderModelDetailDTO getSpecificParagliderModel(int SearchId)
        {
            ParagliderModelDetailDTO paragliderModelDetailDTO = _context.ParagliderModels
                .Where(pdm => pdm.ParagliderModelId == SearchId).Select(pdm => new ParagliderModelDetailDTO()
                {
                    Id = pdm.ParagliderModelId,
                    ModelName = pdm.ModelName,
                    ModelType = pdm.ModelType,
                    MaximumWeight = pdm.MaximumWeight,
                    MinimalWeight = pdm.MinimalWeight,
                    DateOfHomologation = pdm.DateOfHomologation,
                    NumberOfHomologation = pdm.NumberOfHomologation,
                    Size = pdm.Size,
                    NumberOfThisModel = pdm.Paragliders.Count()
                }).First();

            return paragliderModelDetailDTO;
        }
    }
}

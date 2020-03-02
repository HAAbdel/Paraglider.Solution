using Paraglider.DAL;
using Paraglider.sl.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paraglider.sl.Queries
{
    public class DetailedParaglider
    {
        private readonly ParagliderContext _config;

        public DetailedParaglider(ParagliderContext config)
        {
            _config = config;
        }
        public ParagliderDetailDTO GetSpecificParagliderWithSimpleModel(int SerchedId)
        {
            ParagliderDetailDTO paragliderDetailDTO = _config.Paragliders
                .Where(pi => pi.ParagliderId == SerchedId)
                .Select(pd => new ParagliderDetailDTO
                {
                    Id = pd.ParagliderId,
                    DateOfService = pd.DateOfService,
                    DateOfUse = pd.DateOfUse,
                    FlightHours = pd.FlightHours,
                    paragliderModel = _config.ParagliderModels.Where(pdm => pdm.ParagliderModelId == pd.ParagliderModelId).Select(pdm => new ParagliderModelDTO()
                    {
                        Id = pdm.ParagliderModelId,
                        ModelName = pdm.ModelName,
                        ModelType = pdm.ModelType
                    }).First()
                }).First();
            return paragliderDetailDTO;
        }

	}
}

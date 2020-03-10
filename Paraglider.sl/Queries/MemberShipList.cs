using Microsoft.EntityFrameworkCore;
using Paraglider.DAL;
using Paraglider.sl.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paraglider.sl.Queries
{
    public class MemberShipList
    {
        private readonly ParagliderContext _config;

        public MemberShipList(ParagliderContext config)
        {
            _config = config;
        }
        public MemberShipDto GetSpecific(int SearchedId)
        {
            MemberShipDto MemberShipDto = _config.Memberships.Select(MS => new MemberShipDto()
            {
                id = MS.MembershipId,
                membershipAmount = MS.MembershipAmount,
                numberOfSubscribers = MS.PilotMemberships.Count()
            }).Where(K => K.id == SearchedId).First();

            return MemberShipDto;
        }
        public IQueryable<MemberShipDto> GetAllAvalable()
        {
            IQueryable<MemberShipDto> memberShipDtos = _config.Memberships.Select(MS => new MemberShipDto()
            {
                id = MS.MembershipId,
                membershipAmount = MS.MembershipAmount,
                numberOfSubscribers = MS.PilotMemberships.Count()
            }).IgnoreQueryFilters();

            return memberShipDtos;
        }
    }
}

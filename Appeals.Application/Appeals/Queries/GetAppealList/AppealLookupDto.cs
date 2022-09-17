using System;
using AutoMapper;
using Appeals.Domain;
using Appeals.Application.Commons.Mappings;

namespace Appeals.Application.Appeals.Queries.GetAppealList
{
    public class AppealLookupDto : IMapWith<Appeal>
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string TypeName { get; set; } 

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Appeal, AppealLookupDto>()
                .ForMember(appealDto => appealDto.Id,
                    opt => opt.MapFrom(appeal => appeal.Id))
                .ForMember(appealDto => appealDto.Message,
                    opt => opt.MapFrom(appeal => appeal.Message))
                .ForMember(appealDto => appealDto.TypeName,
                    opt => opt.MapFrom(appeal => appeal.Type.Name));
        }

    }
}

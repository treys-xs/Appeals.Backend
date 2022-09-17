using System;
using AutoMapper;
using Appeals.Domain;
using Appeals.Application.Commons.Mappings;

namespace Appeals.Application.AppealTypes.Queries.GetAppealTypeList
{
    public class AppealTypeDto : IMapWith<AppealType>
    {
        public Guid Id { get; set; }
        public string TypeName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AppealType, AppealTypeDto>()
                .ForMember(appealTypeDto => appealTypeDto.Id,
                opt => opt.MapFrom(appealType => appealType.Id))
                .ForMember(appealTypeDto => appealTypeDto.TypeName,
                opt => opt.MapFrom(appealType => appealType.Name));
        }
    }
}

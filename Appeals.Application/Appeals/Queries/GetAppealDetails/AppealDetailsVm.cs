using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Appeals.Application.Commons.Mappings;
using Appeals.Domain;

namespace Appeals.Application.Appeals.Queries.GetAppealDetails
{
    public class AppealDetailsVm : IMapWith<Appeal>
    {   
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string TypeName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Appeal, AppealDetailsVm>()
                .ForMember(appealVm => appealVm.Id,
                opt => opt.MapFrom(appeal => appeal.Id))
                .ForMember(appealVm => appealVm.Message,
                opt => opt.MapFrom(appeal => appeal.Message))
                .ForMember(appealVm => appealVm.Email,
                opt => opt.MapFrom(appeal => appeal.Email))
                .ForMember(appealVm => appealVm.PhoneNumber,
                opt => opt.MapFrom(appeal => appeal.PhoneNumber))
                .ForMember(appealVm => appealVm.TypeName,
                opt => opt.MapFrom(appeal => appeal.Type.Name));
        }

    }
}

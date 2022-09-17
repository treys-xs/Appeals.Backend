using System;
using MediatR;

namespace Appeals.Application.AppealTypes.Commands.CreateAppealType
{
    public class CreateAppealTypeCommand : IRequest<Guid>
    {
        public string TypeName { get; set; }
    }
}

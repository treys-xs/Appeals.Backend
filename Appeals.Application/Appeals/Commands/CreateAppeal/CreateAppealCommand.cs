using System;
using MediatR;

namespace Appeals.Application.Appeals.Commands.CreateAppeal
{
    public class CreateAppealCommand : IRequest<Guid>
    {
        public string Message { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string TypeName { get; set; }
    }
}

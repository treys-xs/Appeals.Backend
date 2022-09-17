using System;
using MediatR;

namespace Appeals.Application.AppealTypes.Commands.DeleteAppealType
{
    public class DeleteAppealTypeCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}

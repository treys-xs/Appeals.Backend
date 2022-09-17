using System;
using MediatR;

namespace Appeals.Application.Appeals.Commands.DeleteAppeal
{
    public class DeleteAppealCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}

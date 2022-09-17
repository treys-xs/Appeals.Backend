using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Appeals.Application.Interfaces;
using Appeals.Application.Commons.Exceptions;
using Appeals.Domain;

namespace Appeals.Application.Appeals.Commands.CreateAppeal
{
    public class CreateAppealCommandHandler : IRequestHandler<CreateAppealCommand, Guid>
    {
        private readonly IAppealsDbContext _dbContext;
        public CreateAppealCommandHandler(IAppealsDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateAppealCommand request, CancellationToken cancellationToken)
        {
            var typeAppeal = await
                _dbContext.AppealTypes
                .FirstOrDefaultAsync(type => type.Name == request.TypeName, cancellationToken);

            if(typeAppeal == null)
            {
                throw new NotFoundException();
            }

            var appeal = new Appeal
            {
                Id = Guid.NewGuid(),
                Message = request.Message,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                CreationDate = DateTime.Now,
                Type = typeAppeal
            };

            await _dbContext.Appeals.AddAsync(appeal, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return appeal.Id;
        }
    }
}

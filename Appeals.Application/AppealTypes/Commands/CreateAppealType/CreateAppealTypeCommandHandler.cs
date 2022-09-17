using System;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using Appeals.Domain;
using Appeals.Application.Interfaces;

namespace Appeals.Application.AppealTypes.Commands.CreateAppealType
{
    public class CreateAppealTypeCommandHandler : IRequestHandler<CreateAppealTypeCommand, Guid>
    {
        private readonly IAppealsDbContext _dbContext;

        public CreateAppealTypeCommandHandler(IAppealsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateAppealTypeCommand request, CancellationToken cancellationToken)
        {
            var appealType = new AppealType
            {
                Id = Guid.NewGuid(),
                Name = request.TypeName
            };

            await _dbContext.AppealTypes.AddAsync(appealType, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return appealType.Id;
        }
        
    }
}

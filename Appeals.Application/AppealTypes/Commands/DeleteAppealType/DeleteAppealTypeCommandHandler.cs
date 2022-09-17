using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Appeals.Application.Interfaces;
using Appeals.Application.Commons.Exceptions;

namespace Appeals.Application.AppealTypes.Commands.DeleteAppealType
{
    public class DeleteAppealTypeCommandHandler : IRequestHandler<DeleteAppealTypeCommand>
    {
        private readonly IAppealsDbContext _dbContext;

        public DeleteAppealTypeCommandHandler(IAppealsDbContext dbContext) =>
            _dbContext = dbContext;
        
        public async Task<Unit> Handle(DeleteAppealTypeCommand request, CancellationToken cancellationToken)
        {
            var appealType = await
                _dbContext.AppealTypes
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (appealType == null)
            {
                throw new NotFoundException();
            }

            _dbContext.AppealTypes.Remove(appealType);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

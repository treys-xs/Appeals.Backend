using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Appeals.Application.Interfaces;
using Appeals.Application.Commons.Exceptions;

namespace Appeals.Application.Appeals.Commands.DeleteAppeal
{
    public class DeleteAppealCommandHandler : IRequestHandler<DeleteAppealCommand>
    {
        private readonly IAppealsDbContext _dbContext;

        public DeleteAppealCommandHandler(IAppealsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteAppealCommand request, CancellationToken cancellationToken)
        {
            var appeal = await 
                _dbContext.Appeals
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if(appeal == null)
            {
                throw new NotFoundException();
            }

            _dbContext.Appeals.Remove(appeal);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
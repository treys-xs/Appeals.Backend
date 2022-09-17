using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using FluentValidation;

namespace Appeals.Application.Commons.Behaviors
{
    public class ValidationBahavior<TRequest, TResponse> 
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBahavior(IEnumerable<IValidator<TRequest>> validators) =>
            _validators = validators;
        

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(failures => failures != null)
                .ToList();

            if(failures.Count != 0)
            {
                throw new ValidationException(failures);
            }

            return next();
        }
    }
}

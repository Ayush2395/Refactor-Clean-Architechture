using FluentValidation;
using MediatR;
using ValidationExcep = Application.Common.Exceptions.ValidationException;

namespace Application.Common.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var result = await Task
                    .WhenAll(_validators.Select(x => x.ValidateAsync(context)));

                var failures = result
                    .Where(x => x.Errors.Any())
                    .SelectMany(x => x.Errors)
                    .ToList();
                if (failures.Any())
                {
                    throw new ValidationExcep(failures);
                }
            }
            return await next();
        }
    }
}

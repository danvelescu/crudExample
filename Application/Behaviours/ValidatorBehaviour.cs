using FluentValidation;
using MediatR;

namespace crudExample.Application.Behaviours
{
    public class ValidatorBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidatorBehaviour(IEnumerable<IValidator<TRequest>> validators) {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
                if (_validators.Any()) {
                var context = new ValidationContext<TRequest>(request);

                var validatorResult = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context,cancellationToken)));
                var failures = validatorResult.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Any()) {
                    throw new ValidationException(failures);
                }
            }
            return await next();
        }
    }
}

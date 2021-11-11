using crudExample.Infrastructure.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace crudExample.Application.Users.Commands
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        private ApplicationDbContext _applicationDbContext;
        public UpdateUserCommandValidator(ApplicationDbContext application)
        {
            _applicationDbContext = application;

            RuleFor(x => x.User.Id)
                .MustAsync(UserIdShouldExist)
                .WithMessage(u => $"User with id ={u.User.Id} not exists in db");
        }

        private async Task<bool> UserIdShouldExist(int id, CancellationToken cancellationToken)
        {
            return await _applicationDbContext.Users.AnyAsync(u => u.Id == id, cancellationToken);
        }
    }
}

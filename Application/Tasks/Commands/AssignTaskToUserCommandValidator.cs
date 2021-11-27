using crudExample.Application.Users.Commands;
using crudExample.Infrastructure.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudExample.Application.Tasks.Commands
{
    public class AssignTaskToUserCommandValidator : AbstractValidator<AssignTaskToUserCommand>
    {
        private ApplicationDbContext _applicationDbContext;
        public AssignTaskToUserCommandValidator(ApplicationDbContext context)
        {
            _applicationDbContext = context;

            RuleFor(x => x.UserId)
                .MustAsync(UserIdShouldExist)
                .WithMessage(u => $"User with id ={u.UserId} not exists in db");
            RuleFor(x => x.TaskId)
                .MustAsync(TaskIdShouldExist)
                .WithMessage(u => $"Task with id ={u.TaskId} not exists in db");
        }

        private async Task<bool> UserIdShouldExist(int id, CancellationToken cancellationToken)
        {
            return await _applicationDbContext.Users.AnyAsync(u => u.Id == id, cancellationToken);
        }
        private async Task<bool> TaskIdShouldExist(int id, CancellationToken cancellationToken)
        {
            return await _applicationDbContext.UserTasks.AnyAsync(u => u.Id == id, cancellationToken);
        }
    }
}

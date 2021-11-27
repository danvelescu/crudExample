using crudExample.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace crudExample.Application.Tasks.Commands
{
    public class AssignTaskToUserCommand : IRequest<bool>
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }
    }
    public class AssignTaskToUserCommandHandler : IRequestHandler<AssignTaskToUserCommand, bool>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public AssignTaskToUserCommandHandler(ApplicationDbContext applicationDb)
        {
            _applicationDbContext = applicationDb;
        }

        public async Task<bool> Handle(AssignTaskToUserCommand request, CancellationToken cancellationToken)
        {
            var task = await _applicationDbContext.UserTasks.FirstOrDefaultAsync(x => x.Id == request.TaskId, cancellationToken);
            task.AssignToUserId = request.UserId;
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}

using crudExample.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace crudExample.Application.Users.Queries
{
    public class DeleteUserByIdCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteUserByIdQueryHandler : IRequestHandler<DeleteUserByIdCommand, bool>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public DeleteUserByIdQueryHandler(ApplicationDbContext application) {
            _applicationDbContext = application;

        }
        public async Task<bool> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
            _applicationDbContext.Users.Remove(user);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return true; 
        }
    }
}

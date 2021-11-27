using crudExample.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudExample.Application.Tasks.Commands
{
    public class DeleteTaskByIdCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteTaskByIdHandler : IRequestHandler<DeleteTaskByIdCommand, bool>
    {
        private ApplicationDbContext _applicationDbContext;

        public DeleteTaskByIdHandler(ApplicationDbContext application)
        {
            _applicationDbContext = application;
        }

        public async Task<bool> Handle(DeleteTaskByIdCommand request, CancellationToken cancellationToken)
        {
            var task = await _applicationDbContext.UserTasks.FirstOrDefaultAsync(x => x.Id == request.Id,cancellationToken);
            _applicationDbContext.UserTasks.Remove(task);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}

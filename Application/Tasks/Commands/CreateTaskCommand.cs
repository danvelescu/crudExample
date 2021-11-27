

using AutoMapper;
using crudExample.Domain.Enums;
using crudExample.Domain.Models;
using crudExample.Infrastructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace crudExample.Application.Tasks.Commands
{
    public class CreateTaskCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskPriority TaskPriority { get; set; }
    }

    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public CreateTaskCommandHandler(ApplicationDbContext application,IMapper mapper)
        {
            _applicationDbContext = application;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = _mapper.Map<UserTask>(request);
            _applicationDbContext.Add(task);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return task.Id;
        }
    }
}

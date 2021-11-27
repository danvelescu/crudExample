using AutoMapper;
using AutoMapper.QueryableExtensions;
using crudExample.Application.Tasks.Dto;
using crudExample.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace crudExample.Application.Tasks.Quries
{
    public class GetTaskByIdQuery : IRequest<TaskDto>
    {
        public int Id { get; set; }
    }

    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, TaskDto>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetTaskByIdQueryHandler(ApplicationDbContext application, IMapper mapper)
        {
            _applicationDbContext = application;
            _mapper = mapper;
        }
        public async Task<TaskDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = _mapper.Map<TaskDto>(await _applicationDbContext.UserTasks
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken));
            return task;
        }
    }

}

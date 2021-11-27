using AutoMapper;
using AutoMapper.QueryableExtensions;
using crudExample.Application.Tasks.Dto;
using crudExample.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudExample.Application.Tasks.Quries
{
    public class GetTasksByUserIdQuery : IRequest<List<TaskDto>>
    {
        public int UserId { get; set; }
    }

    public class GetTasksByUserIdQueryHandler : IRequestHandler<GetTasksByUserIdQuery, List<TaskDto>>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public GetTasksByUserIdQueryHandler(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<List<TaskDto>> Handle(GetTasksByUserIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _applicationDbContext.UserTasks
                .AsQueryable()
                .Where(x => x.AssignToUserId == request.UserId)
                .ProjectTo<TaskDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return task;
        }
    }
}

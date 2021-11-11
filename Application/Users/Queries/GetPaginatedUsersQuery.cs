using AutoMapper;
using AutoMapper.QueryableExtensions;
using crudExample.Application.Users.Dto;
using crudExample.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace crudExample.Application.Users.Queries
{
    public class GetPaginatedUsersQuery : IRequest<List<UserDto>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
    public class UserGetByPaginationQueryHandler : IRequestHandler<GetPaginatedUsersQuery, List<UserDto>>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public UserGetByPaginationQueryHandler(ApplicationDbContext application, IMapper mapper)
        {
            _applicationDbContext = application;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> Handle(GetPaginatedUsersQuery request, CancellationToken cancellationToken)
        {
            var results = await _applicationDbContext.Users.ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .Skip((request.PageNumber - 1)  * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);
            return results;
        }
    }
}

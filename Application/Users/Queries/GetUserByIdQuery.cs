using AutoMapper;
using AutoMapper.QueryableExtensions;
using crudExample.Application.Users.Dto;
using crudExample.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace crudExample.Application.Users.Queries
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int UserId { set; get; }
    }

    public class GetUserQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(ApplicationDbContext application, IMapper mapper)
        {
            _applicationDbContext = application;
            _mapper = mapper;
        }

       public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _applicationDbContext.Users
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

            return user;
        }
    }
}

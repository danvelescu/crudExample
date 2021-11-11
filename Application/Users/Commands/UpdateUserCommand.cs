using AutoMapper;
using crudExample.Application.Users.Dto;
using crudExample.Domain.Models;
using crudExample.Infrastructure.Persistence;
using MediatR;

namespace crudExample.Application.Users.Commands
{
    public class UpdateUserCommand : IRequest<UserDto>
    {
        public UserDto User { get; set; }
    }

    public class UpdateUserCommandHanler : IRequestHandler<UpdateUserCommand, UserDto>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public UpdateUserCommandHanler(ApplicationDbContext applicationDbContext, IMapper mapper) { 
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User user = _mapper.Map<User>(request.User);
            _applicationDbContext.Update(user);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return request.User;
        }
    }
}

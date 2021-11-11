using AutoMapper;
using crudExample.Domain.Models;
using crudExample.Infrastructure.Persistence;
using MediatR;

namespace crudExample.Application.Users.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _applicationDbContext = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            _applicationDbContext.Add(user);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}

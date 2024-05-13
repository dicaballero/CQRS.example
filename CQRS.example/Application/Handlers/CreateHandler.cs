using CQRS.example.Infraestructure.Commands;
using dcaba.users.Models;
using MediatR;

namespace CQRS.example.Application.Handlers
{
    public class CreateHandler : IRequestHandler<CreateUserCommand, UserDTO>
    {


        private readonly CQRSContext _dbContext;

        public CreateHandler(CQRSContext dbctx)
        {
            _dbContext = dbctx;
        }

        public async Task<UserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var item = new User
            {
                UsrName = request.UsrName,
                UsrPassword = request.UsrPassword
            };

            _dbContext.Add(item);
            _dbContext.SaveChangesAsync();

            return new UserDTO
            {
                UsrName = item.UsrName,
                UsrPassword = item.UsrPassword
            };


        }
    }
}

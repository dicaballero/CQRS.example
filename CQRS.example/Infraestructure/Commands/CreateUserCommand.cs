using dcaba.users.Models;
using MediatR;

namespace CQRS.example.Infraestructure.Commands
{
    public record CreateUserCommand(string UsrName, string UsrPassword) : IRequest<UserDTO>{}

}

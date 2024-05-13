using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dcaba.users.Models;
using MediatR;
using CQRS.example.Infraestructure.Commands;

namespace dcaba.users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mdtr)
        {
            _mediator = mdtr;
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser(CreateUserCommand command)
        {
            var item = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateUserCommand),new { id = item.Id, item});
        }



    }
}

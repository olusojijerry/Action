using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actio.Common.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace Actio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
		private readonly IBusClient _bus;
		public UsersController(IBusClient bus)
		{
			_bus = bus;
		}

		[HttpPost("register")]
		public async Task<ActionResult> Post([FromBody]CreateUser command)
		{
			await _bus.PublishAsync(command);

			return Accepted($"");
		}
	}
}
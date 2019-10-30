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
    public class ActivitiesController : ControllerBase
    {
		private readonly IBusClient _bus;
		public ActivitiesController(IBusClient bus)
		{
			_bus = bus;
		}

		[HttpPost("")]
		public async Task<ActionResult> Post([FromBody]CreateActivity command)
		{
			command.Id = Guid.NewGuid();
			command.CreatedAt = DateTime.UtcNow;

			await _bus.PublishAsync(command);

			return Accepted($"activities/{command.Id}");
		}
    }
}
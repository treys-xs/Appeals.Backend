using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Appeals.Application.Appeals.Commands.CreateAppeal;
using Appeals.Application.Appeals.Commands.DeleteAppeal;
using Appeals.Application.Appeals.Queries.GetAppealList;
using Appeals.Application.Appeals.Queries.GetAppealDetails;

namespace Appeals.WebApi.Controllers
{
    public class AppealController : BaseController
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<AppealListVm>> GetAll()
        {
            var query = new GetAppealListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<AppealDetailsVm>> Get(Guid id)
        {
            var query = new GetAppealDeatailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAppealCommand command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteAppealCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}

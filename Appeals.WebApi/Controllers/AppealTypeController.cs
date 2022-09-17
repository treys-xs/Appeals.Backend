using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Appeals.Application.AppealTypes.Commands.CreateAppealType;
using Appeals.Application.AppealTypes.Commands.DeleteAppealType;
using Appeals.Application.AppealTypes.Queries.GetAppealTypeList;

namespace Appeals.WebApi.Controllers
{
    public class AppealTypeController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<AppealTypeListVm>> GetAll()
        {
            var query = new GetAppealTypeListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost("{typeName}")]
        public async Task<ActionResult<Guid>> Create(string typeName)
        {
            var command = new CreateAppealTypeCommand
            {
                TypeName = typeName
            };
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteAppealTypeCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}

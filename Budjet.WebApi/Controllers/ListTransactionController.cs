using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Budjet.Application.Budjet.Commands.CreateListTransaction;
using Budjet.Application.Budjet.Commands.DeleteListTransaction;
using Budjet.Application.Budjet.Commands.UpdateListTransaction;
using Budjet.Application.Budjet.Queries.GetListTransaction;
using AutoMapper;
using Budjet.Application.Budjet.Queries.GetAllListTransaction;

namespace Budjet.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ListTransactionController: BaseController
    {
        private readonly IMapper _mapper;

        public ListTransactionController(IMapper mapper) => _mapper = mapper;
        /// <summary>
        /// Get All List Transaction
        /// </summary>
        [HttpGet("{userId}")]
        public async Task<ActionResult<AllListTransactionVm>> GetAll(Guid userId)
        {
            var query = new GetAllListTransactionQuery
            {
                UserId = userId
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Get List Transaction
        /// </summary>
        [HttpGet("{userId}/{listTransactionId}")]
        public async Task<ActionResult<ListTransactionVm>> Get(Guid userId, Guid listTransactionId)
        {
            var query = new GetListTransactionQuery
            {
                UserId = userId,
                ListTransactionId = listTransactionId
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Create List Transaction
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateListTransactionCommand command)
        {
            var listTransactionId = await Mediator.Send(command);
            return Ok(listTransactionId);
        }

        /// <summary>
        /// Update List Transaction
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateListTransactionCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete List Transaction
        /// </summary>
        [HttpDelete("{userId}/{listTransactionId}")]
        public async Task<IActionResult> Delete(Guid userId, Guid listTransactionId)
        {
            var command = new DeleteListTransactionCommand
            {
                UserId = userId,
                ListTransactionId = listTransactionId
            };
            await Mediator.Send(command);

            return NoContent();
        }
    }
}

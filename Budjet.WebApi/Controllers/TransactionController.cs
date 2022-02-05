using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Budjet.Application.Budjet.Commands.CreateExpenses;
using Budjet.Application.Budjet.Commands.CreateIncome;
using Budjet.Application.Budjet.Commands.DeleteTransaction;
using Budjet.Application.Budjet.Commands.UpdateTransaction;

namespace Budjet.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TransactionController: BaseController
    {
        /// <summary>
        /// Add income
        /// </summary>
        [HttpPost("income")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateIncomeCommand command)
        {
            var transactionId = await Mediator.Send(command);
            return Ok(transactionId);
        }

        /// <summary>
        /// Add expenses
        /// </summary>
        [HttpPost("expenses")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateExpensesCommand command)
        {
            var transactionId = await Mediator.Send(command);
            return Ok(transactionId);
        }

        /// <summary>
        /// Update Transaction
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTransactionCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete Transaction
        /// </summary>
        [HttpDelete("{userId}/{listTransactionId}/{transactionId}")]
        public async Task<IActionResult> Delete(Guid userId, Guid listTransactionId, Guid transactionId)
        {
            var command = new DeleteTransactionCommand
            {
                UserId = userId,
                ListTransactionId = listTransactionId,
                TransactionId = transactionId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}

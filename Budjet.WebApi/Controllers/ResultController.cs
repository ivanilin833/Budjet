using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Budjet.Application.Budjet.Queries.GetTransactionOnDate;
using Budjet.Application.Budjet.Queries.GetTransactionsPerMonth;
using Microsoft.AspNetCore.Authorization;

namespace Budjet.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ResultController: BaseController
    {
        /// <summary>
        /// Get Transaction on date
        /// </summary>
        [HttpGet("{userId}/{onDate}")]
        public async Task<ActionResult<TransactionOnDateVm>> GetOnDate(Guid userId, DateTime onDate)
        {
            var query = new GetTransactionOnDateQuery
            {
                UserId = userId,
                OnDate = onDate
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Get Transaction per month
        /// </summary>
        [HttpGet("{userId}/{startDate}/{endDate}")]
        public async Task<ActionResult<TransactionOnDateVm>> GetPerMonth(Guid userId, DateTime startDate, DateTime endDate)
        {
            var query = new GetTransactionPerMonthQuery
            {
                UserId = userId,
                StartDate = startDate,
                EndDate = endDate
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

    }
}

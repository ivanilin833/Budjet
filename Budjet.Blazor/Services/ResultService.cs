using Budjet.Blazor.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Budjet.Blazor.Services
{
    public class ResultService:BaseService
    {
        private readonly AuthenticationStateProvider _authState;

        public ResultService(AuthenticationStateProvider authState) : base(authState)
        {
            _authState = authState;
        }

        public ResultModel result;
        public DateTime date = DateTime.Today;
        public DateTime dateStart = DateTime.Today.AddDays(-1);
        public DateTime dateEnd = DateTime.Today;
        public string errorMessge;
        public async Task TransactionOnDate()
        {
            var userId = Guid.Parse(await GetUserId());
            string Url = $"https://localhost:44373/api/Result/{userId}/{date.ToString("MM.dd.yyyy")}";
            var transactionOnDate = new WebClient().DownloadString(Url);
            var resultDownload = JsonConvert.DeserializeObject<ResultModel>(transactionOnDate);
            result = resultDownload;
        }

        public async Task TransactionPerMonth()
        {
            var userId = Guid.Parse(await GetUserId());
            if (dateEnd <= dateStart)
            {
                result = new ResultModel();
            }
            else
            {
                string Url = $"https://localhost:44373/api/Result/{userId}/{dateStart.ToString("MM.dd.yyyy")}/{dateEnd.ToString("MM.dd.yyyy")}";
                var transactionOnDate = new WebClient().DownloadString(Url);
                var resultDpwnload = JsonConvert.DeserializeObject<ResultModel>(transactionOnDate);
                result = resultDpwnload;
            }
           
        }
    }
}

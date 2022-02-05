using Budjet.Blazor.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Linq;

namespace Budjet.Blazor.Services
{
    public class CRUDService : BaseService
    {
        private readonly AuthenticationStateProvider _authState;

        public CRUDService(AuthenticationStateProvider authState):base(authState)
        {
            _authState = authState;
        }

        public AllListTransactionModel allList;
        public ListTransactionModel listTransaction;
        public TransactionModel transaction;
        public string deleteMessage;

        public async Task GetAllListTransaction()
        {
            var userId = Guid.Parse(await GetUserId());
            string Url = $"https://localhost:44373/api/ListTransaction/{userId}";
            var allListTransaction = new WebClient().DownloadString(Url);
            var listTransaction = JsonConvert.DeserializeObject<AllListTransactionModel>(allListTransaction);
            allList = listTransaction;
        }

        public async Task DeleteListTransaction(Guid listTransactionid)
        {
            using var client = new HttpClient();
            var userId = Guid.Parse(await GetUserId());
            client.BaseAddress = new Uri("http://localhost:44378//");
            await GetListTransaction(listTransactionid.ToString());
            if (listTransaction.Income.Count==0 && listTransaction.Expenses.Count == 0)
            {
                HttpResponseMessage response = await client.DeleteAsync($"https://localhost:44373/api/ListTransaction/{userId}/{listTransactionid}");

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Sucsesfully posted a command");
                }

                deleteMessage = "Список успешно удалён";
            }
            else
            {
                deleteMessage = "Этот список не пустой, его нельзя удалить!";
            }
            
        }

        public async Task CreateListTransaction(ListTransactionModel listTransaction)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:44378//");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            listTransaction.UserId = Guid.Parse(await GetUserId());

            HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:44373/api/ListTransaction", listTransaction);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Sucsesfully posted a command");
            }
        }

        public async Task EditListTransaction(ListTransactionModel listTransaction, string listTransactionId)
        {

            using var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:44378//");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            listTransaction.UserId = Guid.Parse(await GetUserId());
            listTransaction.ListTransactionId = Guid.Parse(listTransactionId);
            HttpResponseMessage response = await client.PutAsJsonAsync("https://localhost:44373/api/ListTransaction", listTransaction);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Sucsesfully posted a command");
            }
        }

        public async Task DeleteTransaction(Guid listTransactionid, Guid transactionId)
        {
            using var client = new HttpClient();
            var userId = Guid.Parse(await GetUserId());
            client.BaseAddress = new Uri("http://localhost:44378//");

            HttpResponseMessage response = await client.DeleteAsync($"https://localhost:44373/api/Transaction/{userId}/{listTransactionid}/{transactionId}");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Sucsesfully posted a command");
            }
        }

        public async Task GetListTransaction(string listTransactionId)
        {
            var userId = Guid.Parse(await GetUserId());
            string Url = $"https://localhost:44373/api/ListTransaction/{userId}/{listTransactionId}";
            var lListTransactionDownload = new WebClient().DownloadString(Url);
            var listTransact = JsonConvert.DeserializeObject<ListTransactionModel>(lListTransactionDownload);

            listTransaction = listTransact;
        }

        public async Task CreateTransaction(TransactionModel transaction, string listTransactionId, string typeTransaction)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:44378//");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            transaction.ListTransactionId = Guid.Parse(listTransactionId);

            HttpResponseMessage response = await client.PostAsJsonAsync($"https://localhost:44373/api/Transaction/{typeTransaction}", transaction);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Sucsesfully posted a command");
            }
        }

        public async Task EditTransaction(TransactionModel transaction, string listTransactionId, string transactionId)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:44378//");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            transaction.UserId = Guid.Parse(await GetUserId());
            transaction.ListTransactionId = Guid.Parse(listTransactionId);
            transaction.TransactionId = Guid.Parse(transactionId);
            HttpResponseMessage response = await client.PutAsJsonAsync("https://localhost:44373/api/Transaction", transaction);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Sucsesfully posted a command");
            }
        }

        public async Task GetTransaction(string listTransactionId, string transactionId)
        {
            await GetListTransaction(listTransactionId);
            transaction = listTransaction.Income.Where(x => x.TransactionId == Guid.Parse(transactionId)).FirstOrDefault();

            if (transaction is null)
            {
                transaction = listTransaction.Expenses.Where(x => x.TransactionId == Guid.Parse(transactionId)).First();
            }
        }
    }
}

using ModernHttpClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Punchclock;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace XamFormsEfficientNetworking.Models
{
    public class DataService
    {
        private readonly OperationQueue _opQueue = new OperationQueue(2);
        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
        const string OrdersUrl = "https://api.parse.com/1/classes/Order";
        const string ItemsUrl = "https://api.parse.com/1/classes/Item";

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient(new NativeMessageHandler());
            client.DefaultRequestHeaders.Add("X-Parse-Application-Id", "fwpMhK1Ot1hM9ZA4iVRj49VFzDePwILBPjY7wVFy");
            client.DefaultRequestHeaders.Add("X-Parse-REST-API-Key", "egeLQVTC7IsQJGd8GtRj3ttJVRECIZgFgR2uvmsr");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(int skip = 0)
        {
            using (HttpClient client = GetClient())
            {
                Dictionary<string, string> values = new Dictionary<string, string>()
                {
                    { "skip", skip.ToString() }
                };
                FormUrlEncodedContent encodedContent = new FormUrlEncodedContent(values);
                string param = await encodedContent.ReadAsStringAsync().ConfigureAwait(false);
                HttpResponseMessage httpResponseMessage = 
                    await _opQueue.Enqueue(10, () => client.GetAsync(OrdersUrl + "?" + param)).ConfigureAwait(false);
                httpResponseMessage.EnsureSuccessStatusCode();
                string content = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                JObject jsonObject = JObject.Parse(content);
                string ordersJson = jsonObject["results"].ToString();
                IEnumerable<Order> orders = JsonConvert.DeserializeObject<IEnumerable<Order>>(ordersJson);
                List<Task> tasks = new List<Task>();
                foreach (Order order in orders)
                {
                    tasks.Add(GetItemsByOrderNumberAsync(order.OrderNumber).ContinueWith((antecedent) =>
                    {
                        order.Items = new List<Item>(antecedent.Result);
                    }));
                }
                await Task.WhenAll(tasks).ConfigureAwait(false);
                return orders;
            }
        }

        public async Task<IEnumerable<Item>> GetItemsByOrderNumberAsync(string orderNumber)
        {
            using (HttpClient client = GetClient())
            {
                string orderNumberJson = "{\"orderNumber\": \"" + orderNumber + "\"}";
                Dictionary<string, string> values = new Dictionary<string, string>()
                {
                    { "where", orderNumberJson }
                };
                FormUrlEncodedContent encodedContent = new FormUrlEncodedContent(values);
                string param = await encodedContent.ReadAsStringAsync().ConfigureAwait(false);
                HttpResponseMessage httpResponseMessage = 
                    await _opQueue.Enqueue(15, () => client.GetAsync(ItemsUrl + "?" + param)).ConfigureAwait(false);
                httpResponseMessage.EnsureSuccessStatusCode();
                string content = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                JObject jsonObject = JObject.Parse(content);
                string ordersJson = jsonObject["results"].ToString();
                IEnumerable<Item> items = JsonConvert.DeserializeObject<IEnumerable<Item>>(ordersJson);
                return items;
            }
        }

        public async Task<Order> InsertOrderAsync(Order order)
        {
            using (HttpClient client = GetClient())
            {
                HttpResponseMessage httpResponseMessage = await _opQueue.Enqueue(1, () => client.PostAsync(OrdersUrl,
                new StringContent(
                    JsonConvert.SerializeObject(order, _jsonSerializerSettings),
                    Encoding.UTF8, "application/json"))).ConfigureAwait(false);
                httpResponseMessage.EnsureSuccessStatusCode();
                string content = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                Order newOrder = JsonConvert.DeserializeObject<Order>(content);
                List<Task> tasks = new List<Task>();
                foreach (Item item in order.Items)
                {
                    tasks.Add(InsertItemAsync(item));
                }
                await Task.WhenAll(tasks).ConfigureAwait(false);
                return newOrder;
            }
        }

        public async Task<Item> InsertItemAsync(Item item)
        {
            using (HttpClient client = GetClient())
            {
                HttpResponseMessage httpResponseMessage = await _opQueue.Enqueue(3, () => client.PostAsync(ItemsUrl,
                new StringContent(
                    JsonConvert.SerializeObject(item, _jsonSerializerSettings),
                    Encoding.UTF8, "application/json"))).ConfigureAwait(false);
                httpResponseMessage.EnsureSuccessStatusCode();
                string content = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<Item>(content);
            }
        }
    }
}

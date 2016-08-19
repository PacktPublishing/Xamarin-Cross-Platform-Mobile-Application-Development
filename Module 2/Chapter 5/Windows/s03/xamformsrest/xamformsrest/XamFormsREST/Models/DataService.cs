using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XamFormsREST.Models;

namespace XamFormsREST
{
    public class DataService
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
        const string Url = "https://api.parse.com/1/classes/Order";

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-Parse-Application-Id", "fwpMhK1Ot1hM9ZA4iVRj49VFzDePwILBPjY7wVFy");
            client.DefaultRequestHeaders.Add("X-Parse-REST-API-Key", "egeLQVTC7IsQJGd8GtRj3ttJVRECIZgFgR2uvmsr");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            using (HttpClient client = GetClient())
            {
                HttpResponseMessage httpResponseMessage = await client.GetAsync(Url);
                httpResponseMessage.EnsureSuccessStatusCode();
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                JObject jsonObject = JObject.Parse(content);
                string ordersJson = jsonObject["results"].ToString();
                return JsonConvert.DeserializeObject<IEnumerable<Order>>(ordersJson);
            }
        }

        public async Task<Order> InsertAsync(Order order)
        {
            using (HttpClient client = GetClient())
            {
                HttpResponseMessage httpResponseMessage = await client.PostAsync("https://api.parse.com/1/classes/Order",
                new StringContent(
                    JsonConvert.SerializeObject(order, _jsonSerializerSettings),
                    Encoding.UTF8, "application/json"));
                httpResponseMessage.EnsureSuccessStatusCode();
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Order>(content);
            }
        }

        public async Task UpdateAsync(Order order)
        {
            using (HttpClient client = GetClient())
            {
                HttpResponseMessage httpResponseMessage = 
                    await client.PutAsync(Url + "/" + order.ObjectId,
                            new StringContent(
                                    JsonConvert.SerializeObject(order, _jsonSerializerSettings),
                                    Encoding.UTF8, "application/json"));
                httpResponseMessage.EnsureSuccessStatusCode();
            }
        }

        public async Task DeleteAsync(string objectId)
        {
            using (HttpClient client = GetClient())
            {
                HttpResponseMessage httpResponseMessage = await client.DeleteAsync(Url + "/" + objectId);
                httpResponseMessage.EnsureSuccessStatusCode();
            }
        }
    }
}

using MainAssessment.Tables;
using Newtonsoft.Json;
using SeatManagementConsoleFrontend.Interfaces;
using System.Text;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SeatManagementConsoleFrontend
{
    public class SeatManagementAPICall<T> : ISeatManagerAPI<T> where T : class
    {
        private readonly HttpClient client;
        public string apiEndpoint;
        public SeatManagementAPICall(string apiEndpoint)
        {
            this.apiEndpoint = apiEndpoint;
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7004/api/");
        }
        public List<T> GetData()
        {
            var response = client.GetAsync(apiEndpoint).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var getResponse = JsonConvert.DeserializeObject<List<T>>(responseContent);
                return getResponse;
            }
            else
            {
                return null;
            }

        }
        public string CreateData(T data) {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = client.PostAsync(apiEndpoint, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    
                        return "Added a new entry.";
                    
                }
                return response.Content.ReadAsStringAsync().Result ;

             }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateDetail(T data) {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = client.PatchAsync($"{apiEndpoint}", content).Result;
                if (response.IsSuccessStatusCode)
                {

                    return "Allocated.";

                }
                return response.Content.ReadAsStringAsync().Result;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
          
            
        }
        public void DeleteData(T data) { }
    }
}


using MainAssessment.DTO;
using Newtonsoft.Json;
using SeatManagementConsoleFrontend.Interfaces;

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
            try
            {
                HttpResponseMessage response = client.GetAsync(apiEndpoint).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    List<T>? getResponse = JsonConvert.DeserializeObject<List<T>>(responseContent);
                    return getResponse;
                }
                else
                {
                    return null;
                }
            }

            catch (Exception)
            {
                throw;
            }

        }
        public string CreateData(T data)
        {
            try
            {
                string json = JsonConvert.SerializeObject(data);
                StringContent content = new(json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(apiEndpoint, content).Result;
                return response.IsSuccessStatusCode ? "Added a new entry." : response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateAssetDetail(int assetIndexId, int? Id)
        {
            try
            {
                if (Id != null)
                {
                    HttpResponseMessage response = client.PatchAsync($"{apiEndpoint}/{assetIndexId}?meetingRoomId={Id}", null).Result;
                    return response.IsSuccessStatusCode ? "Successful." : response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    HttpResponseMessage response = client.PatchAsync($"{apiEndpoint}/{assetIndexId}", null).Result;
                    return response.IsSuccessStatusCode ? "Successful." : response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateDetail(int IndexId, int? Id)
        {
            try
            {
                if (Id != null)
                {
                    HttpResponseMessage response = client.PatchAsync($"{apiEndpoint}/{IndexId}?employeeId={Id}", null).Result;
                    return response.IsSuccessStatusCode ? "Successful." : response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    HttpResponseMessage response = client.PatchAsync($"{apiEndpoint}/{IndexId}", null).Result;
                    return response.IsSuccessStatusCode ? "Successful." : response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<T> GenerateReport(SeatAllocationReportRequest requestFilter)
        {
            try
            {
                string json = JsonConvert.SerializeObject(requestFilter);
                StringContent content = new(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync($"{apiEndpoint}/reports", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    List<T>? getResponse = JsonConvert.DeserializeObject<List<T>>(responseContent);
                    return getResponse;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                throw;
            }


        }
        public void DeleteData(T data) { }
    }
}


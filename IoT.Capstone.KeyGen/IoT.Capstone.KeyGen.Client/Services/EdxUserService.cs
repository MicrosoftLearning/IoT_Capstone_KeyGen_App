using System.Net.Http;
using System.Threading.Tasks;
using IoT.Capstone.KeyGen.Client.Models;
using Newtonsoft.Json;

namespace IoT.Capstone.KeyGen.Client.Services
{
    public class EdxUserService
    {
        private static readonly HttpClient Client = new HttpClient();
        private readonly string _serviceBaseUrl;

        public EdxUserService(string serviceBaseUrl)
        {
            _serviceBaseUrl = serviceBaseUrl;
        }

        public async Task<EdxUser> GetUserAsync(string edxUserId)
        {
            EdxUser resultEdxUser = null;
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_serviceBaseUrl}/EdxUser/{edxUserId}");
            var response = await Client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                resultEdxUser = JsonConvert.DeserializeObject<EdxUser>(json);
            }

            return resultEdxUser;
        }
    }
}
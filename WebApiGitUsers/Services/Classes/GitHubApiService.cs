using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApiGitUsers.Models;
using WebApiGitUsers.Services.Interfaces;

namespace WebApiGitUsers.Services.Classes
{
    public class GitHubApiService:IGitHubApiService
    {
        private readonly GitApiSettings _gitApiSettings;
        private readonly HttpClient _httpClient;
        public GitHubApiService(IOptions<GitApiSettings> gitApiSettings) {

            _gitApiSettings = gitApiSettings.Value;
            if (string.IsNullOrWhiteSpace(_gitApiSettings.Url) || string.IsNullOrWhiteSpace(_gitApiSettings.Token)){ 
                throw new Exception("Url or Token must not be empty");
            }

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_gitApiSettings.Url);
            _httpClient.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("AppName", "1.0"));
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", _gitApiSettings.Token);

        }

        public async Task<GitUserResult> GetGitUser(string username)
        {

            try
            {
                var response = await _httpClient.GetAsync($"/users/{username}");
                GitUserResult data = JsonConvert.DeserializeObject<GitUserResult>((await response.Content.ReadAsStringAsync())) ;
                
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

           
        }
    }
}

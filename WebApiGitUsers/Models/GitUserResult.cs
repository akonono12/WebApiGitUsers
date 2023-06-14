using Newtonsoft.Json;
using System.Xml.Linq;

namespace WebApiGitUsers.Models
{
    public class GitUserResult
    {
        [JsonProperty("name")]
        public string Name { get;  set; }
        [JsonProperty("login")]
        public string Login { get;  set; }
        [JsonProperty("company")]
        public string Company { get; set; }
        [JsonProperty("followers")]
        public int?  Followers { get; set; }
        [JsonProperty("public_repos")]
        public int?  Repositories { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        public decimal Average => GetAverage();
        private GitUserResult() { }
        private  decimal GetAverage()
        {
            var followers = Convert.ToDecimal(Followers ?? 0);
            var repositories = Convert.ToDecimal(Repositories ?? 0);
            if(repositories  == 0)
            {
                return 0;
            }
            return Math.Round(followers / repositories, 2);
        }
    }
}



namespace WebApiGitUsers.Applications.Users.Queries
{
    public class GetUsersQueryResultDto
    {
       
        public string Name { get;  set; }
        public string Login { get;  set; }
        public string Company { get;  set; }
        public int Followers { get; set; }
        public int Repositories { get;  set; }
        public decimal Average { get; set; }
    }
}

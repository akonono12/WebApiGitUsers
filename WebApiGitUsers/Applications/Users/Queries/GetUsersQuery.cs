using MediatR;

namespace WebApiGitUsers.Applications.Users.Queries
{
    public class GetUsersQuery:IRequest<List<GetUsersQueryResultDto>>
    {
        public List<string> Usernames { get; set; } 
    }
}

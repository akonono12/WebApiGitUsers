using MediatR;
using Microsoft.Extensions.Options;
using WebApiGitUsers.Models;
using WebApiGitUsers.Services.Interfaces;

namespace WebApiGitUsers.Applications.Users.Queries
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<GetUsersQueryResultDto>>
    {
        private readonly IGitHubApiService _gitHubApi;
 
        public GetUsersQueryHandler(IGitHubApiService gitHubApi ) {
            _gitHubApi = gitHubApi;
        }
        public async Task<List<GetUsersQueryResultDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            
            if(request.Usernames == null || request.Usernames.Count == 0)
            {
                return new();
            }

            List<string>  usernames= request.Usernames.Distinct().ToList();
            List<GetUsersQueryResultDto> users = new List<GetUsersQueryResultDto>();

            foreach (var username in usernames)
            {
                var result  = await _gitHubApi.GetGitUser(username);
                
                if(string.IsNullOrEmpty(result.Message))
                {
                    users.Add(new GetUsersQueryResultDto()
                    {
                        Name = result.Name,
                        Average = result.Average,
                        Repositories = (int)result.Repositories,
                        Company = result.Company,
                        Followers = (int)result.Followers,
                        Login = result.Login,
                    });
                }

            }
            return users.Count > 0 ? users.OrderBy(x => x.Name).ToList() : new();
        }
    }
}

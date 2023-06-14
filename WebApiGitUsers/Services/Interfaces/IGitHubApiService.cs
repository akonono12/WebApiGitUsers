using WebApiGitUsers.Models;

namespace WebApiGitUsers.Services.Interfaces
{
    public interface IGitHubApiService
    {
         Task<GitUserResult> GetGitUser(string username);
    }
}

using Domain.Entities;

namespace Application.Http.Responses
{
    public class LoginUserResponse
    {
        public string Username { get; set; }
        public string AccessToken { get; set; }
        public string RememberToken { get; set; }

        public LoginUserResponse(User user, string accessToken)
        {
            Username = user.Username;
            RememberToken = user.RememberToken;
        }
    }
}
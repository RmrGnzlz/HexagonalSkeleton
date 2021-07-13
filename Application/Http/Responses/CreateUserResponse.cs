using System;
using Domain.Entities;

namespace Application.Http.Responses
{
    public class CreateUserResponse
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; set; }

        public CreateUserResponse(User user)
        {
            UserId = user.Id;
            UserName = user.Username;
            Created = user.CreatedAt;
        }
    }
}
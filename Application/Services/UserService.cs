using System;
using System.Net;
using Application.Base;
using Application.Http.Requests;
using Application.Http.Responses;
using Domain.Contract;
using Domain.Entities;
using Domain.Helpers.Security;
using Domain.Repositories;

namespace Application.Services
{
    public class UserService : Service<User>
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _userRepository = unitOfWork.UserRepository;
        }

        public IResponse<LoginUserResponse> LoginUser(LoginUserRequest request)
        {
            var user = _userRepository.FindFirstOrDefault(x =>
                x.Username == request.Username && x.Password == Hash.GetSha256(request.Password));
            if (user is null)
            {
                return new Response<LoginUserResponse>("User not found", HttpStatusCode.NoContent, false);
            }

            return new Response<LoginUserResponse>("Ok", HttpStatusCode.OK, true,
                new LoginUserResponse(user, string.Empty));
        }

        public IResponse<CreateUserResponse> CreateUser(CreateUserRequest request)
        {
            var user = new User
            {
                Username = request.Username,
                Password = Hash.GetSha256(request.Password)
            };
            _userRepository.Add(user);
            if (UnitOfWork.Commit() > 0)
            {
                return new Response<CreateUserResponse>("Ok", HttpStatusCode.OK, true, new CreateUserResponse(user));
            }

            return new Response<CreateUserResponse>("User not created", HttpStatusCode.InternalServerError, false);
        }
    }
}
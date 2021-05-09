using System;
using Application.Base;
using Application.Http.Requests;
using Application.Http.Responses;
using Domain.Contract;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Encrypt;

namespace Application.Services
{
    public class UserService : Service<User>
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _userRepository = unitOfWork.UserRepository;
        }

        public Response<LoginUserResponse> LoginUser(LoginUserRequest request)
        {
            // TODO: User authentication code
            var user = _userRepository.FindFirstOrDefault(x => x.Username == request.Username && x.Password == Hash.GetSha256(request.Password));
            // TODO: More code here
            throw new NotImplementedException();
        }

        public Response<CreateUserResponse> CreateUser(CreateUserRequest request)
        {
            // TODO: User creation code
            var user = new User
            {
                Username = request.Username,
                Password = Hash.GetSha256(request.Password)
            };
            _userRepository.Add(user);
            // TODO: More code here
            throw new NotImplementedException();
        }
    }
}
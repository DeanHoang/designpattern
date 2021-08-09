using AutoMapper;
using Demo.Database.Entity;
using Demo.Service.IApiService;
using Demo.Service.IRepositories;
using Demo.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.ApiService
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public UserModel AddUser(UserModel user)
        {
            var userToAdd = _mapper.Map<User>(user);
            var userResult = _userRepository.AddUser(userToAdd);
            return _mapper.Map<UserModel>(userResult);
        }
    }
}

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

        public bool DeleteUser(int id)
        {
                var userDel = _userRepository.GetUser(id);
                if (userDel != null)
                {
                    var user = _mapper.Map<User>(userDel);
                    _userRepository.DeleteUser(user.Id);
                    return true;
                }
                return false;                  
        }

        public List<ProductModel> GetProductByUserId(int id)
        {
            if (_userRepository.GetUser(id) != null)
                {
                    var products = _userRepository.GetProductsByUserId(id);
                    var productShow = _mapper.Map<List<ProductModel>>(products);
                    return productShow;
                }
            return null;
            }
        public UserModel GetUser(int id)
        {
            var user = _userRepository.GetUser(id);
            if (user != null)
            {
                var userShow = _mapper.Map<UserModel>(user);
                return userShow;
            }
            return null;
        }

        public List<UserModel> GetUsers()
        {
            var users = _userRepository.GetUsers();
            var usersShow = _mapper.Map<List<UserModel>>(users);
            return usersShow;
        }

        public UserModel UpdateUser(int userId, UserModel userModel)
        {
            if (userModel.Id == userId)
            {
                var userUpdate = _mapper.Map<User>(userModel);
                _userRepository.UpdateUser(userId, userUpdate);
                return userModel;
            }
            return null;
        }
    }
}

using AutoMapper;
using Demo.Database.Entity;
using Demo.Service.ApiService;
using Demo.Service.Common;
using Demo.Service.IRepositories;
using Demo.Service.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductControllerTest
{
    public class UserServiceTesting
    {
        private Mock<IUserRepository> _userRepository = new Mock<IUserRepository>();
        private UserService _userService;
        private IMapper _mapper;
        public UserServiceTesting()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });
            _mapper = mockMapper.CreateMapper();

            _userService = new UserService(_userRepository.Object, _mapper);
        }
        List<UserModel> _listUsers = new List<UserModel>()
        {
            new UserModel(){Id=1, Email="abc1@mail.com", UserName="abc1", Role="Member", Password="L1bXO2/KFEtgfxuxMl6p/SnHlCBXKQk5LwpF01QjshY="},
             new UserModel(){Id=2, Email="abc2@mail.com", UserName="abc2", Role="Member", Password="L1bXO2/KFEtgfxuxMl6p/SnHlCBXKQk5LwpF01QjshY="},
              new UserModel(){Id=3, Email="abc3@mail.com", UserName="abc3", Role="Member", Password="L1bXO2/KFEtgfxuxMl6p/SnHlCBXKQk5LwpF01QjshY="},
               new UserModel(){Id=4, Email="abc4@mail.com", UserName="abc4", Role="Member", Password="L1bXO2/KFEtgfxuxMl6p/SnHlCBXKQk5LwpF01QjshY="},
                new UserModel(){Id=5, Email="abc5@mail.com", UserName="abc5", Role="Member", Password="L1bXO2/KFEtgfxuxMl6p/SnHlCBXKQk5LwpF01QjshY="}
        };
        [Fact]
        public void UserService_GetAllUsers_Test()
        {
            _userRepository.Setup(u => u.GetUsers()).Returns(_mapper.Map<List<User>>(_listUsers));

            var result = _userService.GetUsers() as List<UserModel>;

            Assert.NotNull(result);
            Assert.Equal(_listUsers.Count, result.Count);
        }
        [Fact]
        public void UserService_GetUserById_Test()
        {
            UserModel user = _listUsers[1];
            _userRepository.Setup(u => u.GetUser(It.IsAny<int>())).Returns(_mapper.Map<User>(user));

            var result = _userService.GetUser(user.Id) as UserModel;
            Assert.Equal(result.Id, user.Id);
        }
        [Fact]
        public void UserService_UpdateUser_Test()
        {
            UserModel user = new UserModel();
            int id = 1;
            user.Id = 1;
            user.UserName = "abc";
            user.Password = "L1bXO2/KFEtgfxuxMl6p/SnHlCBXKQk5LwpF01QjshY=";
            user.Email = "abc@gmai.com";
            user.Role = "Member";

            _userRepository.Setup(u => u.UpdateUser(It.IsAny<int>(), It.IsAny<User>())).Returns(
                (int userId, User res) =>
            {
                userId = id;
                res.Id = id;
                return res;
            });

            var result = _userService.UpdateUser(id, user);

            Assert.Equal(id, result.Id);
        }
    }
}

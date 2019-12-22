using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Dto;
using Ecommerce.Service.Interface;

namespace Ecommerce.Service.Services
{
    public class UserService : EcommerceServices<User>, IUserService
    {
        private readonly IUserReponsitory _userReponsitory;
        private readonly IMapper _mapper;
        public UserService(IUserReponsitory userReponsitory, IMapper mapper) : base(userReponsitory)
        {
            _userReponsitory = userReponsitory;
            _mapper = mapper;
        }

        public User Authenticate(string username, string password)
        {
            return _userReponsitory.Authenticate(username, password);
        }

        public User Create(UserDto userDto, string password)
        {
            var user = _mapper.Map<User>(userDto);
            return _userReponsitory.Create(user, password);
        }

        public void Delete(Guid id)
        {
            _userReponsitory.Delete(id);
        }

        public void Update(UserDto userDto, string password = null)
        {
            var user = _mapper.Map<User>(userDto);
            _userReponsitory.Update(user,password);
        }
    }
}

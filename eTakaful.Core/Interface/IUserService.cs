using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Domain.Models;
using Ecommerce.Service.Dto;

namespace Ecommerce.Service.Interface
{
    public interface IUserService : IServices<User>
    {
        User Authenticate(string username, string password);
        //IEnumerable<User> GetAll();
        //User GetById(int id);
        User Create(UserDto user, string password);
        void Update(UserDto user, string password = null);
        void Delete(Guid id);
    }
}

using Entities;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.IRepository
{
    public interface IUserDAL
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<int> CreateUserAsync(UserDTO user);
    }
}

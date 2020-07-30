using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.IRepository
{
    public interface IUserDAL
    {
        Task<User> GetUserIdAsync(int userId);
    }
}

using BLL.InterfacesBll;
using DAL.Repository.IRepository;
using Entities;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBll: IUserBll
    {
        private IUserDAL iUserDAL;
        public UserBll(IUserDAL iUserDAL)
        {
            this.iUserDAL = iUserDAL;
        }

        public Task<int> CreateUserAsync(UserDTO user)
        {
            return iUserDAL.CreateUserAsync(user);
        }

        public Task<User> GetUserByIdAsync(int userId)
        {
            return iUserDAL.GetUserByIdAsync(userId);
        }
    }
}

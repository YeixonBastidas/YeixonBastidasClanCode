using Entities;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InterfacesBll
{
    public interface IUserBll
    {
        Task<ResultGameDTO> GetUserByIdAsync(int userId);
        Task<ResultGameDTO> CreateUserAsync(UserDTO user);
    }
}

using BLL.InterfacesBll;
using Commun.Constant;
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

        public async Task<ResultGameDTO> CreateUserAsync(UserDTO user)
        {
            ResultGameDTO resultGame = new ResultGameDTO();
            var resultRequest = await iUserDAL.CreateUserAsync(user);

            if (resultRequest == 0)
            {
                resultGame.IsError = true;
                return resultGame;
            }

            resultGame.ResultObject = resultRequest;
            return resultGame;
        }

        public async Task<ResultGameDTO> GetUserByIdAsync(int userId)
        {
            ResultGameDTO resultGame = new ResultGameDTO();
            var resultRequest = await iUserDAL.GetUserByIdAsync(userId);

            if (string.IsNullOrEmpty(resultRequest.Name))
            {
                resultGame.IsError = true;
                resultGame.Message = Messages.ErrorNotResult;
                return resultGame;
            }

            resultGame.ResultObject = resultRequest;
            return resultGame;
        }
    }
}

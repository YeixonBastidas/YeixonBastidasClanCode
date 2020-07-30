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
    public class StartRouletteBll: IStartRouletteBll
    {
        private readonly IStartRouletteDAL iStartRouletteDAL;
        public StartRouletteBll(IStartRouletteDAL iStartRouletteDAL)
        {
            this.iStartRouletteDAL = iStartRouletteDAL;
        }

        public async Task<string> OpenStartRouletteAsync(RouletteIdDTO startRoulette)
        {
            var resultRoulette = await this.iStartRouletteDAL.OpenStartRouletteAsync(startRoulette);
            if (resultRoulette > 0)
            {
                return Constant.StatusRouletteStart;
            }

            return Constant.StatusRouletteError;
        }

        public async Task<ResultGameDTO> GetCloseRouletteAsync(int rouletteId)
        {
            ResultGameDTO resultGame = new ResultGameDTO();
           var resultCloseRoulette = await this.iStartRouletteDAL.CloseStartRouletteAsync(rouletteId);

            if(resultCloseRoulette == 0)
            {
                resultGame.IsError = true;
                resultGame.Message = Messages.ErrorClosedRoulettes;
                return resultGame;
            }
            resultGame.Message = Messages.MessageSummary;
            resultGame.ResultObject = await this.iStartRouletteDAL.GetCloseRouletteAsync(rouletteId);
            return resultGame;
        }
    }
}

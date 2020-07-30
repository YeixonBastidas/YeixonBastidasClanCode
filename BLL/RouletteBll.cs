using DAL.Repository.IRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Commun.Constant;
using Entities.DTO;

namespace BLL
{
    public class RouletteBll : IRouletteBll
    {
        private readonly IRouletteDAL iRoulette;
        public RouletteBll(IRouletteDAL iRoulette)
        {
            this.iRoulette = iRoulette;
        }

        public async Task<ResultGameDTO> CreateRoulettesAsync(Roulette roulette)
        {
            ResultGameDTO resultGame = new ResultGameDTO();
            var resultRequest = await this.iRoulette.CreateRoulettesAsync(roulette);

            if (resultRequest == 0)
            {
                resultGame.IsError = true;
                return resultGame;
            }

            resultGame.ResultObject = resultRequest;
            return resultGame;
        }

        public async Task<ResultGameDTO> GetRoulettesAsync()
        {
            ResultGameDTO resultGame = new ResultGameDTO();
            var resultRequest = await this.iRoulette.GetRoulettesAsync();

            if (resultRequest.Any())
            {
                resultGame.IsError = true;
                return resultGame;
            }

            resultGame.ResultObject = resultRequest;
            return resultGame;
        }          
        
    }
}

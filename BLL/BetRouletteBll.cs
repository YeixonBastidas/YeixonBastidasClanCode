using DAL.Repository.IRepository;
using Entities;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Commun.Constant;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;

namespace BLL
{
    public class BetRouletteBll : IBetRouletteBll
    {
        private readonly IBetRouletteDAL iBetRouletteDAL;

        private List<string> ValuesInGame = new List<string>();
        private StartBetDTO UserGameInformation = new StartBetDTO();
        public BetRouletteBll(IBetRouletteDAL iBetRouletteDAL)
        {
            this.iBetRouletteDAL = iBetRouletteDAL;
        }

        public async Task<ResultGameDTO> CreateBetAsync(BetDTO betRoulette)
        {
            ResultGameDTO result = new ResultGameDTO();
            var valitationsCap = ValidationMoneyCap(betRoulette);
            if (valitationsCap.IsError)
            {
                return valitationsCap;
            }

            var resultValidations = await Validations(betRoulette);

            if (resultValidations.IsError)
            {
                return resultValidations;
            }

            await iBetRouletteDAL.CreateBetAsync(SetBet(betRoulette));
            result.Message = Messages.SuccessfulBet;

            return result;
        }

        private async Task<ResultGameDTO> Validations(BetDTO betRoulette)
        {
            ResultGameDTO resultBet = new ResultGameDTO();

            var ValidateDataBet = await ValidBetByUserIdAsync(betRoulette);

            if (ValidateDataBet.IsError)
            {
                return ValidateDataBet;
            }

            var ValidateValueInBet = ValidBetValues(betRoulette);
            if (ValidateValueInBet.IsError)
            {
                return ValidateValueInBet;
            }

            return resultBet;
        }

        private BetRoulette SetBet(BetDTO betRoulette)
        {
            BetRoulette resultRoulette = new BetRoulette();

            resultRoulette.BetMoney = betRoulette.BetMoney;
            resultRoulette.UserId = betRoulette.UserId;
            resultRoulette.BetFor = betRoulette.BetFor;
            resultRoulette.IsGame = true;
            resultRoulette.StartRouletteId = (int)UserGameInformation.StartRouletteId;

            return resultRoulette;
        }
        public async Task<ResultGameDTO> ValidBetByUserIdAsync(BetDTO betUser)
        {
            ResultGameDTO result = new ResultGameDTO();
            UserGameInformation = await this.iBetRouletteDAL.ValidBetByUserIdAsync(betUser);


            if (UserGameInformation.RouletteId == 0 || UserGameInformation.RouletteId == null)
            {
                result.IsError = true;
                result.Message = Messages.ErrorClosedRoulettes;
                return result;
            }

            if (UserGameInformation.UserMoney < betUser.BetMoney)
            {
                result.IsError = true;
                result.Message = Messages.ErrorInsufficientBalance;
                return result;
            }

            return result;
        }

        private ResultGameDTO ValidBetValues(BetDTO betRoulette)
        {
            ResultGameDTO Result = new ResultGameDTO();
            CreateValues();

            if (!ValuesInGame.Contains(betRoulette.BetFor.ToLower()))
            {
                Result.IsError = true;
                Result.Message = Messages.ErrorInValuesBet;
            }

            return Result;
        }

        private ResultGameDTO ValidationMoneyCap(BetDTO betRoulette)
        {
            ResultGameDTO Result = new ResultGameDTO();

            if (betRoulette.BetMoney > Constant.MaximumBet)
            {
                Result.IsError = true;
                Result.Message = Messages.ErrorMaximumBet;
            }

            return Result;
        }

        private void CreateValues()
        {
            for (int i = 0; i <= Constant.NumberMaximumBet; i++)
            {
                ValuesInGame.Add(Convert.ToString(i));
            }

            ValuesInGame.Add(Constant.Black);
            ValuesInGame.Add(Constant.Red);
        }
    }
}

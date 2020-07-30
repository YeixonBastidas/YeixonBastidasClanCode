using Entities;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.IRepository
{
    public interface IBetRouletteDAL
    {
        int CreateBetAsync(BetRoulette betRoulette);

        Task<StartBetDTO> ValidBetByUserIdAsync(BetDTO betUser);
    }
}

using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IBetRouletteBll
    {
        Task<ResultGameDTO> CreateBetAsync(BetDTO betRoulette);

        Task<ResultGameDTO> ValidBetByUserIdAsync(BetDTO betUser);
    }
}

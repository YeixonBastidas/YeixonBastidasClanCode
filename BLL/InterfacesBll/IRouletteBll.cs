namespace BLL
{
    using Entities;
    using Entities.DTO;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRouletteBll
    {
        Task<ResultGameDTO> GetRoulettesAsync();

        Task<ResultGameDTO> CreateRoulettesAsync(Roulette roulette);        
    }
}

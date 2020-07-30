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
        Task<IEnumerable<RouletteDTO>> GetRoulettesAsync();

        Task<int> CreateRoulettesAsync(Roulette roulette);        
    }
}

namespace DAL.Repository.IRepository
{
    using Entities;
    using Entities.DTO;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRouletteDAL
    {
        Task<IEnumerable<RouletteDTO>> GetRoulettesAsync();
        Task<int> CreateRoulettesAsync(Roulette roulette);        
    }
}

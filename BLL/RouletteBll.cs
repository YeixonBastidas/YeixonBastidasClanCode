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

        public async Task<int> CreateRoulettesAsync(Roulette roulette)
        {
            return await this.iRoulette.CreateRoulettesAsync(roulette);
        }

        public async Task<IEnumerable<RouletteDTO>> GetRoulettesAsync()
        {
            return await this.iRoulette.GetRoulettesAsync();
        }          
        
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using BLL;
using Commun.Constant;
using Entities;
using Entities.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route(Constant.ApiController)]
    [EnableCors(Constant.AllowFront)]
    [ApiController]
    public class RouletteController : Controller
    {
        private readonly IRouletteBll iRoulette;

        public RouletteController(IRouletteBll iRoulette)
        {
            this.iRoulette = iRoulette;
        }

        [HttpGet]
        public async Task<ResultGameDTO> GetRoulettesAsync()
        {
            return await iRoulette.GetRoulettesAsync();
        }

        [HttpPost]
        public async Task<ResultGameDTO> CreateRoulettesAsync([FromBody] Roulette roulette)
        {
            return await iRoulette.CreateRoulettesAsync(roulette);
        }
    }
}

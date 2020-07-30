using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Entities;
using Entities.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("/api/[controller]")]
    [EnableCors("AllowFront")]
    [ApiController]
    public class RouletteController : Controller
    {
        private readonly IRouletteBll iRoulette;

        public RouletteController(IRouletteBll iRoulette)
        {
            this.iRoulette = iRoulette;
        }

        [HttpGet]
        public async Task<IEnumerable<RouletteDTO>> GetRoulettesAsync()
        {
            return await iRoulette.GetRoulettesAsync();
        }

        [HttpPost]
        public async Task<int> CreateRoulettesAsync([FromBody] Roulette roulette)
        {
            return await iRoulette.CreateRoulettesAsync(roulette);
        }
    }
}

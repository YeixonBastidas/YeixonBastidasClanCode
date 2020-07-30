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
    public class StartRouletteController : Controller
    {
        private readonly IStartRouletteBll iStartRouletteBll;

        public StartRouletteController(IStartRouletteBll iStartRouletteBll)
        {
            this.iStartRouletteBll = iStartRouletteBll;
        }

        [HttpPost]
        public async Task<string> OpenStartRouletteAsync([FromBody] RouletteIdDTO startRouletteid)
        {
            return await iStartRouletteBll.OpenStartRouletteAsync(startRouletteid);
        }

        [HttpPut]
        [Route("/api/StartRoulette/{rouletteId}")]
        public async Task<ResultGameDTO> CloseStartRouletteAsync(int rouletteId)
        {
            return await iStartRouletteBll.GetCloseRouletteAsync(rouletteId);
        }
    }
}

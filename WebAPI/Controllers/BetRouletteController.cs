using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL;
using Entities.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace WebAPI.Controllers
{
    [Route("/api/[controller]")]
    [EnableCors("AllowFront")]
    [ApiController]
    public class BetRouletteController : Controller
    {
        private readonly IBetRouletteBll iBetRouletteBll;

        public BetRouletteController(IBetRouletteBll iBetRouletteBll)
        {
            this.iBetRouletteBll = iBetRouletteBll;
        }

        [HttpPost]
        public async Task<ResultGameDTO> GetRoulettesAsync([FromBody] BetDTO betRoulette)
        {
            var headers = Headers.GetUserByTokenHeader(this.Request);
            if (headers.IsError)
            {
                return headers;
            }
            betRoulette.UserId = (int)headers.ResultObject;
            return await iBetRouletteBll.CreateBetAsync(betRoulette);
        }

    }
}

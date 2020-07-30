using System.Threading.Tasks;
using BLL;
using Commun.Constant;
using Entities.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route(Constant.ApiController)]
    [EnableCors(Constant.AllowFront)]
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

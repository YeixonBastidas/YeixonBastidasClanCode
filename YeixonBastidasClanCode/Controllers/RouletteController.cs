using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL.Repository.IRepository;
using Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace YeixonBastidasClanCode.Controllers
{
    //[EnableCors("AllowFront")]
    [Route("/api/[controller]")]
    public class RouletteController : Controller
    {
        private readonly IRouletteBll iRoulette;

        public RouletteController(IRouletteBll iRoulette)
        {
            this.iRoulette = iRoulette;
        }

        [HttpGet]
        public IEnumerable<Roulette> GetRoulettesAsync()
        {
            return iRoulette.GetRoulettesAsync();
        }
    }
}

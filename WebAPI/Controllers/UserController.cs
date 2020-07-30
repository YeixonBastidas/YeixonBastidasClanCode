using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.InterfacesBll;
using Entities;
using Entities.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("/api/[controller]")]
    [EnableCors("AllowFront")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserBll iUserBll;

        public UserController(IUserBll iUserBll)
        {
            this.iUserBll = iUserBll;
        }

        [HttpGet]
        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await iUserBll.GetUserByIdAsync(userId);
        }

        [HttpPost]
        public async Task<int> CreateRoulettesAsync([FromBody] UserDTO user)
        {
            return await iUserBll.CreateUserAsync(user);
        }
    }
}

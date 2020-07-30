using Entities.DTO;
using System.Threading.Tasks;

namespace BLL
{
    public interface IStartRouletteBll
    {
        Task<string> OpenStartRouletteAsync(RouletteIdDTO startroulette);

        Task<ResultGameDTO> GetCloseRouletteAsync(int rouletteId);
    }
}

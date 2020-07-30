namespace DAL.Repository.IRepository
{
    using Entities.DTO;
    using System.Threading.Tasks;

    public interface IStartRouletteDAL
    {
        Task<int> CloseStartRouletteAsync(int rouletteId);
        Task<int> OpenStartRouletteAsync(RouletteIdDTO startroulette);
        Task<RouletteSummaryDTO> GetCloseRouletteAsync(int rouletteId);
    }
}

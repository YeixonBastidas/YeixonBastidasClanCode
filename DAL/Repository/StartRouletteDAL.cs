namespace DAL.Repository
{
    using Commun.Constant;
    using DAL.Repository.IRepository;
    using Entities;
    using Entities.DTO;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using System.Threading.Tasks;

    public class StartRouletteDAL : IStartRouletteDAL
    {
        public async Task<int> CloseStartRouletteAsync(int rouletteId)
        {
            string connectionString = "Data Source=.;Initial Catalog=DBRoulette;Integrated Security=True";
            int numberRowAffected = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = string.Format(Querys.QueryUpdateCloseRoulette, DateTime.UtcNow.ToString(Constant.FormatDate), rouletteId);
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    await connection.OpenAsync();
                    numberRowAffected = await  command.ExecuteNonQueryAsync();
                    await connection.CloseAsync();
                }
            }

            return numberRowAffected;
        }

        public async Task<int> OpenStartRouletteAsync(RouletteIdDTO startroulette)
        {
            string connectionString = "Data Source=.;Initial Catalog=DBRoulette;Integrated Security=True";
            int idRoulette = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = string.Format(Querys.QueryOpenRoulette, DateTime.UtcNow.ToString(Constant.FormatDate), startroulette.RouletteId);
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    await connection.OpenAsync();
                    idRoulette = (Int32)await command.ExecuteScalarAsync();
                    await connection.CloseAsync();
                }
                return idRoulette;
            }
        }

        public async Task<RouletteSummaryDTO> GetCloseRouletteAsync(int rouletteId)
        {
            RouletteSummaryDTO rouletteSummary = new RouletteSummaryDTO();

            string connectionString = "Data Source=.;Initial Catalog=DBRoulette;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                await connection.OpenAsync();
                string sql = string.Format(Querys.QueryGetCloseRoulette, rouletteId);                
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        rouletteSummary.Id = Convert.ToInt32(dataReader[Constant.AttributeId]);
                        rouletteSummary.Name = Convert.ToString(dataReader[Constant.AttributeName]);
                        rouletteSummary.AcomuladoBet = Convert.ToDouble(dataReader[Constant.AttributeResultBet]);
                    }
                }

                await connection.CloseAsync();
            }
            return rouletteSummary;
        }
    }
}

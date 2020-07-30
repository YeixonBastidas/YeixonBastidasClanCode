namespace DAL.Repository
{
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
                string sql = $"Update StartRoulette SET IsOpen='0',EndDate='{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")}' Where RouletteId='{rouletteId}' and IsOpen = 1";
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
                string sql = $"Insert Into StartRoulette (StartDate, RouletteId, IsOpen) Values ('{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")}','{startroulette.RouletteId}', '1')"
                            + "SELECT CAST(scope_identity() AS int)";

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
                //SqlDataReader
                await connection.OpenAsync();

                string sql = "select top 1 " +
                             $"  rt.id, rt.Name, " +
                             $" (select sum(BetMoney)" +
                             $"  from BetRoulette br " +
                             $"  where br.StartRouletteId = 3) ResultBet " +
                             $" from Rouletts rt " +
                             $" inner join StartRoulette st on rt.Id = st.RouletteId " +
                             $"  where rt.Id = 3 " +
                             $" order by 1 desc";
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        rouletteSummary.Id = Convert.ToInt32(dataReader["Id"]);
                        rouletteSummary.Name = Convert.ToString(dataReader["Name"]);
                        rouletteSummary.AcomuladoBet = Convert.ToDouble(dataReader["ResultBet"]);
                    }
                }

                await connection.CloseAsync();
            }
            return rouletteSummary;
        }
    }
}

using DAL.Repository.IRepository;
using Entities;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class BetRouletteDAL : IBetRouletteDAL
    {
        public int CreateBetAsync(BetRoulette betRoulette)
        {
            string connectionString = "Data Source=.;Initial Catalog=DBRoulette;Integrated Security=True";
            int idNewRoulette = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Insert Into BetRoulette (UserId, BetMoney,BetFor, IsWinningUser, BetDate, StartRouletteId) " +
                             $"Values ('{betRoulette.UserId}', '{betRoulette.BetMoney}', '{betRoulette.BetFor}', '{betRoulette.IsGame}', " +
                             $" '{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")}', '{betRoulette.StartRouletteId}')"
                            + "SELECT CAST(scope_identity() AS int)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    idNewRoulette = (Int32)command.ExecuteScalar();
                    connection.Close();
                }
                return idNewRoulette;
            }
        }

        public async Task<StartBetDTO> ValidBetByUserIdAsync(BetDTO betUser)
        {
            StartBetDTO startBet = new StartBetDTO();

            string connectionString = "Data Source=.;Initial Catalog=DBRoulette;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string sql = "SELECT sr.RouletteId,sr.Id as StartRouletteId, br.UserId, " +
                            $"(select us.Money from Users us where us.Id = {betUser.UserId}) as Money " +
                            $" FROM StartRoulette sr " +
                            $" left JOIN BetRoulette br on sr.Id = br.StartRouletteId " +
                            $" and br.UserId = {betUser.UserId} " +
                            $" WHERE sr.RouletteId = {betUser.RouletteId} and IsOpen = 1 ";
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        startBet = new StartBetDTO
                        {
                            StartRouletteId = !dataReader.IsDBNull("StartRouletteId") ? 
                                              Convert.ToInt32(dataReader["StartRouletteId"]) 
                                               : 0,
                            UserId = !dataReader.IsDBNull("UserId") ? 
                                        Convert.ToInt32(dataReader["UserId"]) 
                                        : 0,
                            RouletteId = !dataReader.IsDBNull("RouletteId") ? 
                                         Convert.ToInt32(dataReader["RouletteId"]) :
                                         0,
                            UserMoney = !dataReader.IsDBNull("Money") ?
                                        Convert.ToDouble(dataReader["Money"]) : 
                                        0
                        };
                    }
                }

                await connection.CloseAsync();
            }
            return startBet;
        }
    }
}

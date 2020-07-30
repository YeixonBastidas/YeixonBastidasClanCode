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

namespace DAL.Repository
{
    public class BetRouletteDAL : IBetRouletteDAL
    {
        public async Task<int> CreateBetAsync(BetRoulette betRoulette)
        {
            int idNewRoulette = 0;
            using (SqlConnection connection = new SqlConnection(BaseContext.GetParameterConnection()))
            {
                var sql = string.Format(Querys.QueryCreateBet, betRoulette.UserId, betRoulette.BetMoney,
                                        betRoulette.BetFor, betRoulette.IsGame,
                                        DateTime.UtcNow.ToString(Constant.FormatDate), betRoulette.StartRouletteId);

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    await connection.OpenAsync();
                    idNewRoulette = (Int32)await command.ExecuteScalarAsync();
                    await connection.CloseAsync();
                }
                return idNewRoulette;
            }
        }

        public async Task<StartBetDTO> ValidBetByUserIdAsync(BetDTO betUser)
        {
            StartBetDTO startBet = new StartBetDTO();

            using (SqlConnection connection = new SqlConnection(BaseContext.GetParameterConnection()))
            {
                await connection.OpenAsync();

                string sql = string.Format(Querys.QueryValidBetByUserId, betUser.UserId, betUser.UserId, betUser.RouletteId);
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    startBet = await SetDataValidBetByUserId(dataReader);
                }
                await connection.CloseAsync();
            }
            return startBet;
        }

        private async Task<StartBetDTO> SetDataValidBetByUserId(SqlDataReader dataReader)
        {
            StartBetDTO startBet = new StartBetDTO();

            while (await dataReader.ReadAsync())
            {
                startBet = new StartBetDTO
                {
                    StartRouletteId = !dataReader.IsDBNull(Constant.AttributeStartRouletteId) ?
                                      Convert.ToInt32(dataReader[Constant.AttributeStartRouletteId]) : 0,
                    UserId = !dataReader.IsDBNull(Constant.AttributeUserId) ?
                                Convert.ToInt32(dataReader[Constant.AttributeUserId]) : 0,
                    RouletteId = !dataReader.IsDBNull(Constant.AttributeRouletteId) ?
                                 Convert.ToInt32(dataReader[Constant.AttributeRouletteId]) : 0,
                    UserMoney = !dataReader.IsDBNull(Constant.AttributeMoney) ?
                                Convert.ToDouble(dataReader[Constant.AttributeMoney]) : 0
                };
            }

            return startBet;
        }
    }
}

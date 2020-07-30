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
    public class RouletteDAL: IRouletteDAL
    {
        public async Task<IEnumerable<RouletteDTO>> GetRoulettesAsync()
        {
            List<RouletteDTO> rouletteList = new List<RouletteDTO>();            
            using (SqlConnection connection = new SqlConnection(BaseContext.GetParameterConnection()))
            {               
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(Querys.QueryGetRoulettes, connection);

                using (SqlDataReader dataReader =await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        RouletteDTO roulette = new RouletteDTO();
                        roulette.RouletteId = Convert.ToInt32(dataReader[Constant.AttributeId]);
                        roulette.RouletteName = Convert.ToString(dataReader[Constant.AttributeName]);
                        roulette.RouletteStatus = Convert.ToString(dataReader[Constant.AttributeIsOpen]);
                        rouletteList.Add(roulette);
                    }
                }
                await connection.CloseAsync();
            }
            return rouletteList;
        }

        public async Task<int> CreateRoulettesAsync(Roulette roulette)
        {
            int idNewRoulette = 0;
            using (SqlConnection connection = new SqlConnection(BaseContext.GetParameterConnection()))
            {
                string sql = string.Format(Querys.QueryCreateRoulettes, roulette.RouletteName);

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    await connection.OpenAsync();
                    idNewRoulette = (int) await command.ExecuteScalarAsync();
                    await connection.CloseAsync();
                }
                return idNewRoulette;
            }
        }
               
    }
}

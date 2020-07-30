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

            //Configuration["ConnectionStrings:DefaultConnection"];
            string connectionString = "Data Source=.;Initial Catalog=DBRoulette;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //SqlDataReader
                await connection.OpenAsync();

                string sql = "select * , case " +
                              $" (select top 1 IsOpen " +
                              $" from StartRoulette sr " +
                              $" where sr.RouletteId = r.Id " +
                              $" order by 1 desc) when 1 then 'Abierta' " +
                              $" else 'Cerrada' end as IsOpen " +
                              $"from Rouletts r"; 
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader dataReader =await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        RouletteDTO roulette = new RouletteDTO();
                        roulette.RouletteId = Convert.ToInt32(dataReader["Id"]);
                        roulette.RouletteName = Convert.ToString(dataReader["Name"]);
                        roulette.RouletteStatus = Convert.ToString(dataReader["IsOpen"]);

                        rouletteList.Add(roulette);
                    }
                }

                await connection.CloseAsync();
            }
            return rouletteList;
        }

        public async Task<int> CreateRoulettesAsync(Roulette roulette)
        {
            string connectionString = "Data Source=.;Initial Catalog=DBRoulette;Integrated Security=True";
            int idNewRoulette = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Insert Into Rouletts (Name, Status) Values ('{roulette.RouletteName}', '1')"
                            + "SELECT CAST(scope_identity() AS int)"; 

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

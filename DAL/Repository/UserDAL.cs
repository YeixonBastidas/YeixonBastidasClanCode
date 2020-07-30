using Commun.Constant;
using DAL.Repository.IRepository;
using Entities;
using Entities.DTO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UserDAL : IUserDAL
    {
        public async Task<User> GetUserByIdAsync(int userId)
        {
            User currentUser = new User();

            string connectionString = "Data Source=.;Initial Catalog=DBRoulette;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string sql = string.Format(Querys.QueryUsersById, userId);
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    currentUser = await SetDataGetUserId(dataReader);
                }
                await connection.CloseAsync();
            }
            return currentUser;
        }

        private async Task<User> SetDataGetUserId(SqlDataReader dataReader)
        {
            User currentUser = new User();
            while (await dataReader.ReadAsync())
            {
                currentUser = new User
                {
                    Id = Convert.ToInt32(dataReader[Constant.AttributeId]),
                    Name = Convert.ToString(dataReader[Constant.AttributeName]),
                    Alias = Convert.ToString(dataReader[Constant.AttributeAlias]),
                    Money = Convert.ToDouble(dataReader[Constant.AttributeMoney]),
                    Status = Convert.ToBoolean(dataReader[Constant.AttributeStatus])
                };
            }

            return currentUser;
        }

        public async Task<int> CreateUserAsync(UserDTO user)
        {
            string connectionString = "Data Source=.;Initial Catalog=DBRoulette;Integrated Security=True";
            int idNewUser = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var sql = string.Format(Querys.QueryCreateUser, user.Name, user.Alias, user.Money);

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    await connection.OpenAsync();
                    idNewUser = (Int32)await command.ExecuteScalarAsync();
                    await connection.CloseAsync();
                }
                return idNewUser;
            }
        }

    }
}

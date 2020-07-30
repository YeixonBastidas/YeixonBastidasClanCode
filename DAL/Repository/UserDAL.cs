using DAL.Repository.IRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UserDAL: IUserDAL
    {
        private readonly IUserDAL iUserDAL;
         public UserDAL(IUserDAL iUserDAL) 
        {
            this.iUserDAL = iUserDAL;
        }

        public async Task<User> GetUserIdAsync(int userId)
        {
            User currentUser = new User();

            string connectionString = "Data Source=.;Initial Catalog=DBRoulette;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string sql = $"select * Users where Id='{userId}'";
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader dataReader = await command.ExecuteReaderAsync())
                {
                    while (await dataReader.ReadAsync())
                    {
                        currentUser = new User {
                            Id = Convert.ToInt32(dataReader["Id"]),
                            Name = Convert.ToString(dataReader["Name"]),
                            Alias = Convert.ToString(dataReader["Alias"]),
                            Money = Convert.ToDouble(dataReader["Money"]),
                            Status = Convert.ToBoolean(dataReader["Status"])
                         };
                    }
                }

                await connection.CloseAsync();
            }
            return currentUser;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Commun.Constant
{
    public class Querys
    {
        public static readonly string QueryUsersById = "select * from Users where Id='{0}'";

        public static readonly string QueryUsers = "select * Users order by 1";

        public static readonly string QueryCreateUser = "INSERT INTO Users (Name, Alias, Money, Status) " +
                                                        " VALUES('{0}','{1}','{2}',1)" +
                                                        " SELECT CAST(scope_identity() AS int)";

        public static readonly string QueryUpdateCloseRoulette = "Update StartRoulette SET IsOpen='0',EndDate='{0}' Where RouletteId='{1}' and IsOpen = 1";

        public static readonly string QueryOpenRoulette = "Insert Into StartRoulette (StartDate, RouletteId, IsOpen) Values ('{0}',{1}, '1') " +
                                                          " SELECT CAST(scope_identity() AS int)";

        public static readonly string QueryGetCloseRoulette = "select top 1  rt.id, rt.Name,  (select sum(BetMoney)" +
                                                             " from BetRoulette br " +
                                                             " where br.StartRouletteId = st.Id) ResultBet " +
                                                             "from Rouletts rt " +
                                                             " inner join StartRoulette st on rt.Id = st.RouletteId " +
                                                             " where rt.Id = {0} " +
                                                             " order by 1 desc";
        public static readonly string QueryGetRoulettes = "select * , case " +
                                                          " (select top 1 IsOpen " +
                                                          " from StartRoulette sr " +
                                                          " where sr.RouletteId = r.Id " +
                                                          " order by 1 desc) when 1 then 'Abierta' " +
                                                          " else 'Cerrada' end as IsOpen " +
                                                          "from Rouletts r";

        public static readonly string QueryCreateRoulettes = "Insert Into Rouletts (Name, Status) Values ('{0}', '1')"
                                                           + " SELECT CAST(scope_identity() AS int)";

        public static readonly string QueryCreateBet = "Insert Into BetRoulette (UserId, BetMoney,BetFor, IsWinningUser, BetDate, StartRouletteId) " +
                                                       " Values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}') " +
                                                       " SELECT CAST(scope_identity() AS int)";

        public static readonly string QueryValidBetByUserId = "SELECT sr.RouletteId,sr.Id as StartRouletteId, br.UserId, " +
                                                              "(select us.Money from Users us where us.Id = {0}) as Money " +
                                                              " FROM StartRoulette sr " +
                                                              " left JOIN BetRoulette br on sr.Id = br.StartRouletteId " +
                                                              " and br.UserId = {1} " +
                                                              " WHERE sr.RouletteId = {2} and IsOpen = 1 ";
    }
}

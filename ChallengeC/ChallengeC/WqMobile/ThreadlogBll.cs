using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using MySql.Data.MySqlClient;
using ChallengeC.common;

namespace ChallengeC.WqMobile
{
    public class ThreadlogBll
    {
        public bool Savelog(ThreadlogModel log)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO threadlog(");
            strSql.Append("idthreadlog,type,content,logtime,user)");
            strSql.Append(" VALUES (");
            strSql.Append("@idthreadlog,@type,@content,@logtime,@user)");
            MySqlParameter[] cmdParms = new MySqlParameter[] { new MySqlParameter("@idthreadlog", log.idthreadlog), new MySqlParameter("@type", log.type), new MySqlParameter("@content", log.content), new MySqlParameter("@logtime", log.logtime), new MySqlParameter("@user", log.user) };
            return (MySqlHelper.ExecuteNonQuery(ConstValues.connStr, strSql.ToString(), cmdParms) == 1);
        }

        public List<ThreadlogModel> GetLatest100()
        {
            List<ThreadlogModel> logList = new List<ThreadlogModel>();
            string sql = "select * from threadlog order by idthreadlog desc LIMIT 0, 100";
            using (MySqlDataReader dr = MySqlHelper.ExecuteReader(ConstValues.connStr, sql, null))
            {
                while (dr.Read())
                {
                    logList.Add(new ThreadlogModel(dr));
                }
            }
            return logList;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChallengeC.Model;
using MySql.Data.MySqlClient;
using System.Configuration;
using ChallengeC.common;
using System.Text;

namespace ChallengeC.Bll
{
    public class UserBll
    {
        

        public UserModel GetModel(string username, string passwd)
        {
            string sql = "select * from users where username=@username and password = @password";
            MySqlParameter[] para = { 
                                      new MySqlParameter("@username",username),
                                      new MySqlParameter("@password",passwd)
                                  };
            using (MySqlDataReader dr = MySqlHelper.ExecuteReader(ConstValues.connStr, sql, para))
            {
                if (dr.Read())
                {
                    return new UserModel(dr);
                }
            }
            return null;
        }
        public UserModel GetModelByName(string username)
        {
            string sql = "select * from users where username=@username or mobile=@mobile";
            MySqlParameter[] para = { 
                                      new MySqlParameter("@username",username),
                                      new MySqlParameter("@mobile",username)
                                  };
            using (MySqlDataReader dr = MySqlHelper.ExecuteReader(ConstValues.connStr, sql, para))
            {
                if (dr.Read())
                {
                    return new UserModel(dr);
                }
            }
            return null;
        }

        public Boolean SaveUser(UserModel user)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO users(");
            strSql.Append("username,password,email,mobile)");
            strSql.Append(" VALUES (");
            strSql.Append("@in_username,@in_password,@in_email,@in_mobile)");
            MySqlParameter[] cmdParms = {
				new MySqlParameter("@in_username",  user.username),
				new MySqlParameter("@in_password",  user.password),
				new MySqlParameter("@in_email",  user.email),
				new MySqlParameter("@in_mobile",  user.tel)};

            return MySqlHelper.ExecuteNonQuery(ConstValues.connStr, strSql.ToString(), cmdParms) == 1 ? true : false;
        }
    }
}
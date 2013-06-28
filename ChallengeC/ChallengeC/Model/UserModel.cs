using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Common;
using MySql.Data.MySqlClient;

namespace ChallengeC.Model
{
    public class UserModel
    {

        private int _id;
        private string _username;
        private string _password;
        private string _email;
        private string _tel;
        private DateTime _createdate;

        public UserModel()
        {

        }

        public UserModel(MySqlDataReader dr)
        {
            id = PublicMethod.GetInt(dr["id"]);
            username = PublicMethod.GetString(dr["username"]);
            password = PublicMethod.GetString(dr["password"]);
            email = PublicMethod.GetString(dr["email"]);
            tel = PublicMethod.GetString(dr["mobile"]);
            createdate = PublicMethod.GetDateTime(dr["createdate"]);
        }


        /// <summary>
        /// id
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// username
        /// </summary>
        public string username
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// password
        /// </summary>
        public string password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// email
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// tel
        /// </summary>
        public string tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// createdate
        /// </summary>
        public DateTime createdate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
    }
}
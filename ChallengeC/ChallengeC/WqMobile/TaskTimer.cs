using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeC.WqMobile
{
    public class TaskTimer : System.Timers.Timer
    {
        #region <变量>
        /// <summary>
        /// 定时器id
        /// </summary>
        private int id;
        /// <summary>
        /// 定时器参数
        /// </summary>
        private string param;

        private string gameName;
        private int rate;
        #endregion

        #region <属性>
        /// <summary>
        /// 定时器id属性
        /// </summary>
        public int ID
        {
            set { id = value; }
            get { return id; }
        }
        /// <summary>
        /// 定时器参数属性
        /// </summary>
        public string Param
        {
            set { param = value; }
            get { return param; }
        }
        public string GameName
        {
            set { gameName = value; }
            get { return gameName; }
        }
        public int Rate
        {
            set { rate = value; }
            get { return rate; }
        }
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public TaskTimer()
            : base()
        {

        }
    }
}
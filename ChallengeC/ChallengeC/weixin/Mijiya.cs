using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChallengeC.weixin
{
    class Mijiya
    {
        private string Content;
        private string FromUserName;
        public int msgType { get; set; }

        public Mijiya(string content, string fromUserName)
        {
            // TODO: Complete member initialization
            this.Content = content;
            this.FromUserName = fromUserName;
        }

        internal string GetReMsg()
        {
            String url = "http://www.baidu.com/s?wd=" + this.Content + "&pn=1&cl=3&rn=4&ie=utf-8";
            return "<a href=\"" + url + "\">点击查看搜索结果</a>";
        }


        internal string GetRePic(string p)
        {
            return "repic.";
        }

        internal string GetDefault()
        {
            return "reDefault.Content:" + this.Content + ",fromUser:" + this.FromUserName;
        }

        internal string GetFirst()
        {
            return "first.Content:" + this.Content + ",fromUser:" + this.FromUserName;
        }
    }
}

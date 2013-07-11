using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChallengeC.weixin
{
    class RequestXML
    {
        public string ToUserName { get; set; }

        public string FromUserName { get; set; }

        public string CreateTime { get; set; }

        public string MsgType { get; set; }

        public string Content { get; set; }

        public string Location_X { get; set; }

        public string Location_Y { get; set; }

        public string Scale { get; set; }

        public string Label { get; set; }

        public string PicUrl { get; set; }

        public string Event { get; set; }

        public string EventKey { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;

namespace WebContentAnalysis
{
    public class TmallClient
    {
        private ITopClient _client = null;
        private string Url = "http://gw.api.taobao.com/router/rest";
        private string Appkey = "21272939";
        private string AppSecret = "7d1583f829525c902a94f3c670857181";
        private string SessionKey = "61021064b011c31ad587314762f49771e5d305e95f81f1b1048424102";

        public TmallClient()
        {
            _client = new DefaultTopClient(Url, Appkey, AppSecret);
        }

        public string getProductDesc(string productId)
        {
            
            ItemGetRequest req = new ItemGetRequest();
            req.Fields = "detail_url,num_iid,title,price,desc";
            req.NumIid = long.Parse(productId);
            ItemGetResponse response = _client.Execute(req, SessionKey);
            return response.Item.Desc;
        }

    }
}

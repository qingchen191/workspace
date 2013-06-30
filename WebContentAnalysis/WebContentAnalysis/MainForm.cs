using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace WebContentAnalysis
{
    public partial class MainForm : Form
    {


        private WebClient tmallClient;
        private HtmlWeb htmlWeb;
        private string folderName;

        public MainForm()
        {
            InitializeComponent();
            tmallClient = new WebClient();
            tmallClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据

            htmlWeb = new HtmlWeb();
            htmlWeb.AutoDetectEncoding = true;
        }

        private void getStart_Click(object sender, EventArgs e)
        {
            string strUrl = tbUrl.Text;
            if (strUrl.Trim().Equals(""))
            {
                MessageBox.Show("请输入URL地址。");
                tbUrl.Focus();
                return;
            }

            if (tbCount.Text.Trim().Equals(""))
            {
                MessageBox.Show("请输入下载单品个数。");
                tbCount.Focus();
                return;
            }

            if (Int16.Parse(tbCount.Text) > 60)
            {
                MessageBox.Show("下载个数不能超过60个，请重新输入。");
                tbCount.Focus();
                return;
            }

            if (tbImageFolder.Text.Trim().Equals(""))
            {
                MessageBox.Show("请输入图片存放文件夹。");
                tbImageFolder.Focus();
                return;
            }
            lblProgress.Text = "正在下载，请稍候……";

            StringBuilder textSB = new StringBuilder();

            HtmlAgilityPack.HtmlDocument listDoc = htmlWeb.Load(strUrl);
            //查询过滤条件
            HtmlNode searchKeyword = listDoc.GetElementbyId("J_CrumbSearchInuput");
            string keyword = searchKeyword.GetAttributeValue("value", "无");
            StringBuilder conSB = new StringBuilder();
            HtmlNode J_CrumbSlideCon = listDoc.GetElementbyId("J_CrumbSlideCon");
            HtmlNodeCollection crumbSlideConCollection = J_CrumbSlideCon.ChildNodes;
            List<HtmlNode> crumbSlideConList = crumbSlideConCollection.ToList<HtmlNode>();
            foreach (HtmlNode crumbSlideCon in crumbSlideConList)
            {
                if (crumbSlideCon.Name.Equals("li"))
                {
                    HtmlNode aNode = crumbSlideCon.Element("a");
                    if (aNode != null)
                    {
                        string aText = aNode.InnerText;
                        if (!aText.Trim().Equals("全部"))
                        {
                            conSB.Append(aText);
                            conSB.Append(",");
                        }
                    }
                }
            }
            conSB.Append("关键字：" + keyword);

            //System.Console.WriteLine("查询过滤条件：" + conSB.ToString());
            textSB.AppendLine("查询过滤条件：" + conSB.ToString());

            // 发货地
            HtmlNode J_FOriginArea = listDoc.GetElementbyId("J_FOriginArea");
            string originArea = J_FOriginArea.SelectSingleNode("b").InnerText;

            //System.Console.WriteLine("发货地：" + originArea);
            //textSB.AppendLine("发货地：" + originArea);

            //排序名称
            HtmlNode J_Filter = listDoc.GetElementbyId("J_Filter");
            string orderBy = "";
            //HtmlNode J_FForm = listDoc.GetElementbyId("J_FForm");
            IEnumerable<HtmlNode> bNodes = J_Filter.Descendants("b");
            List<HtmlNode> bNodesList = bNodes.ToList();
            foreach (HtmlNode node in bNodesList)
            {
                if (node.GetAttributeValue("class", "").Equals("fR-text") || node.GetAttributeValue("class", "").Equals("fR-cur"))
                {
                    orderBy = node.InnerText;
                }
            }

            //System.Console.WriteLine("排序：" + orderBy);
            textSB.AppendLine("排序：" + orderBy);

            // 价格
            HtmlNode J_FPrice = listDoc.GetElementbyId("J_FPrice");
            HtmlNode startPriceNode = J_FPrice.SelectSingleNode("div/b/input");
            HtmlNode endPriceNode = J_FPrice.SelectSingleNode("div/b[2]/input");
            if (startPriceNode != null && endPriceNode != null)
            {
                string startPrice = J_FPrice.SelectSingleNode("div/b/input").GetAttributeValue("value", "");
                string endPrice = J_FPrice.SelectSingleNode("div/b[2]/input").GetAttributeValue("value", "");

                System.Console.WriteLine("价格：" + startPrice + "-" + endPrice);
                textSB.AppendLine("价格：" + startPrice + "-" + endPrice);
            }

            //
            // 下一页URL
            HtmlNode nextPage = J_Filter.SelectSingleNode("p/a");
            if (nextPage != null)
            {
                string nextPageUrl = nextPage.GetAttributeValue("href", "");
                //System.Console.WriteLine("下一页URL:" + nextPageUrl);
                //textSB.AppendLine("下一页URL:" + nextPageUrl);
            }
            string path = tbImageFolder.Text;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (StreamWriter sw = new StreamWriter(path + "\\查询条件.txt", false, Encoding.Default))//将获取的内容写入文本
            {
                sw.Write(textSB.ToString());
            }

            // 获取商品列表信息
            HtmlNode itemListNode = listDoc.GetElementbyId("J_ItemList"); // 商品列表
            if (itemListNode != null)
            {
                //using (StreamWriter sw = new StreamWriter("E:\\test\\J_ItemList.html", false, Encoding.Default))//将获取的内容写入文本
                //{
                //    sw.Write(itemListNode.InnerHtml);
                //}
                //Console.WriteLine("J_ItemList中Product的个数:" + itemListNode.ChildNodes.Count);
                HtmlNodeCollection productsCollection = itemListNode.ChildNodes;
                List<HtmlNode> productsList = productsCollection.ToList<HtmlNode>();
                int getCount = Int16.Parse(tbCount.Text) * 2;
                for (int i = 0; i < productsList.Count && i <= getCount; i++)
                {
                    HtmlNode product = productsList[i];
                    if (product.Name.Equals("div"))
                    {
                        //Console.WriteLine("NodeName:" + product.Name + " |  productClass:" + product.GetAttributeValue("class", "..."));
                        HtmlNode title = product.SelectSingleNode("div/p[2]/a");
                        //Console.WriteLine("productTitle:" + title.GetAttributeValue("title", "---"));
                        string productUrl = title.GetAttributeValue("href", "");
                        string productTitle = title.GetAttributeValue("title", "title");
                        folderName = productTitle;
                        downloadProductImages(productUrl, productTitle);
                    }

                }
                lblProgress.Text = "下载完成。";
                MessageBox.Show("下载完成。");
            }
            else
            {
                MessageBox.Show("无法获取该网页的商品列表，请确认URL地址是否正确。</BR>" + strUrl);
            }
            
        }

        private void downloadProductImages(string productUrl, string folderName)
        {
            Regex urlRegex = new Regex(@"(?:^|\?|&)id=(\d*)");
            Match m = urlRegex.Match(productUrl);
            string mvalue = m.Value;

            string productId = m.Value.Substring(mvalue.IndexOf("id=") + 3);
            TmallClient client = new TmallClient();
            string description = client.getProductDesc(productId);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            HtmlNode productDesc = doc.CreateElement("description");
            productDesc.InnerHtml = description;
            IEnumerable<HtmlNode> imageList = productDesc.Descendants("img");

            string path = tbImageFolder.Text + "\\" + folderName;
                foreach (HtmlNode imageNode in imageList)
                {
                    string imageUrl = imageNode.GetAttributeValue("src", "");
                    string imageName = imageUrl.Substring(imageUrl.LastIndexOf("/") + 1);
                    saveImage(path, imageName, imageUrl);
                }

        }

        private Boolean saveImage(string imagePath, string imageName, string imageUrl)
        {
            try
            {
                if (!Directory.Exists(imagePath))
                {
                    Directory.CreateDirectory(imagePath);
                }
                Byte[] image = getUrlBytes(imageUrl);
                if (image.Length > 50 * 1024)
                {
                    File.WriteAllBytes(imagePath + "\\" + imageName, image);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        private Byte[] getUrlBytes(string url)
        {
            Byte[] pageData = tmallClient.DownloadData(url); //从指定网站下载数据
            return pageData;
        }

        //void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        //{
        //    WebBrowser web = (WebBrowser)sender;
        //    HtmlElement descNode = web.Document.GetElementById("J_ItemDesc");

        //    if (descNode != null)
        //    {
        //        HtmlElementCollection ElementCollection = descNode.GetElementsByTagName("img");
        //        string path = tbImageFolder.Text + "\\" + folderName;
        //        foreach (HtmlElement item in ElementCollection)
        //        {
        //            File.AppendAllText("Kaijiang_xj.txt", item.InnerText);
        //            string imageUrl = item.GetAttribute("src");
        //            string imageName = imageUrl.Substring(imageUrl.LastIndexOf("/") + 1);
        //            saveImage(path, imageName, imageUrl);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("无法获取该网页的商品描述信息，请确认URL地址是否正确。</BR>");
        //    }
        //}

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace WebContentAnalysis
{
    public partial class ProductPage : Form
    {
        private string imagePath;
        private WebClient tmallClient;

        public ProductPage()
        {
            InitializeComponent();
            tmallClient = new WebClient();
            tmallClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
        }
        public ProductPage(string url, string path)
        {
            InitializeComponent();
            tmallClient = new WebClient();
            tmallClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
            lblUrl.Text = url;
            imagePath = path;
        }

        private void ProductPage_Load(object sender, EventArgs e)
        {
            wbProduct.Navigate(lblUrl.Text);
                        
        }

        private void wbProduct_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElement descNode = wbProduct.Document.GetElementById("J_ItemDesc");
            wbProduct.Document.Window.ScrollTo(0, 500);

            
            using (StreamWriter sw = new StreamWriter("E:\\test\\product.html", false, Encoding.Default))//将获取的内容写入文本
            {
                sw.Write(descNode.InnerHtml);
            }

            button1.PerformClick();
            //System.Threading.Thread.Sleep(3000);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            HtmlElement descNode = wbProduct.Document.GetElementById("J_ItemDesc");
            using (StreamWriter sw = new StreamWriter("E:\\test\\J_ItemDesc.html", false, Encoding.Default))//将获取的内容写入文本
            {
                sw.Write(descNode.InnerHtml);
            }

            if (descNode != null)
            {
                HtmlElementCollection ElementCollection = descNode.GetElementsByTagName("img");
                //string path = tbImageFolder.Text + "\\" + folderName;
                foreach (HtmlElement item in ElementCollection)
                {
                    string imageUrl = item.GetAttribute("src");
                    string imageName = imageUrl.Substring(imageUrl.LastIndexOf("/") + 1);
                    saveImage(imagePath, imageName, imageUrl);
                }
            }
            else
            {
                MessageBox.Show("无法获取该网页的商品描述信息，请确认URL地址是否正确。</BR>");
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
                File.WriteAllBytes(imagePath + "\\" + imageName, getUrlBytes(imageUrl));
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
    }
}

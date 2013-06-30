using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Net;

namespace WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        string workPath;
        string workingApk;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            workPath = tbFolder.Text;
            workingApk = Path.Combine(workPath, "Working_APK");

            unpackApp();

            DirectoryInfo theFolder = new DirectoryInfo(workingApk);
            foreach (DirectoryInfo NextFolder in theFolder.GetDirectories())
            {
                string xmlFile = Path.Combine(NextFolder.FullName, "AndroidManifest.xml");
                AppInfoBean appInfo = new AppInfoBean(xmlFile);
                if (appInfo.Activity == null || appInfo.Activity.Equals(""))
                {
                    MessageBox.Show("无法获取APP信息。");
                    return;
                }
                // 添加V告
                if (cbVGaoAdd.Checked)
                {
                    VGaoAd vgao = new VGaoAd(workPath);
                    vgao.addVGaoAd(NextFolder.FullName, appInfo);
                }
                // 添加酷果
                if (cbKuGuoAdd.Checked)
                {
                    KuGuoAd kuguo = new KuGuoAd(workPath);
                    kuguo.addKuGuoAd(NextFolder.FullName, appInfo);
                }
                // 添加帷千
                if (cbWQAdd.Checked)
                {
                    WQAd wq = new WQAd(workPath);
                    wq.addWQAd(NextFolder.FullName, appInfo);
                }

                // 替换V告包名
                if (cbReVGao.Checked)
                {
                    replacePackageName(NextFolder.FullName, "com.va.", tbVGaoTargStr.Text);
                }
                // 替换酷果包名
                if (cbReKuguo.Checked)
                {
                    replacePackageName(NextFolder.FullName, "com.kuguo.demo.ChildOfMain", tbKuguoTargStr.Text);
                }
                //// 替换帷千包名
                //if (cbReWQ.Checked)
                //{
                //    replacePackageName(NextFolder.FullName, "com.wqmobile.", tbWqTargStr.Text);
                //}
                // 替换游戏包名
                if (cbReGame.Checked)
                {
                    string oldPackage = appInfo.Package;
                    string[] packageStrArray = oldPackage.Split('.');

                    packageStrArray[1] = tbPackageAddStr.Text;

                    string newPackage = String.Join(".", packageStrArray);
                    replacePackageName(NextFolder.FullName, oldPackage, newPackage);
                }
            }


            repackApp();

            //MessageBox.Show("任务已完成，测试你的游戏吧。");
        }


        private void unpackApp()
        {
            Process pro = new Process();

            FileInfo batFile = new FileInfo(Path.Combine(workPath, "Unpack-apk.bat"));
            pro.StartInfo.WorkingDirectory = batFile.Directory.FullName;
            pro.StartInfo.FileName = batFile.FullName;
            //pro.StartInfo.UseShellExecute = false;
            pro.StartInfo.CreateNoWindow = false;
            pro.Start();
            pro.WaitForExit();
        }

        private void repackApp()
        {
            Process pro = new Process();

            FileInfo batFile = new FileInfo(Path.Combine(workPath, "Repack-apk.bat"));
            pro.StartInfo.WorkingDirectory = batFile.Directory.FullName;
            pro.StartInfo.FileName = batFile.FullName;
            //pro.StartInfo.UseShellExecute = false;
            pro.StartInfo.CreateNoWindow = false;
            pro.Start();
            pro.WaitForExit();
        }

        private void replacePackageName(string folder, string orgStr, string tarStr)
        {
            DirectoryInfo theFolder = new DirectoryInfo(folder);
            //遍历文件
            foreach (FileInfo NextFile in theFolder.GetFiles())
            {
                if (FileUtil.isASCII(NextFile.Extension))
                {
                    FileUtil.replacePackageString(NextFile.FullName, orgStr, tarStr);
                }
            }
            
            //遍历文件夹
            foreach (DirectoryInfo NextFolder in theFolder.GetDirectories())
            {
                replacePackageName(NextFolder.FullName, orgStr, tarStr);
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {

            workPath = tbFolder.Text;
            workingApk = Path.Combine(workPath, "Working_APK");

            unpackApp();

            DirectoryInfo theFolder = new DirectoryInfo(workingApk);
            foreach (DirectoryInfo NextFolder in theFolder.GetDirectories())
            {
                string xmlFile = Path.Combine(NextFolder.FullName, "AndroidManifest.xml");

                XmlDocument doc = new XmlDocument();
                doc.Load(xmlFile);
                XmlElement root = doc.DocumentElement;
                string oldVersionCode = root.GetAttribute("android:versionCode");
                string oldVersionName = root.GetAttribute("android:versionName");

                int last = 0;
                string[] codeArray = oldVersionCode.Split('.');
                last = Int32.Parse(codeArray[codeArray.Length - 1]);
                codeArray[codeArray.Length - 1] = (last + 1).ToString();

                string[] nameArray = oldVersionName.Split('.');
                last = Int32.Parse(nameArray[nameArray.Length - 1]);
                nameArray[nameArray.Length - 1] = (last + 1).ToString();


                string newVersionCode = String.Join(".", codeArray);
                string newVersionName = String.Join(".", nameArray);
                root.SetAttribute("android:versionCode", newVersionCode);
                root.SetAttribute("android:versionName", newVersionName);

                doc.Save(xmlFile);
            }


            repackApp();

            //MessageBox.Show("版本号已升级，测试你的游戏吧。");
        }

        private void btnReplaceID_Click(object sender, EventArgs e)
        {
            workPath = tbFolder.Text;
            workingApk = Path.Combine(workPath, "Working_APK");
            string apkFolder = Path.Combine(workingApk, "_" + tbApkName.Text);

            string xmlFile = Path.Combine(apkFolder, "AndroidManifest.xml");

            string oldVID = "0123456789abcdef";
            string oldCooId = "f946b3d4086249a6968aabec7c752027";

            if (!File.Exists(xmlFile))
            {
                MessageBox.Show("文件不存在：" + xmlFile);
                return;
            }

            FileUtil.replaceString(xmlFile, oldVID, tbVGaoID.Text);

            FileUtil.replaceString(xmlFile, oldCooId, tbKuguoID.Text);

            AppInfoBean appInfo = new AppInfoBean(xmlFile);
            if (appInfo.Activity == null || appInfo.Activity.Equals(""))
            {
                MessageBox.Show("无法获取APP信息。");
                return;
            }

            string smaliFolder = Path.Combine(apkFolder,"smali");
            DirectoryInfo smaliDir = new DirectoryInfo(smaliFolder);
            FileInfo[] smaliFiles = smaliDir.GetFiles(appInfo.EntryName + ".smali", SearchOption.AllDirectories);

            foreach (FileInfo file in smaliFiles)
            {
                string smaliFile = file.FullName;

                FileUtil.replaceString(smaliFile, oldVID, tbVGaoID.Text);

                FileUtil.replaceString(smaliFile, oldCooId, tbKuguoID.Text);
            }

            repackApp();
        }

        private void btnModWQ_Click(object sender, EventArgs e)
        {

            workPath = tbFolder.Text;
            workingApk = Path.Combine(workPath, "Working_APK");

            for (int i = 0; i < Int32.Parse(tbCnt.Text); i++)
            {

                unpackApp();

                DirectoryInfo theFolder = new DirectoryInfo(workingApk);
                foreach (DirectoryInfo NextFolder in theFolder.GetDirectories())
                {
                    modWQContent(NextFolder.FullName);

                }


                repackApp();

                string dateStr = DateTime.Now.ToString("yyyyMMdd-HHmmss");

                Directory.Move(Path.Combine(workPath, "New_APK"), Path.Combine(workPath, "New_" + dateStr));

                Directory.Delete(Path.Combine(workPath, "Working_APK"), true);
                Directory.Delete(Path.Combine(workPath, "Raw_APK"), true);

            }

            //MessageBox.Show("任务已完成，测试你的游戏吧。");
        }

        private void modWQContent(string appFolder)
        {
            string smaliFile = Path.Combine(appFolder, "smali\\com\\wqmobile\\sdk\\a\\b.smali");

            string sourceBFile = Path.Combine(workPath, "wq\\a\\b.smali");
            File.Copy(sourceBFile, smaliFile, true);

            if (!File.Exists(smaliFile))
            {
                MessageBox.Show("文件不存在：" + smaliFile);
                return ;
            }

            //getIMSI()1111111111111
            string imsi = "46002";
            imsi = imsi + getNumByLength(10);
            FileUtil.replaceString(smaliFile, "getIMSI()11111111", imsi);

            //getIMEI()22222222
            string imei = getNumByLength(15);
            FileUtil.replaceString(smaliFile, "getIMEI()22222222", imei);

            //getBSSID()33333333
            string bssid = getHexnum();
            FileUtil.replaceString(smaliFile, "getBSSID()33333333", bssid);

            //getMacAddr()44444444
            string maca = getHexnum();
            FileUtil.replaceString(smaliFile, "getMacAddr()44444444", maca);

            //getDeviceId()55555555
            string devid = getNumByLength(15);
            FileUtil.replaceString(smaliFile, "getDeviceId()55555555", devid);

            //getManufacturer()66666666
            string manu = getManufacturer();
            FileUtil.replaceString(smaliFile, "getManufacturer()66666666", manu);

            //getModel()77777777
            string model = getModel(manu);
            FileUtil.replaceString(smaliFile, "getModel()77777777", model);

            //getMinCpuFreq()99999999
            string minCpu = getMinCpu();
            FileUtil.replaceString(smaliFile, "getMinCpuFreq()99999999", minCpu);

            //getMaxCpuFreq()00000000
            string maxCpu = getMaxCpu();
            FileUtil.replaceString(smaliFile, "getMaxCpuFreq()00000000", maxCpu);

            //getCurCpuFreq()88888888
            string curCpu = getCurCpu(minCpu, maxCpu);
            FileUtil.replaceString(smaliFile, "getCurCpuFreq()88888888", curCpu);

            //getCid()11115555 基站编号
            string cid = getNumByLength(5);
            FileUtil.replaceString(smaliFile, "getCid()11115555", cid);

            //getLac()11114444 基站区域编号
            string lac = getNumByLength(4);
            FileUtil.replaceString(smaliFile, "getLac()11114444", lac);

            //getLat()11113333 东经
            string lat = getLat();
            FileUtil.replaceString(smaliFile, "getLat()11113333", lat);

            //getLng()11112222 北纬
            string lng = getLng();
            FileUtil.replaceString(smaliFile, "getLng()11112222", lng);

            //getCpuName()22221111 CPU名
            string cpu = getCpu();
            FileUtil.replaceString(smaliFile, "getCpuName()22221111", cpu);

            //getScreenResolution()22223333 屏幕尺寸
            string screen = getScreen();
            FileUtil.replaceString(smaliFile, "getScreenResolution()22223333", screen);
            


        }

        private string getScreen()
        {
            string str = "";
            Random random = new Random();
            int model = random.Next(5);
            switch (model)
            {
                case 0:
                    str = "320x480";
                    break;
                case 1:
                    str = "480x800";
                    break;
                case 2:
                    str = "1280x800";
                    break;
                case 3:
                    str = "320x512";
                    break;
                case 4:
                    str = "960x640";
                    break;
                default:
                    str = "720x1280";
                    break;
            }
            return str;
        }

        private string getCpu()
        {
            string str = "";
            Random random = new Random();
            int model = random.Next(9);
            switch (model)
            {
                case 0:
                    str = "ARMv6-compatible processor rev 5 (v6l)";
                    break;
                case 1:
                    str = "ARMv6-compatible processor rev 7 (v7l)";
                    break;
                case 2:
                    str = "ARMv7 Processor rev 0 (v7l)";
                    break;
                case 3:
                    str = "ARMv7 Processor rev 1 (v7l)";
                    break;
                case 4:
                    str = "ARMv7 Processor rev 2 (v7)";
                    break;
                case 5:
                    str = "ARMv7 Processor rev 4 (v7l)";
                    break;
                case 6:
                    str = "ARMv7 Processor rev 9 (v7l)";
                    break;
                case 7:
                    str = "ARMv7 Processor rev 10 (v7l)";
                    break;
                case 8:
                    str = "ARMv7 Processor rev 5 (v7)";
                    break;
                default:
                    str = "ARMv7 Processor rev 4 (v7l)";
                    break;
            }
            return str;
        }

        private string getLat()
        {
            // 范围是北纬21-43

            string latStr = "";
            Random random = new Random();
            int lat = random.Next(23) + 21;

            latStr = lat + "." + getNumByLength(8);
            return latStr;
        }

        private string getLng()
        {
            // 范围是东经102-121

            string lngStr = "";
            Random random = new Random();
            int lng = random.Next(20) + 102;

            lngStr = lng + "." + getNumByLength(8);
            return lngStr;
        }

        private string getCurCpu(string minCpu, string maxCpu)
        {
            Int32 mid = Int32.Parse(maxCpu) - Int32.Parse(minCpu);
            Random random = new Random();
            Int32 cur = random.Next(mid);
            cur = cur + Int32.Parse(minCpu);
            return cur.ToString();
        }

        private string getMaxCpu()
        {
            string maxCpu = "1";
            maxCpu = maxCpu + getNumByLength(6);
            return maxCpu;
        }

        private string getMinCpu()
        {
            string maxCpu = "1";
            maxCpu = maxCpu + getNumByLength(5);
            return maxCpu;
        }

        private string getModel(string manu)
        {
            Random random = new Random();
            string str = "";
            if (manu.Equals("COOLPAD"))
            {
                int model = random.Next(14);
                switch (model)
                {
                    case 0:
                        str = "COOLPAD 5010";
                        break;
                    case 1:
                        str = "COOLPAD 5110";
                        break;
                    case 2:
                        str = "COOLPAD 5210";
                        break;
                    case 3:
                        str = "COOLPAD 5820";
                        break;
                    case 4:
                        str = "COOLPAD 5832";
                        break;
                    case 5:
                        str = "COOLPAD 5855";
                        break;
                    case 6:
                        str = "COOLPAD 5860";
                        break;
                    case 7:
                        str = "COOLPAD 7019A";
                        break;
                    case 8:
                        str = "COOLPAD 7260";
                        break;
                    case 9:
                        str = "COOLPAD 7295";
                        break;
                    case 10:
                        str = "COOLPAD 8010";
                        break;
                    case 11:
                        str = "COOLPAD 8050";
                        break;
                    case 12:
                        str = "COOLPAD 9100";
                        break;
                    case 13:
                        str = "COOLPAD D5800";
                        break;
                    default:
                        str = "COOLPAD N950";
                        break;
                }

            }
            else if (manu.Equals("LENOVO"))
            {
                int model = random.Next(4);
                if (model == 0)
                {
                    str = "LENOVO A356";
                }
                else if (model == 1)
                {
                    str = "LENOVO S2-38AH0";
                }
                else if (model == 2)
                {
                    str = "LENOVO S868T";
                }
                else if (model == 3)
                {
                    str = "LENOVO A65";
                }
            }
            else if (manu.Equals("HUAWEI"))
            {
                int model = random.Next(4);
                if (model == 0)
                {
                    str = "HUAWEI U8100";
                }
                else if (model == 1)
                {
                    str = "HUAWEI G7010";
                }
                else if (model == 2)
                {
                    str = "HUAWEI Y210C";
                }
                else if (model == 3)
                {
                    str = "HUAWEI U8800";
                }
            }
            else if (manu.Equals("SAMSUNG"))
            {
                int model = random.Next(4);
                if (model == 0)
                {
                    str = "SAMSUNG N7100";
                }
                else if (model == 1)
                {
                    str = "SAMSUNG GT-I9100G";
                }
                else if (model == 2)
                {
                    str = "SAMSUNG GT-S7566";
                }
                else if (model == 3)
                {
                    str = "SAMSUNG I519";
                }
            }
            return str;
        }

        private string getManufacturer()
        {
            String str = "COOLPAD";
            Random random = new Random();

            int manufact = random.Next(4);
            if (manufact == 0)
            {
                str = "COOLPAD";
            }
            else if (manufact == 1)
            {
                str = "LENOVO";
            }
            else if (manufact == 2)
            {
                str = "HUAWEI";
            }
            else if (manufact == 3)
            {
                str = "SAMSUNG";
            }

            return str;
        }


        
	public String getHexnum() {
		String val = "";

		Random random = new Random();
		for (int i = 0; i < 12; i++) {
			String charOrNum = random.Next(2) % 2 == 0 ? "char" : "num"; // 输出字母还是数字

			if ("char".Equals(charOrNum)) // 字符串
			{
                val += (char)(97 + random.Next(6)); // 小写字母（a-f）
            }
            else if ("num".Equals(charOrNum)) // 数字
			{
                val += random.Next(10);
			}
			
			if((i % 2 == 1) && (i < 11)){
				val += ":";
			}
		}

		return val;
	}

	public String getNumByLength(int length) {

		String val = "";

		Random random = new Random();
		for (int i = 0; i < length; i++) {
            val += random.Next(10);
		}

		return val;

	}
	
	public int getNum(int maxValue){
		Random random = new Random();
        return random.Next(maxValue);
	}

    private void button1_Click_1(object sender, EventArgs e)
    {
        string strBuff = "";
        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://sdk.adwaken.cn/client/client.html");
        HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
        Stream stream = webResponse.GetResponseStream();
        StreamReader reader = new StreamReader(stream, System.Text.Encoding.GetEncoding("UTF-8"));
        strBuff = reader.ReadToEnd();
        

    }
    }
}

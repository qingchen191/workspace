using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace WindowsFormsApplication
{
    class AppInfoBean
    {
        public AppInfoBean()
        {

        }

        public AppInfoBean(string xmlFile)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFile);
            XmlElement root = doc.DocumentElement;
            this.VersionCode = root.GetAttribute("android:versionCode");
            this.VersionName = root.GetAttribute("android:versionName");
            this.Package = root.GetAttribute("package");
            string entryActivity = "";

            XmlNode applicationNode = root.SelectSingleNode("application");

            XmlNodeList activityList = applicationNode.SelectNodes("activity");

            foreach (XmlNode activityNode in activityList)
            {
                if (isEntryActivity(activityNode))
                {
                    XmlNodeReader nodeReader = new XmlNodeReader(activityNode);
                    entryActivity = activityNode.Attributes["android:name"].Value;
                    break;
                }
            }

            if (entryActivity.Substring(0, 1).Equals("."))
            {
                this.Activity = this.Package + entryActivity;
                this.EntryName = entryActivity.Substring(1);
            } else if(!entryActivity.Contains(".")){

                this.Activity = this.Package + "." + entryActivity;
                this.EntryName = entryActivity;
            }
            else
            {
                this.Activity = entryActivity;
                this.EntryName = entryActivity.Substring(entryActivity.LastIndexOf(".") + 1);
            }

        }

        private bool isEntryActivity(XmlNode activityNode)
        {
            XmlNodeList intentFilterNodeList = activityNode.SelectNodes("intent-filter");

            foreach (XmlNode intentFilter in intentFilterNodeList)
            {
                XmlNode actionNode = intentFilter.SelectSingleNode("action");
                if (actionNode != null)
                {
                    if (actionNode.Attributes["android:name"].Value.Equals("android.intent.action.MAIN"))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        string versionCode;
        string versionName;
        string package;
        string activity;
        string entryName;

        public string EntryName
        {
            get { return entryName; }
            set { entryName = value; }
        }

        public string Activity
        {
            get { return activity; }
            set { activity = value; }
        }

        public string Package
        {
            get { return package; }
            set { package = value; }
        }

        public string VersionName
        {
            get { return versionName; }
            set { versionName = value; }
        }

        public string VersionCode
        {
            get { return versionCode; }
            set { versionCode = value; }
        }
    }
}

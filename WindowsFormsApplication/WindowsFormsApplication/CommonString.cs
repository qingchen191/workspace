using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication
{
    class CommonString
    {
        public static string usePermissionVGao = " <uses-permission android:name=\"android.permission.INTERNET\" />\r\n"
+ " <uses-permission android:name=\"android.permission.WAKE_LOCK\" />\r\n"
+ " <uses-permission android:name=\"android.permission.READ_PHONE_STATE\" />\r\n"
+ " <uses-permission android:name=\"android.permission.ACCESS_NETWORK_STATE\" />\r\n"
+ " <uses-permission android:name=\"android.permission.WRITE_EXTERNAL_STORAGE\" />\r\n"
+ " <uses-permission android:name=\"android.permission.ACCESS_WIFI_STATE\" />";

        public static string xmlContentVGao = " <meta-data android:name=\"V-ID\" android:value=\"0123456789abcdef\" />\r\n"
+ " <meta-data android:name=\"CHL-ID\" android:value=\"k-gm\" />\r\n"
+ " <activity android:label=\"\" android:name=\"com.va.VActivity\" android:excludeFromRecents=\"true\" android:launchMode=\"singleTask\" android:configChanges=\"keyboardHidden|orientation\" />\r\n"
+ " <service android:name=\"com.va.VService\" />\r\n"
+ " <receiver android:name=\"com.va.VReceiver\">\r\n"
+ "   <intent-filter>\r\n"
+ "     <action android:name=\"android.intent.action.PACKAGE_ADDED\" />\r\n"
+ "     <data android:scheme=\"package\" />\r\n"
+ "   </intent-filter>\r\n"
+ "   <intent-filter>\r\n"
+ "     <action android:name=\"android.net.conn.CONNECTIVITY_CHANGE\" />\r\n"
+ "   </intent-filter>\r\n"
+ "   <intent-filter>\r\n"
+ "     <action android:name=\"android.intent.action.USER_PRESENT\" />\r\n"
+ "   </intent-filter>\r\n"
+ " </receiver>";

        public static string usePermissionKuGuo = " <uses-permission android:name=\"android.permission.INTERNET\" />\r\n"
+ " <uses-permission android:name=\"android.permission.WAKE_LOCK\" />\r\n"
+ " <uses-permission android:name=\"android.permission.READ_PHONE_STATE\" />\r\n"
+ " <uses-permission android:name=\"android.permission.ACCESS_NETWORK_STATE\" />\r\n"
+ " <uses-permission android:name=\"android.permission.WRITE_EXTERNAL_STORAGE\" />\r\n"
+ " <uses-permission android:name=\"android.permission.ACCESS_COARSE_LOCATION\" />\r\n"
+ " <uses-permission android:name=\"android.permission.ACCESS_FINE_LOCATION\" />\r\n"
+ " <uses-permission android:name=\"android.permission.ACCESS_WIFI_STATE\" />\r\n"
+ " <supports-screens android:anyDensity=\"true\" />";

        public static string xmlContentKuGuo = " <meta-data android:name=\"cooId\" android:value=\"f946b3d4086249a6968aabec7c752027\" />\r\n"
+ " <meta-data android:name=\"channelId\" android:value=\"k-appchina\" />\r\n"
+ " <activity android:name=\"com.kuguo.demo.ChildOfMainActivity\" android:excludeFromRecents=\"true\" android:launchMode=\"singleInstance\" />\r\n"
+ " <service android:name=\"com.kuguo.demo.ChildOfMainService\" />\r\n"
+ " <receiver android:name=\"com.kuguo.demo.ChildOfMainReceiver\">\r\n"
+ "   <intent-filter>\r\n"
+ "     <action android:name=\"android.intent.action.PACKAGE_ADDED\" />\r\n"
+ "     <data android:scheme=\"package\" />\r\n"
+ "   </intent-filter>\r\n"
+ "   <intent-filter>\r\n"
+ "     <action android:name=\"android.net.conn.CONNECTIVITY_CHANGE\" />\r\n"
+ "   </intent-filter>\r\n"
+ " </receiver>";

        public static string smaliMethodVGao = ".method public toStartVGao()V\r\n"
+ " .locals 5\r\n"
+ " .prologue\r\n"
+ " .line 19\r\n"
+ " invoke-static {p0}, Lcom/va/VGaoManager;->getInstance(Landroid/content/Context;)Lcom/va/VGaoManager;\r\n"
+ " move-result-object v1\r\n"
+ " const-string v2, \"0123456789abcdef\"\r\n"
+ " invoke-virtual {v1, p0, v2}, Lcom/va/VGaoManager;->setVId(Landroid/content/Context;Ljava/lang/String;)V\r\n"
+ " .line 20\r\n"
+ " invoke-static {p0}, Lcom/va/VGaoManager;->getInstance(Landroid/content/Context;)Lcom/va/VGaoManager;\r\n"
+ " move-result-object v1\r\n"
+ " const/4 v2, 0x1\r\n"
+ " invoke-virtual {v1, p0, v2}, Lcom/va/VGaoManager;->getMessage(Landroid/content/Context;Z)V\r\n"
+ " .line 560\r\n"
+ " return-void\r\n"
+ ".end method\r\n";


        public static string smaliMethodKuGuo = ".method public toStartKuGuo()V\r\n"
+ " .locals 5\r\n"
+ " .prologue\r\n"
+ " .line 15\r\n"
+ " invoke-static {p0}, Lcom/pkag/p/PAM;->getInstance(Landroid/content/Context;)Lcom/pkag/p/PAM;\r\n"
+ " move-result-object v0\r\n"
+ " .line 16\r\n"
+ " .local v0, localPAM:Lcom/pkag/p/PAM;\r\n"
+ " const-string v1, \"f946b3d4086249a6968aabec7c752027\"\r\n"
+ " invoke-virtual {v0, p0, v1}, Lcom/pkag/p/PAM;->setCooId(Landroid/content/Context;Ljava/lang/String;)V\r\n"
+ " .line 17\r\n"
+ " const/4 v1, 0x1\r\n"
+ " invoke-virtual {v0, p0, v1}, Lcom/pkag/p/PAM;->receivePushMessage(Landroid/content/Context;Z)V\r\n"
+ " .line 560\r\n"
+ " return-void\r\n"
+ ".end method\r\n";


        public static string usePermissionWQ = "<uses-permission android:name=\"android.permission.INTERNET\" />\r\n"
+ " <uses-permission android:name=\"android.permission.ACCESS_NETWORK_STATE\" />\r\n"
+ " <uses-permission android:name=\"android.permission.ACCESS_WIFI_STATE\" />\r\n"
+ " <uses-permission android:name=\"android.permission.READ_PHONE_STATE\" />\r\n"
+ " <uses-permission android:name=\"android.permission.WRITE_EXTERNAL_STORAGE\" />\r\n"
+ " <uses-permission android:name=\"android.permission.ACCESS_COARSE_LOCATION\" />\r\n"
+ " <uses-permission android:name=\"android.permission.ACCESS_FINE_LOCATION\" />\r\n"
+ " <uses-permission android:name=\"android.permission.VIBRATE\" />";

        public static string xmlContentWQ = "<activity android:name=\"com.wqmobile.sdk.WQActionHandler\" android:configChanges=\"keyboardHidden|orientation\" />\r\n"
+ " <activity android:name=\"com.wqmobile.sdk.WQBrowser\" android:configChanges=\"keyboardHidden|orientation\" />";


        public static string smaliFieldWQ = "# annotations\r\n"
+ " .annotation system Ldalvik/annotation/MemberClasses;\r\n"
+ " value = {\r\n"
+ " Lcom/java/test/TestActivity$OpenWall;\r\n"
+ " }\r\n"
+ " .end annotation\r\n"
+ " # instance fields\r\n"
+ " .field private wallbtn:Landroid/widget/ImageView;";


        public static string getWQMethod(string imageId)
        {
            string str = ".method public toStartWQ()V\r\n"
                + " .locals 5\r\n"
                + " .prologue\r\n"
                + " const/4 v4, -0x2\r\n"
                + " .line 31\r\n"
                + " new-instance v2, Landroid/widget/ImageView;\r\n"
                + " invoke-direct {v2, p0}, Landroid/widget/ImageView;-><init>(Landroid/content/Context;)V\r\n"
                + " iput-object v2, p0, Lcom/java/test/TestActivity;->wallbtn:Landroid/widget/ImageView;\r\n"
                + " .line 32\r\n"
                + " iget-object v2, p0, Lcom/java/test/TestActivity;->wallbtn:Landroid/widget/ImageView;\r\n"
                + " const v3, " + imageId + "\r\n"
                + " invoke-virtual {v2, v3}, Landroid/widget/ImageView;->setImageResource(I)V\r\n"
                + " .line 33\r\n"
                + " iget-object v2, p0, Lcom/java/test/TestActivity;->wallbtn:Landroid/widget/ImageView;\r\n"
                + " const/16 v3, 0xbc\r\n"
                + " invoke-virtual {v2, v3}, Landroid/widget/ImageView;->setAlpha(I)V\r\n"
                + " .line 34\r\n"
                + " new-instance v1, Landroid/widget/LinearLayout;\r\n"
                + " invoke-direct {v1, p0}, Landroid/widget/LinearLayout;-><init>(Landroid/content/Context;)V\r\n"
                + " .line 35\r\n"
                + " .local v1, localLinearLayout:Landroid/widget/LinearLayout;\r\n"
                + " new-instance v0, Landroid/widget/LinearLayout$LayoutParams;\r\n"
                + " invoke-direct {v0, v4, v4}, Landroid/widget/LinearLayout$LayoutParams;-><init>(II)V\r\n"
                + " .line 36\r\n"
                + " .local v0, localLayoutParams:Landroid/widget/LinearLayout$LayoutParams;\r\n"
                + " const/high16 v2, 0x428c\r\n"
                + " iput v2, v0, Landroid/widget/LinearLayout$LayoutParams;->weight:F\r\n"
                + " .line 37\r\n"
                + " const/16 v2, 0x12c\r\n"
                + " iput v2, v0, Landroid/widget/LinearLayout$LayoutParams;->height:I\r\n"
                + " .line 38\r\n"
                + " const/16 v2, 0x13\r\n"
                + " iput v2, v0, Landroid/widget/LinearLayout$LayoutParams;->gravity:I\r\n"
                + " .line 39\r\n"
                + " iget-object v2, p0, Lcom/java/test/TestActivity;->wallbtn:Landroid/widget/ImageView;\r\n"
                + " invoke-virtual {v1, v2, v0}, Landroid/widget/LinearLayout;->addView(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V\r\n"
                + " .line 40\r\n"
                + " invoke-virtual {v1}, Landroid/widget/LinearLayout;->invalidate()V\r\n"
                + " .line 41\r\n"
                + " invoke-virtual {p0, v1, v0}, Lcom/java/test/TestActivity;->addContentView(Landroid/view/View;Landroid/view/ViewGroup$LayoutParams;)V\r\n"
                + " .line 42\r\n"
                + " iget-object v2, p0, Lcom/java/test/TestActivity;->wallbtn:Landroid/widget/ImageView;\r\n"
                + " new-instance v3, Lcom/java/test/TestActivity$OpenWall;\r\n"
                + " invoke-direct {v3, p0}, Lcom/java/test/TestActivity$OpenWall;-><init>(Lcom/java/test/TestActivity;)V\r\n"
                + " invoke-virtual {v2, v3}, Landroid/widget/ImageView;->setOnClickListener(Landroid/view/View$OnClickListener;)V\r\n"
                + " .line 43\r\n"
                + " return-void\r\n"
                + " .end method";

            return str;
        }
    }
}

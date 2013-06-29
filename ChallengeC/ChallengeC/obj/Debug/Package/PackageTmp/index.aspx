<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ChallengeC.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        #Text1
        {
            width: 148px;
        }
        #Button3
        {
            height: 36px;
            width: 115px;
        }
    </style>
</head>
<body style="height: 195px">
    <form id="form1" runat="server">

    
    <asp:Button ID="Button1" runat="server" onclick="taikong3d_view" 
        Text="展示太空竞速3D" Width="138px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" Text="展示PopStar" 
        onclick="popstar_view" />
    </br>

    <br />

    <asp:Button ID="taikong3d" runat="server" onclick="taikong3d_Click" 
        Text="下载太空竞速3D" Width="138px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="popstar" runat="server" Text="下载PopStar" 
        onclick="popstar_Click" />
    </br>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
<!--    <p>
        <asp:TextBox ID="TextBox1" runat="server" Height="89px" TextMode="MultiLine" 
            Width="800px"></asp:TextBox>
    </p>
    <asp:TextBox ID="TextBox2" runat="server" Height="80px" TextMode="MultiLine" 
        Width="800px"></asp:TextBox>
    <p>
        <asp:TextBox ID="TextBox3" runat="server" Height="138px" TextMode="MultiLine" 
            Width="800px"></asp:TextBox>
    </p> -->


    <div style="height: 79px">
    
        <br />
        <asp:TextBox ID="tbInterval" runat="server" ToolTip="以秒为单位"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSetInterval" runat="server" Text="设置时间间隔" 
            onclick="btnSetInterval_Click" />
        &nbsp;
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <br />
        <br />
    
    </div>

    
    </form>


    </body>
</html>

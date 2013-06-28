<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ChallengeC.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>

    
    <asp:Button ID="Button1" runat="server" onclick="taikong3d_view" 
        Text="展示太空竞速3D" Width="138px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" Text="展示PopStar" 
        onclick="popstar_view" />
    </br>

    <asp:Button ID="taikong3d" runat="server" onclick="taikong3d_Click" 
        Text="下载太空竞速3D" Width="138px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="popstar" runat="server" Text="下载PopStar" 
        onclick="popstar_Click" />
    <p>
        <asp:TextBox ID="TextBox1" runat="server" Height="89px" TextMode="MultiLine" 
            Width="800px"></asp:TextBox>
    </p>
    <asp:TextBox ID="TextBox2" runat="server" Height="80px" TextMode="MultiLine" 
        Width="800px"></asp:TextBox>
    <p>
        <asp:TextBox ID="TextBox3" runat="server" Height="138px" TextMode="MultiLine" 
            Width="800px"></asp:TextBox>
    </p>
    </form>
    


</body>
</html>

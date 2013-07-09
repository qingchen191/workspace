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
<body style="height: 472px">
    <form id="form1" runat="server">
    <br />
    <br />
&nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" Text="游戏："></asp:Label>
    <asp:DropDownList ID="GameList" runat="server" Height="16px" 
        onselectedindexchanged="GameList_SelectedIndexChanged" Width="118px">
    </asp:DropDownList>
    &nbsp;

    <br />
    <br />
    <br />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnDiaoyudao" runat="server" Height="30px" 
        onclick="btnDiaoyudao_Click" Text="保卫钓鱼岛" Width="100px" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnFkmt" runat="server" Height="30px" onclick="btnFkmt_Click" 
        Text="疯狂摩托" Width="100px" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnJjmt" runat="server" Height="30px" onclick="btnJjmt_Click" 
        Text="竞技摩托" Width="100px" />
    </form>


    </body>
</html>

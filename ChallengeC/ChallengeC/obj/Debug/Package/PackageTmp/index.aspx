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
<ContentTemplate>  
&nbsp;&nbsp;
    <asp:Label ID="Label2" runat="server" Text="日期："></asp:Label>
        <asp:TextBox ID="requestedDeliveryDateTextBox" runat="server" Width="100" />  
        <asp:ImageButton id="imageButton" runat="server" 
            ImageUrl="/Images/calendar.png" AlternateText="calendar" 
            OnClick="ImageButton_Click" CausesValidation="false" Width="30px" />  
        &nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="查询" 
        Width="92px" />
&nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <br />  
        <div id="calendar" class="calendar" visible="false" runat="server">  
        <asp:Calendar ID="requestedDeliveryDateCalendar" runat="server" OnSelectionChanged="RequestedDeliveryDateCalendar_SelectionChanged" />  
        </div>  
</ContentTemplate>  
    <asp:Table ID="ViewTable1" runat="server" CellPadding="3" CellSpacing="3" 
        Height="330px" Width="848px">
        <asp:TableRow runat="server" Height="20px" TableSection="TableHeader">
            <asp:TableCell runat="server">游戏名</asp:TableCell>
            <asp:TableCell runat="server">展示数</asp:TableCell>
            <asp:TableCell runat="server">点击数</asp:TableCell>
            <asp:TableCell runat="server">金额</asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </form>


    </body>
</html>

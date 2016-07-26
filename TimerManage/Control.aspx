<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Control.aspx.cs" Inherits="TimerManage.Control" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnBegin" runat="server" Text="添加并开始" Height="89px" Width="163px" OnClick="btnBegin_Click" />
            <asp:Button ID="btnPause" runat="server" Text="暂停" Height="89px" Width="163px" OnClick="btnPause_Click" />
            <asp:Button ID="btnResuse" runat="server" Text="重启" Height="89px" Width="163px" OnClick="btnResuse_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="停止" Height="89px" Width="163px" OnClick="btnDelete_Click" />
        </div>
    </form>
</body>
</html>

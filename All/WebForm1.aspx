<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="StyleSheet1.css"/> <!-- подключаем файл стилей -->
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="JavaScript.css">
    <title></title>
</head>
<body>

<div id ="header">
		
</div>
        <div id ="content">
    <form id="form1" runat="server">
        
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </form>
        </div>
    
</body>
</html>

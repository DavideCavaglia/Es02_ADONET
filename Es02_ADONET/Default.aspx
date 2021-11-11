<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Es02_ADONET.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Visualizza automobili</h1>
            <asp:Label ID="lblMarche" runat="server" Text="Marche"></asp:Label>
            <asp:DropDownList ID="cmbMarche" runat="server" OnSelectedIndexChanged="cmbMarche_SelectedIndexChanged" OnUnload="Page_Load"></asp:DropDownList>
             <br />
            <asp:Label ID="lblModelli" runat="server" Text="Modelli"></asp:Label>
            
            <asp:DropDownList ID="cmbModelli" runat="server" OnSelectedIndexChanged="cmbModelli_SelectedIndexChanged" OnUnload="Page_Load"></asp:DropDownList>
            <asp:Image ID="imgModello" runat="server" />
            
        </div>
    </form>
</body>
</html>

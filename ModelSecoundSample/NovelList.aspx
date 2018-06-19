<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NovelList.aspx.cs" Inherits="ModelSecoundSample.NovelList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
ul {
    list-style-type: none;
    margin: 0;
    padding: 0;
    overflow: hidden;
}

li {
    float: left;
}

li a {
    display: block;
    padding: 8px;
    background-color: #dddddd;
}
</style>
</head>
<body>
<ul>
  <li><a href="NovelList.aspx">Add Novel</a></li>
  <li><a href="Overview.aspx">Novel List</a></li>
  <li><a href="#contact">Coming soon</a></li>
  <li><a href="#about">Coming soon</a></li>
</ul>
    <form id="form1" runat="server">
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Novel Name"></asp:Label>
        <p>
            <asp:TextBox ID="NovelText" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Released Chapters"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="NovelChapter" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Genre"></asp:Label>
        </p>
        <p>
            <asp:CheckBoxList ID="GenreCheckBox" runat="server"  OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged" RepeatColumns="2" RepeatDirection="Horizontal" CellPadding="5" CellSpacing="5">


            </asp:CheckBoxList>
        </p>
        <p>
            <asp:Label ID="Label4" runat="server" BackColor="White" ForeColor="Red" Text="Something is not in the right format or You forgot Something, please look again." Visible="False"></asp:Label>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Height="36px" OnClick="Button1_Click" Text="Add Novel" Width="88px" />
        </p>
    </form>
</body>
</html>

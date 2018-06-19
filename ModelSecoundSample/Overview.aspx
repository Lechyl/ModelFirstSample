<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Overview.aspx.cs" Inherits="ModelSecoundSample.Overview" %>

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
  <li><a href="NovelList.aspx">New Novel</a></li>
  <li><a href="Overview.aspx">Novel List</a></li>
  <li><a href="#contact">Coming Soon</a></li>
  <li><a href="#about">Coming Soon</a></li>
</ul>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="False" Font-Names="Merriweather Black" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" Font-Underline="True" Text="Your Novel List"></asp:Label>
        </div>
        <asp:TextBox ID="TextBox1" runat="server" Height="334px" OnTextChanged="TextBox1_TextChanged" ReadOnly="True" TextMode="MultiLine" Width="277px"></asp:TextBox>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Remove a Novel From Your Novel List"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Novel Name"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged" Wrap="False"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="RemoveBtn" runat="server" OnClick="Button1_Click" Text="Remove" />
        </p>
    </form>
</body>
</html>

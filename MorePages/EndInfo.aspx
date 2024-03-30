<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EndInfo.aspx.cs" Inherits="finalExam.MorePages.EndInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Style/Site.css" rel="stylesheet" type="text/css" />
    <title>SET Pizza Shop</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>SET Pizza Shop</h1>
        </div>
        <div>
            <h2>Thank you,
                <asp:label id="welcomeLabel" runat="server"></asp:label>
            </h2>
        </div>
        <div>
            <asp:label id="endingLabel" runat="server"></asp:label>
        </div>

    </form>
</body>
</html>

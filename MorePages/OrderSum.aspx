<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderSum.aspx.cs" Inherits="finalExam.MorePages.OrderSum" %>

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
            <h2>Ciao,
                <asp:label id="welcomeLabel" runat="server"></asp:label>
            </h2>
        </div>
        <div>
            Please check your order
        </div>
        <div>
              <table id="sumTable">
                <tr id ="sumTableList">
                    <td>
                        <p>
                                Extra Topping:
                                 <asp:label id="toppingLabel" runat="server"></asp:label>
                        </p>
                        <p>
                                Total Price: $
                                 <asp:label id="priceLabel" runat="server"></asp:label>

                        </p>
                    </td>
                </tr>
            </table>

        </div>
        <div>
            Do you want to confirm your order?
        </div>
        <div>

            <td>
                <asp:Button ID="cancelBtn" runat="server" Text="Cancel" OnClick="cancelBtn_Click" />
            </td>
            <td>
                <asp:Button ID="confirmBtn" runat="server" Text="Confirm" OnClick="confirmBtn_Click" />
            </td>

        </div>

    </form>
</body>
</html>

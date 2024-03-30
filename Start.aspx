<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Start.aspx.cs" Inherits="finalExam.Start" %>

<!DOCTYPE html>
<!--
    /// \file   Start.aspx
    /// \Author Jay Mo
    /// \Date   2023-12-09
    /// \brief  This is a file about the SET pizza website.
    ///         On the first page, the user enters a name
    ///         On the second page, choose the toppings
    ///         On the third page,  the final price is calculated by reflecting the price according to the topping and the user is asked if the order is allowed
    ///         On fourth page, It shows whether the user accepted or rejected the order.
    ///
    ///

-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Style/Site.css" rel="stylesheet" type="text/css"  />
    <title>SET Pizza Shop</title>
</head>
<body>
    <form id="form1" runat="server">
            <div>
                <h1>SET Pizza Shop</h1>
            </div>
             <div>
                  <h3>What is your name?</h3> 
              </div>
            <div>
                    Please enter your name in alphabets. 
                </div>
            <div>
                    Please enter your first name and last name separately. (Ex. John Smith)
            </div>
            <div>
                <asp:TextBox ID="userName" runat="server"></asp:TextBox>
            </div>

            <div>
                <asp:CustomValidator ID="nameValidator" runat="server" Display="Dynamic" ErrorMessage="Please enter &quot;First name Last Name&quot; in alphabetical order (Ex. John Smith)" ForeColor="Red" OnServerValidate="nameValidator_ServerValidate"></asp:CustomValidator>
            </div>
             <div>
           <asp:Button ID="nextPage" runat="server" Text="submit" OnClick="nextPage_Click"/>
            </div>
    </form>
</body>
</html>

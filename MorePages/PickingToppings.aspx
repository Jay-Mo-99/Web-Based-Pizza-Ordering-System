<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PickingToppings.aspx.cs" Inherits="finalExam.MorePages.PickingToppings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SET Pizza Shop</title>
    <link href="~/Style/Site.css" rel="stylesheet" type="text/css" />
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <script>
        $(document).ready(function () {
            resetAllCheckBoxes();
            basicPrice();
            basicToppingName();

            function resetAllCheckBoxes() {
                $("input:checkbox").prop("checked", false);
            }

            function basicPrice() {
                $('#priceLabel').text("10.00");
            }

            function basicToppingName() {
                $("#toppingNameLabel").text('');
            }

            function getBasicPrice() {
                return parseFloat($('#priceLabel').text()) || 0.00;
            }

            function updateLabels(toppings) {
                var basicPrice = 10.00; // Default basic price
                var additionalPrice = 0;

                for (var i = 0; i < toppings.length; i++) {
                    additionalPrice += toppings[i].Price;
                }

                var updatedPrice = basicPrice + additionalPrice;
                var toppingNames = toppings.map(function (topping) {
                    return topping.Name;
                });

                $("#toppingNameLabel").text(toppingNames.join(', '));
                $("#priceLabel").text(updatedPrice.toFixed(2));
            }

            function getToppingsInfo(selectedToppings) {
                $.ajax({
                    type: 'POST',
                    url: '<%=ResolveUrl("~/MorePages/PickingToppings.aspx/returnInfo") %>',
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ indices: selectedToppings }),
                    dataType: 'json',
                    success: function (result) {
                        var toppings = JSON.parse(result.d);
                        if (toppings && toppings.length > 0) {
                            updateLabels(toppings);
                        } else {
                            $("#errorLabel").text("Invalid server");
                            resetLabels();
                        }
                    },
                    error: function (error) {
                        $("#errorLabel").text("Invalid Json return");
                        resetLabels();
                    }
                });
            }

            $('.toppingCheckbox').change(function () {
                var selectedToppings = [];

                $('.toppingCheckbox:checked').each(function () {
                    selectedToppings.push($(this).data('index'));
                });

                getToppingsInfo(selectedToppings);
            });

            function resetLabels() {
                basicPrice(); // Reset the price to the initial value
                $("#toppingNameLabel").text("");
            }

            $('#nextPage').click(function () {
                var totalPrice = $('#priceLabel').text();
                var selectedToppings = $('#toppingNameLabel').text().split(', ');

                $.ajax({
                    type: 'POST',
                    url: '<%=ResolveUrl("~/MorePages/PickingToppings.aspx/SetSessionVariables") %>',
                    data: JSON.stringify({ price: totalPrice, toppings: selectedToppings }),
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function () {
                        <%= Page.GetPostBackEventReference(nextPage) %>;
                        resetAllCheckBoxes();
                    },
                    error: function () {
                        $("#errorLabel").text("Can't go next page");
                    }
                });
            });
        });
    </script>
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
        <h3>You can order a large pizza (the sauce and cheese are already default: $10).</h3>

        <div>
              <table id="toppingsTable">
                <tr>
                    <th>Please choose the toppings you want to add</th>
                </tr>
                <tr id ="checkBoxList">
                    <td>
                        <p>
                            <input type='checkbox' id="toppingCheckbox1" class="toppingCheckbox" data-index="1" />🍕 Pepperoni</p>
                        <p>
                            <input type='checkbox' id="toppingCheckbox2" class="toppingCheckbox" data-index="2" />🍄 Mushrooms</p>

                        <p>
                            <input type='checkbox' id="toppingCheckbox3" class="toppingCheckbox" data-index="3" />🫒 Green Olives</p>
                        <p>
                            <input type='checkbox' id="toppingCheckbox4" class="toppingCheckbox" data-index="4" />🫑 Green Peppers</p>
                        <p>
                            <input type='checkbox' id="toppingCheckbox5" class="toppingCheckbox" data-index="5" />🧀 Double Cheese
                        </p>
                    </td>
                </tr>
            </table>
        </div>
        <div style="display: none;">
            The Extra topping : <asp:Label runat="server" ID="toppingNameLabel"></asp:Label>
        </div>
        <div>
           <h3>Total Price: $<asp:Label ID="priceLabel" runat="server">10</asp:Label> </h3> 
        </div>
        <div style="display: none;">
            Error: $<label id="errorLabel"></label>
        </div>
        <div>
            <asp:Button ID="nextPage" runat="server" OnClick="nextPage_Click" Text="Make it" />
        </div>
        
    </form>
</body>
</html>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Text;
using Newtonsoft.Json;


namespace finalExam.MorePages
{
    public partial class PickingToppings : System.Web.UI.Page
    {

        /*
         * Method: Page_Load
         * Purpose:This is done when the page is loaded.Set session variables and update existing labels to default values.
         *         
         * Returns: None
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            // Disabling UnobtrusiveValidation Default Behavior
            UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            //When the page is first loaded
            if (IsPostBack == false)
            {
                //Displays the name on the page.
                if (Session["UserName"] != null)
                {
                    string userName = Session["UserName"].ToString();
                    welcomeLabel.Text = userName;
                    priceLabel.Text = "10.00";//Set the default price 
                }

            }

        }

        /*
         * Class: Topping
         * Purpose: Represents a pizza topping with properties for Name and Price.
         *          - Name: The name of the topping.
         *          - Price: The price of topping.
         */
        public class Topping
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }


        /*
         * Method:  returnInfo
         * Purpose: This function returns the name and price of the topping in JSON form when a particular value comes in as a parameter.
         * Param  : int index
         * Returns: jsonResult(Return the name and price of the topping according to the topping sent by the client in json form)
         */

        [WebMethod]
        public static string returnInfo(int[] indices)
        {
            List<Topping> selectedToppings = new List<Topping>();

            foreach (int index in indices)
            {
                Topping returnTopping;

                switch (index)
                {
                    case 1:
                        returnTopping = new Topping { Name = "Pepperoni", Price = 1.50 };
                        break;
                    case 2:
                        returnTopping = new Topping { Name = "Mushrooms", Price = 1 };
                        break;
                    case 3:
                        returnTopping = new Topping { Name = "Green Olives", Price = 1 };
                        break;
                    case 4:
                        returnTopping = new Topping { Name = "Green Peppers", Price = 1 };
                        break;
                    case 5:
                        returnTopping = new Topping { Name = "Double Cheese", Price = 2.25 };
                        break;
                    default:
                        return null; // Handle invalid indices
                }

                selectedToppings.Add(returnTopping);
            }

            // Convert the selected toppings to JSON format
            string jsonResult = JsonConvert.SerializeObject(selectedToppings);

            return jsonResult;
        }

        /*
         * WebMethod: SetSessionVariables
         * Purpose: Sets session variables for storing pizza order information.
         */

        [System.Web.Services.WebMethod]
        public static void SetSessionVariables(string price, List<string> toppings)
        {
            HttpContext.Current.Session["Price"] = price;
            HttpContext.Current.Session["Toppings"] = toppings;
        }

        /*
         * Method: nextPage_Click
         * Purpose:This is done when the user click the submit button
         * Param  : object sender, EventArgs e
         * Returns: None
         */
        protected void nextPage_Click(object sender, EventArgs e)
        {
            Session["UserName"] = welcomeLabel.Text; // Save user input text as session variable
            Server.Transfer("OrderSum.aspx");
        }
    }
}
    

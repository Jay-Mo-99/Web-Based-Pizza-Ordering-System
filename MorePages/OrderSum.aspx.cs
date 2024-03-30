using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace finalExam.MorePages
{
    public partial class OrderSum : System.Web.UI.Page
    {
        /*
         * Method: Page_Load
         * Purpose:This is done when the page is loaded.
         *         Set the session variables and update labels
         * Param  : object sender, EventArgs e
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

                    if (Session["Toppings"] != null)
                    {
                        List<string> toppings = (List<string>)Session["Toppings"];
                        if (toppings.Count > 0)
                        {
                            toppingLabel.Text = string.Join(", ", toppings);
                        }
                        else
                        {
                            toppingLabel.Text = "None";
                        }
                    }
                    if (Session["Price"] != null)
                    {
                        string price = Session["Price"].ToString();
                        priceLabel.Text = price;
                    }
                }

            }
        }

        /*
         * Method:  confirmBtn_Click
         * Purpose:When the user presses cofirm, it updates and initializes the session variables with a guide message. Go to the next page.
         * Param  : object sender, EventArgs e
         * Returns: None
         */
        protected void confirmBtn_Click(object sender, EventArgs e)
        {
            //Initialization of session variables
            Session["Toppings"] = null;
            Session["Price"] = null;

            Session["UserName"] = welcomeLabel.Text; // Save user input text as session variable
            Session["EndingInfo"] = "Your order is confirmed"; //Save the EndingInfoMessage as session variable
            Server.Transfer("EndInfo.aspx");
        }

        /*
         * Method: cancelBtn_Click
         * Purpose:When the user presses cancel button, it updates and initializes the session variables with a guide message. Go to the next page.
         * Param  : object sender, EventArgs e
         * Returns: None
         */
        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            //Initialization of session variables
            Session["Toppings"] = null;
            Session["Price"] = null;

            Session["UserName"] = welcomeLabel.Text; // Save user input text as session variable
            Session["EndingInfo"] = "Your order is canceld"; //Save the EndingInfoMessage as session variable
            Server.Transfer("EndInfo.aspx");
        }
    }
}
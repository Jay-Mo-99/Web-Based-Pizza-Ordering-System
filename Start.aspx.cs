using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace finalExam
{
    public partial class Start : System.Web.UI.Page
    {
        /*
         * Method: Page_Load
         * Purpose:This is done when the page is loaded.
         *         If it is not postBack, userName will be reset
         * Param  : object sender, EventArgs e
         * Returns: None
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                userName.Text = "";

            }
            // Disabling UnobtrusiveValidation Default Behavior
            UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
        }

        /*
         * Method: nextPage_Click
         * Purpose:This is done when the user click the submit button
         *        When a user enters right format, it goes to the maxNumber.aspx page
         * Param  : object sender, EventArgs e
         * Returns: None
         */
        protected void nextPage_Click(object sender, EventArgs e)
        {
            // If the user input is valid, proceed to the next page
            if (nameValidator.IsValid)
            {
                Session["UserName"] = userName.Text; // Save user input text as session variable
                Server.Transfer("MorePages/PickingToppings.aspx");
            }
        }

        /*
         * Method: nameValidator_ServerValidate
         * Purpose: Check that the user entered the name in the order "firstname Lastname".
         * Param  : object sender, EventArgs e
         * Returns: None
         */
        protected void nameValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Get the entered name from user
            string fullName = userName.Text; // Trim to remove leading and trailing whitespaces

            // Define the input pattern
            string pattern = @"^[A-Za-z]+\s+[A-Za-z]+$";

            // Check if the entered name matches the pattern
            if (System.Text.RegularExpressions.Regex.IsMatch(fullName, pattern))
            {
                args.IsValid = true; 
            }
            else
            {
                args.IsValid = false; 
            }
        }


    }
}
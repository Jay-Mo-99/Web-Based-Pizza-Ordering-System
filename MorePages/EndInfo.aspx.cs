using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace finalExam.MorePages
{
    public partial class EndInfo : System.Web.UI.Page
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

                    string end = Session["EndingInfo"].ToString();
                    endingLabel.Text = end;

                }

            }
        }

        /*
         * Method: Page_Unload
         * Purpose:When the page ends, the session variables are initialized and the sessions are terminated.
         * Param  : object sender, EventArgs e
         * Returns: None
         */
        protected void Page_Unload(object sender, EventArgs e)
        {
            //initialize session variables to null
            Session["UserName"] = null;
            Session["EndingInfo"] = null;
            //Clear all the session
            Session.Clear();
            Session.Abandon();
        }

    }
}
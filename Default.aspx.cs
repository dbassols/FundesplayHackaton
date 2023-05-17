using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace David_Bassols_Hackaton_Backend
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //si no estas logeado no tendras una variable de session creada y por lo tanto si no hay variable de session te redirige al login 
            // de forma que solo acepta usuarios logeados 
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
                //hace que reconozca al usuario logeado 
                UserText.Text = (string)Session["User"];
            }

        }
    }
}
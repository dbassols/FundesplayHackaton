using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace David_Bassols_Hackaton_Backend
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var nameSession = Session["User"];
            if (nameSession != null)
            {
                labelUserName.Text = "Hola," + (string)nameSession;
                labelEstado.Text = "Salir";
            }
            else
            {
                labelUserName.Text = "Inicia sesion";
                labelEstado.Text = "Entrar";
            }
        }
        protected void Salir_Click(object sender, EventArgs e)
        {
            Session.Contents.RemoveAll();
            Response.Redirect("Login.aspx");

        }
    }
}
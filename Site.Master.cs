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
            // en caso de estar logeado se te saluda al usuario especifico usando las variables de session
            var nameSession = Session["User"];
            if (nameSession != null)
            {
                labelUserName.Text = "Hola," + (string)nameSession;
                labelEstado.Text = "Salir";
            }
            else
            {
                // si no se esta logeado se muestra una frase predefinida
                labelUserName.Text = "Inicia sesion";
                labelEstado.Text = "Entrar";
            }
        }
        protected void Salir_Click(object sender, EventArgs e)
        {
            // para hacer logout destruyes las sessiones y vuelves al login 
            Session.Contents.RemoveAll();
            Response.Redirect("Login.aspx");

        }
    }
}
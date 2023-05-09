using David_Bassols_Hackaton_Backend.DAL;
using David_Bassols_Hackaton_Backend.Encriptar;
using David_Bassols_Hackaton_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace David_Bassols_Hackaton_Backend
{
    public partial class _Login : Page
    {
        DBConnections DBUser = new DBConnections();
        private List<Usuario> usuarios = new List<Usuario>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Contents.RemoveAll();
                usuarios = DBUser.ListaUsuarios();
                Session["usuario"] = usuarios;
            }
            usuarios = (List<Usuario>)Session["usuario"];
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            foreach (Usuario usuario in usuarios)
            {
                if (LoginUser.Text.Equals(usuario.Nombre))
                {
                    string passEncript = PasswordUser.Text + usuario.Keys;
                    string finalEncript = Encrypt.Encryptar(passEncript);

                    if (finalEncript.Equals(usuario.Password))
                    {
                        Session["User"] = LoginUser.Text;
                        Response.Redirect("Default.aspx");
                    }
                }
            }
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}
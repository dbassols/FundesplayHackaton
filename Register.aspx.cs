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
    public partial class _Register : Page
    {
        DBConnections DBUser = new DBConnections();
        private List<Usuario> usuarios = new List<Usuario>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                usuarios = DBUser.ListaUsuarios();
                Session["usuario"] = usuarios;
            }
            usuarios = (List<Usuario>)Session["usuario"];
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (usuarios.Count > 0)
                {
                    foreach (Usuario usuario in usuarios)
                    {
                        if (RegisterUser.Text.Equals(usuario.Nombre))
                        {
                            Mensage.Text = "Usuario ya existente";
                        }
                        else
                        {
                            string passwordRegister = PasswordUser.Text + "abcd";
                            string finalEncript = Encrypt.Encryptar(passwordRegister);
                            Usuario user = new Usuario((string)RegisterUser.Text, finalEncript, "abcd");
                            DBUser.AñadirUsuario(user);
                            Response.Redirect("Login.aspx");

                        }
                    }
                }
                else
                {
                    string passwordRegister = PasswordUser.Text + "abcd";
                    string finalEncript = Encrypt.Encryptar(passwordRegister);
                    Usuario user = new Usuario((string)RegisterUser.Text, finalEncript, "abcd");
                    DBUser.AñadirUsuario(user);
                    Response.Redirect("Login.aspx");
                }
            }catch(Exception ex)
            {
                Mensage.Text = "Error ejecucion";
            }
        }
    }
}
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
        //se inicia la conexion a la BD
        DBConnections DBUser = new DBConnections();
        private List<Usuario> usuarios = new List<Usuario>();

        protected void Page_Load(object sender, EventArgs e)
        {
            // solo al cargar por primera vez la pagina( mientras se este en la pagina no en el total) 
            if (!IsPostBack)
            {
                //eliminas las variables de session debido a que en login no pueden haber ninguna variable de session activa
                Session.Contents.RemoveAll();
                //obtenemos los datos de la tabla de la base de datos para hacer la comprobacion del login
                usuarios = DBUser.ListaUsuarios();
                Session["usuario"] = usuarios;
            }
            // nos aseguramos que la lista este actualizada
            usuarios = (List<Usuario>)Session["usuario"];
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            foreach (Usuario usuario in usuarios)
            {
                //comprobamos si el nombre del usuario es correcto al compara el introducido con los de la tabla
                if (LoginUser.Text.Equals(usuario.Nombre))
                {
                    // al ser correcto obtienes su llave de la tabla y lo usas para encriptar la contraseña y comparars las 2 contaseñas
                    // las cuales han sido encriptadas
                    string passEncript = PasswordUser.Text + usuario.Keys;
                    string finalEncript = Encrypt.Encryptar(passEncript);

                    if (finalEncript.Equals(usuario.Password))
                    {
                        // si todo es correcto creas la variable de sesssion que indica que estas logeado y te redirige a default ( pagina principal)
                        Session["User"] = LoginUser.Text;
                        Response.Redirect("Default.aspx");
                    }
                }
            }
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            //redirige a register por si te neesitas registrar 
            Response.Redirect("Register.aspx");
        }
    }
}
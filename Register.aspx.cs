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
        //se inicia la conexion a la BD
        DBConnections DBUser = new DBConnections();
        private List<Usuario> usuarios = new List<Usuario>();
        protected void Page_Load(object sender, EventArgs e)
        {
            // solo al cargar por primera vez la pagina( mientras se este en la pagina no en el total) 
            if (!IsPostBack)
            {
                //obtenemos los datos de la tabla de la base de datos para hacer la comprobacion del register y ver si el usuario ya existe 
                usuarios = DBUser.ListaUsuarios();
                Session["usuario"] = usuarios;
            }
            usuarios = (List<Usuario>)Session["usuario"];
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            try
            {
                // comprovamos que ya hay usuarios en la base de datos (en caso de no haber pasamos al siguiente paso)
                if (usuarios.Count > 0)
                {
                    // comprobamos si el usuario ya existia 
                    foreach (Usuario usuario in usuarios)
                    {
                        if (RegisterUser.Text.Equals(usuario.Nombre))
                        {
                            // si ya existe lo decimos y terminamos el proceso 
                            Mensage.Text = "Usuario ya existente";
                        }
                        else
                        {
                            // en caso de no existir ciframos la contraseña y lo subimos todo a la base de datos, luego se te reedirige a login
                            // se usa la clave "abcd" por defecto
                            string passwordRegister = PasswordUser.Text + "abcd";
                            string finalEncript = Encrypt.Encryptar(passwordRegister);
                            Usuario user = new Usuario((string)RegisterUser.Text, finalEncript, "abcd");
                            //usamos el metodo de la DBconnexion para crear al nuevo usuario en la tabla de la BD
                            DBUser.AñadirUsuario(user);
                            Response.Redirect("Login.aspx");

                        }
                    }
                }
                else
                {
                    // en caso de no haber usuarios realizamos el registro de un nuevo usuario de forma directa 
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
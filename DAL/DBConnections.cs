using David_Bassols_Hackaton_Backend.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace David_Bassols_Hackaton_Backend.DAL
{
    
    public class DBConnections
    {
        // creamos variable de conexion 
        SqlConnection conexion;
        public SqlConnection AbrirConexion()
        {
            //al poder fallas debido a factores no relacionados con el codigo (conexion a internet entre otros), aplicamos try catch 
            try
            {

                //le damos un valor a la variable de conexion que corresponde a los parametros de la base de datos en la que la conectamos
                conexion = new SqlConnection("Data Source=46.183.117.56,54321; Initial Catalog=DavidHAT; Persist Security Info=true; User Id=sa; Password=123456789");
                //iniciamos la conexion y la devolvemos para usaer en otros metodos 
                conexion.Open();
                return conexion;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return conexion;
            }
        }
        public void CerrarConexion()
        {
            try
            {
                //cerramos conexion (se puede hacer porque conexion es una variable de la clase y no del metodo de abrirConexion) con el .close
                conexion.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            

        }
        public List<Usuario> ListaUsuarios()
        {
            try
            {
                //abrimos la conexion con el metodo ya creado 
                SqlConnection conexion = AbrirConexion();
                // creamos una query y hacemos el sqlcomand usando la query y la conexion abierta
                string cadena2 = "select * from Usuarios";
                SqlCommand comando2 = new SqlCommand(cadena2, conexion);
                //creamos el lector y la lista para los parametros
                SqlDataReader registros = comando2.ExecuteReader();
                List<Usuario> usuarios = new List<Usuario>();
                while (registros.Read())
                {
                    //obtenemos los parametros de la query y vamos creando los usuarios que se añadiran a la lista
                    object Id = registros.GetValue(0);
                    object nombre = registros.GetValue(1);
                    object password = registros.GetValue(2);
                    object keys = registros.GetValue(3);
                    
                    Usuario usuario = new Usuario((int)Id, (string)nombre, (string)password, (string)keys);
                    usuarios.Add(usuario);
                }
                //cerramos la conexion al terminar el proceso y devolvemos la lista con los usuarios de la tabla de la base de datos
                registros.Close();
                CerrarConexion();
                return usuarios;
            }
            catch (Exception ex)
            {
                List<Usuario> usuarios = new List<Usuario>();
                Console.WriteLine(ex.Message);
                return usuarios;
            }
        }
        public void AñadirUsuario(Usuario usuario)
        {
            try
            {
                //abrimos la conexion creamos la query de insert para añadir los nuevos usuarios y realizamos con el sqlcommand con
                //la query y la conexion 
                SqlConnection conexion = AbrirConexion();
                string query = $"INSERT INTO Usuarios VALUES (@Usuario, @Password, @Keys)";
                SqlCommand command = new SqlCommand(query, conexion);

                //asignamos como parametros los atributos del usuario que queremos añadir ( el usuario que se envia a esta funcion)
                //segun su tipo el quela coincidira con el tipo de la columna de la tabla de la base de datos,
                //1 creamos el  parametro para que encaje con la tabla (siendo el dato del uusario recibido)
                //2 lo añadimos al commando como parametro
                //3 lo ponemos como valor de User
                SqlParameter User = new SqlParameter("@Usuario", SqlDbType.NVarChar, 50);
                command.Parameters.Add(User);
                User.Value = usuario.Nombre;

                SqlParameter Password = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
                command.Parameters.Add(Password);
                Password.Value = usuario.Password;

                SqlParameter Keys = new SqlParameter("@Keys", SqlDbType.NVarChar, 50);
                command.Parameters.Add(Keys);
                Keys.Value = usuario.Keys;

                command.ExecuteNonQuery();
                CerrarConexion();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }

}
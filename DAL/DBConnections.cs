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
        SqlConnection conexion;
        public SqlConnection AbrirConexion()
        {
            try
            {
                conexion = new SqlConnection("Data Source=46.183.117.56,54321; Initial Catalog=DavidHAT; Persist Security Info=true; User Id=sa; Password=123456789");
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
                SqlConnection conexion = AbrirConexion();
                string cadena2 = "select * from Usuarios";
                SqlCommand comando2 = new SqlCommand(cadena2, conexion);
                SqlDataReader registros = comando2.ExecuteReader();
                List<Usuario> usuarios = new List<Usuario>();
                while (registros.Read())
                {
                    object Id = registros.GetValue(0);
                    object nombre = registros.GetValue(1);
                    object password = registros.GetValue(2);
                    object keys = registros.GetValue(3);
                    

                    Usuario usuario = new Usuario((int)Id, (string)nombre, (string)password, (string)keys);
                    usuarios.Add(usuario);
                }
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
                SqlConnection conexion = AbrirConexion();
                string query = $"INSERT INTO Usuarios VALUES (@Usuario, @Password, @Keys)";
                SqlCommand command = new SqlCommand(query, conexion);

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
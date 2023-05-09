using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace David_Bassols_Hackaton_Backend.Model
{
    public class Usuario
    {
        private int id;
        private string nombre;
        private string password;
        private string keys;
  

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Keys
        {
            get { return keys; }
            set { keys = value; }
        }

        public Usuario(string Nombre, string Password, string Keys)
        {
            this.Nombre = Nombre;
            this.Password = Password;
            this.Keys = Keys;
            
        }
        public Usuario(int id, string Nombre, string Password, string Keys)
        {
            this.Id = id;
            this.Nombre = Nombre;
            this.Password = Password;
            this.Keys = Keys;
            
        }
    }
}
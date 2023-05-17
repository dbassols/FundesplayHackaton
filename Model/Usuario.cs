using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace David_Bassols_Hackaton_Backend.Model
{
    public class Usuario
    {

        //creas los atributos en privado
        private int id;
        private string nombre;
        private string password;
        private string keys;
  
        // haces el getter y setter de cada atributo
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

        //creas los constructores que utilizaras en otras clases para crear usuarios (no usamos en overwrite (toString)) por lo que no lo he creado esta vez
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
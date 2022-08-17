using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TODOOFERTAS.Dominio
{
    public class Administrador
    {
        private int _ci;
        private string _nombre;
        private string _password;
        private int _intentos;

        public int Ci { get => _ci; set => _ci = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Password { get => _password; set => _password = value; }
        public int Intentos { get => _intentos; set => _intentos = value; }
        public Administrador() { }
        public Administrador(int ci, string nombre, string password, int intentos)
        {
            _ci = ci;
            _nombre = nombre;
            _password = password;
            _intentos = intentos;
        }

        public override string ToString()
        {
            return $"{Ci} {Nombre}";
        }
    }
}
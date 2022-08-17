using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TODOOFERTAS.Dominio
{
    public class Usuario : Administrador
    {
        public Usuario() { }

        public Usuario(int pCI, string pNombre, string pPassword, int intentos) : base(pCI, pNombre, pPassword, intentos) { }

        public override string ToString()
        {
            return $"{Ci} {Nombre}";
        }
    }
}
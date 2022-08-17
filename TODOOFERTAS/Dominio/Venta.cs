using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TODOOFERTAS.Dominio
{
    public class Venta
    {
        private int _id;
        private string _idpromocion;
        private int _ciusuario;

        public int Id { get => _id; set => _id = value; }
        public string IdPromocion { get => _idpromocion; set => _idpromocion = value; }
        public int CiUsuario { get => _ciusuario; set => _ciusuario = value; }

        public Venta() { }

        public Venta(int pId, string pIdPromocion, int pCiUsuario)
        {
            Id = pId;
            IdPromocion = pIdPromocion;
            CiUsuario = pCiUsuario;
        }

        public override string ToString()
        {
            return $"{Id} {IdPromocion} {CiUsuario}";
        }
    }
}
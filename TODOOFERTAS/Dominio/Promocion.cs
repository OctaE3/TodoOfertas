using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TODOOFERTAS.Dominio
{
    public class Promocion
    {
        private string _id;
        private string _titulo;
        private string _producto;
        private string _descripcion;
        private int _precioOriginal;
        private int _precioPromocion;
        private int _porcentajeDesc;
        private string _imagen;
        private string _detalles;
        private string _condiciones;
        private DateTime _fecha;

        public string Id { get => _id; set => _id = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public int PrecioOriginal { get => _precioOriginal; set => _precioOriginal = value; }
        public int PrecioPromocion { get => _precioPromocion; set => _precioPromocion = value; }
        public int PorcentajeDesc { get => _porcentajeDesc; set => _porcentajeDesc = value; }
        public string Imagen { get => _imagen; set => _imagen = value; }
        public string Detalles { get => _detalles; set => _detalles = value; }
        public string Condiciones { get => _condiciones; set => _condiciones = value; }
        public string Producto { get => _producto; set => _producto = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }

        public override string ToString()
        {
            return this.Id + " " + this.Titulo + " " + this.Producto + " " + this.Descripcion + " " + this.PrecioOriginal + " " + this.PrecioPromocion + " " + this.PorcentajeDesc + " " + this.Detalles +" "+ this.Fecha  + " " + this.Condiciones.ToString(); 
        }

        public Promocion()
        {

        }

        public Promocion(string id, string titulo, string producto, string descripcion, int precioOriginal, int precioPromocion, int porcentajeDesc, string imagen, string detalles, string condiciones , DateTime fecha)
        {
            _id = id;
            _titulo = titulo;
            _producto = producto;
            _descripcion = descripcion;
            _precioOriginal = precioOriginal;
            _precioPromocion = precioPromocion;
            _porcentajeDesc = porcentajeDesc;
            _imagen = imagen;
            _detalles = detalles;
            _condiciones = condiciones;
            _fecha = fecha;
        }
    }
}
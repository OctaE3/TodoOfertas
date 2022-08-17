using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using TODOOFERTAS.Dominio;
using TODOOFERTAS.Persistencia;
using System.Web.Security;

namespace TODOOFERTAS.Presentacion
{
    public partial class wfrmInicio1 : System.Web.UI.Page
    {
        public List<Promocion> Item { get; set; }

        Controladora controladora = new Controladora();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtIdPromocion.Attributes.Add("onkeypress", "LetrasYNumeros(event);");
            this.getPromocion();
            this.DataBind();

            if(Request.Cookies[".ASPXAUTH"] == null)
            {
                Response.Redirect("~/Presentacion/wfrmLoginUsuario");
            } 
        }

        public void getPromocion()
        {
            var conexion = new SqlConnection(Conexion.CadenaDeConexion);
            conexion.Open();
            SqlCommand cmd = new SqlCommand(null, conexion);
            cmd.CommandText = "SELECT id_promocion, titulo, descripcion, producto, precio_original, precio_promocion, porcentaje_descuento, imagen, detalles, condiciones FROM Promocion";
            SqlDataReader rd = cmd.ExecuteReader();
            Item = new List<Promocion>();
            while (rd.Read())
            {
                var item = new Promocion
                {
                    Id = rd["id_promocion"].ToString(),
                    Titulo = rd["titulo"].ToString(),
                    Descripcion = rd["descripcion"].ToString(),
                    Producto = rd["producto"].ToString(),
                    PrecioOriginal = int.Parse(rd["precio_original"].ToString()),
                    PrecioPromocion = int.Parse(rd["precio_promocion"].ToString()),
                    PorcentajeDesc = int.Parse(rd["porcentaje_descuento"].ToString()),
                    Imagen = rd["imagen"].ToString(),
                    Detalles = rd["detalles"].ToString(),
                    Condiciones = rd["condiciones"].ToString()
                };
                Item.Add(item);
            }
            conexion.Close();
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {

            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie == null) return;
            var cookieValue = authCookie.Value;

            if (String.IsNullOrWhiteSpace(cookieValue)) return;
            var ticket = FormsAuthentication.Decrypt(cookieValue);

            if (Request.Cookies[".ASPXAUTH"] != null)
            {
                int id = 0;
                int cedula = int.Parse(ticket.UserData);
                string idpromocion = this.txtIdPromocion.Text;

                int aId = 0;
                int aCedula = int.Parse(ticket.UserData);
                string desc = "Venta realizada";
                DateTime aFecha = DateTime.Now;

                Audith audith = new Audith(aId, aCedula, desc, aFecha);
                Venta unaVenta = new Venta(id, idpromocion, cedula);
            if (controladora.AltaVenta(unaVenta))
            {
                    controladora.AltaAudith(audith);
                    this.txtMensaje.InnerText = "Compra realizada con éxito";
                    this.txtIdPromocion.Text = "";
            }
            }
            else
            {
                Response.Redirect("~/Presentacion/wfrmLoginUsuario");
            }
        }
    }
}
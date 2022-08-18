using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TODOOFERTAS.Dominio;

namespace TODOOFERTAS.Presentacion
{
    public partial class wfrmInicio : System.Web.UI.Page
    {
        Controladora controladora = new Controladora();
        protected void Page_Load(object sender, EventArgs e)
        {
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie == null) return;
            var cookieValue = authCookie.Value;

            if (String.IsNullOrWhiteSpace(cookieValue)) return;
            var ticket = FormsAuthentication.Decrypt(cookieValue);

            Administrador admin = controladora.BuscarAdminCi(int.Parse(ticket.UserData));

            if (Request.Cookies[".ASPXAUTH"] == null)
            {
                Response.Redirect("~/Presentacion/wfrmLoginUsuario");
            }

            if (admin == null)
            {
                Response.Redirect("~/Presentacion/wfrmLogin");
            }

            txtIdProm.Attributes.Add("onkeypress", "LetrasYNumeros(event);");
            txtTitulo.Attributes.Add("onkeypress", "LetrasNumerosYEspacios(event);");
            txtProducto.Attributes.Add("onkeypress", "LetrasNumerosYEspacios(event);");
            txtPrecioOriginal.Attributes.Add("onkeypress", "SoloNumeros(event);");
            txtPorcentajeDescuento.Attributes.Add("onkeypress", "SoloNumeros(event);");

            if (!IsPostBack)
            {
                this.Listar();
            }
        }

        private bool FaltanDatos()
        {
            if (this.txtTitulo.Value == "" || this.txtDescripcion.Value == "" || this.txtPrecioOriginal.Value == "" || this.txtFecha.Value == "" || this.txtPorcentajeDescuento.Value == "" || this.txtImagen.Value == "" || this.txtDetalles.Value == "" || this.txtCondiciones.Value == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Limpiar()
        {
            this.txtIdProm.Value = null;
            this.txtTitulo.Value = null;
            this.txtDescripcion.Value = null;
            this.txtProducto.Value = null;
            this.txtPrecioOriginal.Value = null;
            this.txtPrecioDescuento.Value = null;
            this.txtPorcentajeDescuento.Value = null;
            this.txtImagen.Value = null;
            this.txtDetalles.Value = null;
            this.txtCondiciones.Value = null;
            this.txtFecha.Value = null;
        }

        private void Listar()
        {
            this.lstPromocion.DataSource = null;
            this.lstPromocion.DataSource = controladora.listaPromocion();
            this.lstPromocion.DataBind();
        }

        protected void lstPromocion_Click(object sender, EventArgs e)
        {
            if (this.lstPromocion.SelectedIndex > -1)
            {
                string linea = this.lstPromocion.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                string id = partes[0];

                Promocion promocion = controladora.buscarPromocion(id);
                this.txtIdProm.Value = Convert.ToString(promocion.Id);
                this.txtTitulo.Value = Convert.ToString(promocion.Titulo);
                this.txtDescripcion.Value = Convert.ToString(promocion.Descripcion);
                this.txtProducto.Value = Convert.ToString(promocion.Producto);
                this.txtPrecioOriginal.Value = Convert.ToString(promocion.PrecioOriginal);
                this.txtPrecioDescuento.Value = Convert.ToString(promocion.PrecioPromocion);
                this.txtPorcentajeDescuento.Value = Convert.ToString(promocion.PorcentajeDesc);
                this.txtImagen.Value = Convert.ToString(promocion.Imagen);
                this.txtDetalles.Value = Convert.ToString(promocion.Detalles);
                this.txtCondiciones.Value = Convert.ToString(promocion.Condiciones);
                this.txtFecha.Value = promocion.Fecha.ToString("yyyy-MM-dd");
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            Promocion unaPromocion = controladora.buscarPromocion(this.txtIdProm.Value);

            if(unaPromocion == null) {
                if (!this.FaltanDatos())
                {
                    var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

                    if (authCookie == null) return;
                    var cookieValue = authCookie.Value;

                    if (String.IsNullOrWhiteSpace(cookieValue)) return;
                    var ticket = FormsAuthentication.Decrypt(cookieValue);

                    string id = this.txtIdProm.Value;
                    string titulo = this.txtTitulo.Value;
                    string producto = this.txtProducto.Value;
                    string descripcion = this.txtDescripcion.Value;
                    int precioOriginal = int.Parse(this.txtPrecioOriginal.Value);
                    int precioDescuento = 0;
                    int porcentajeDescuento = int.Parse(this.txtPorcentajeDescuento.Value);
                    string imagen = this.txtImagen.Value;
                    string detalles = this.txtDetalles.Value;
                    string condiciones = this.txtCondiciones.Value;
                    DateTime fecha = DateTime.Parse(this.txtFecha.Value);

                    int aId = 0;
                    int cedula = int.Parse(ticket.UserData);
                    string desc = "Agrego Promocion";
                    DateTime aFecha = DateTime.Now;

                    Audith audith = new Audith(aId, cedula, desc, aFecha);
                    Promocion promocion = new Promocion(id, producto, titulo, descripcion, precioOriginal, precioDescuento, porcentajeDescuento, imagen, detalles, condiciones, fecha);
                    if (controladora.insertTablaPromocion(promocion))
                    {
                        controladora.AltaAudith(audith);

                        this.txtMensaje.InnerText = "Promocion ingresada con éxito!";
                        this.Listar();
                        this.Limpiar();
                    }
                    else
                    {
                        this.txtMensaje.InnerText = "Ocurrió un error. Intente nuevamente";
                    }
                }
                else
                {
                    this.txtMensaje.InnerText = "Faltan datos";
                }
            }
            else
            {
                this.txtMensaje.InnerText = "Ya existe una promoción con esa id";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!FaltanDatos())
            {
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

                if (authCookie == null) return;
                var cookieValue = authCookie.Value;

                if (String.IsNullOrWhiteSpace(cookieValue)) return;
                var ticket = FormsAuthentication.Decrypt(cookieValue);

                int aId = 0;
                int cedula = int.Parse(ticket.UserData);
                string desc = "Elimino promoción";
                DateTime aFecha = DateTime.Now;

                Audith audith = new Audith(aId, cedula, desc, aFecha);
                string idProm = txtIdProm.Value;
                if (controladora.eliminarPromocion(idProm))
                {
                    controladora.AltaAudith(audith);
                    this.txtMensaje.InnerText = "Basado";
                    this.Listar();
                    this.Limpiar();
                }
                else
                {
                    this.txtMensaje.InnerText = "Basado2";
                }
            }
            else
            {
                this.txtMensaje.InnerText = "Basado3";
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!FaltanDatos())
            {
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

                if (authCookie == null) return;
                var cookieValue = authCookie.Value;

                if (String.IsNullOrWhiteSpace(cookieValue)) return;
                var ticket = FormsAuthentication.Decrypt(cookieValue);

                int aId = 0;
                int cedula = int.Parse(ticket.UserData);
                string desc = "Modifico promoción";
                DateTime aFecha = DateTime.Now;

                string id = txtIdProm.Value;
                string titulo = this.txtTitulo.Value;
                string producto = this.txtProducto.Value;
                string descripcion = this.txtDescripcion.Value;
                int precioOriginal = int.Parse(this.txtPrecioOriginal.Value);
                int precioDescuento = 0;
                int porcentajeDescuento = int.Parse(this.txtPorcentajeDescuento.Value);
                string imagen = this.txtImagen.Value;
                string detalles = this.txtDetalles.Value;
                string condiciones = this.txtCondiciones.Value;
                DateTime fecha = DateTime.Parse(this.txtFecha.Value);

                Audith audith = new Audith(aId, cedula, desc, aFecha);
                Promocion promocion = new Promocion(id, producto, titulo, descripcion, precioOriginal, precioDescuento, porcentajeDescuento, imagen, detalles, condiciones, fecha);
                if (controladora.modificarPromocion(promocion))
                {
                    controladora.AltaAudith(audith);
                    this.txtMensaje.InnerText = "Basado";
                    this.Listar();
                    this.Limpiar();
                }
                else
                {
                    this.txtMensaje.InnerText = "Basado2";
                }
            }
            else
            {
                this.txtMensaje.InnerText = "Basado3";
            }
        }
    }
}
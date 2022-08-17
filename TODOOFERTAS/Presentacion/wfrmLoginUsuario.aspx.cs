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
    public partial class wfrmLoginUsuario : System.Web.UI.Page
    {
        Controladora controladora = new Controladora();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCedula.Attributes.Add("onkeypress", "SoloNumeros(event);");
        }

        #region Métodos auxiliares
        private bool faltanDatos()
        {
            if (this.txtCedula.Text == "" || this.txtCedula.Text == "")
            {
                return true;
            }
            return false;
        }
        #endregion

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (!this.faltanDatos())
            {
                int cedula = int.Parse(this.txtCedula.Text);
                string password = Encriptacion.Encriptar(this.txtPassword.Text);

                Usuario usuario = controladora.BuscarUsuario(cedula, password);
                Usuario usuario2 = controladora.BuscarUsuarioCi(cedula);
                if (usuario != null && usuario2.Intentos < 3)
                {
                    FormsAuthenticationTicket tkt;
                    string cookiestr;
                    HttpCookie ck;
                    tkt = new FormsAuthenticationTicket(1, txtCedula.Text, DateTime.Now,
                    DateTime.Now.AddMinutes(90), chkPersistCookie.Checked, usuario.Ci.ToString());
                    cookiestr = FormsAuthentication.Encrypt(tkt);
                    ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                    if (chkPersistCookie.Checked)
                        ck.Expires = tkt.Expiration;
                    ck.Path = FormsAuthentication.FormsCookiePath;
                    Response.Cookies.Add(ck);

                    int aId = 0;
                    int acedula = cedula;
                    string desc = "Inició sesion";
                    DateTime aFecha = DateTime.Now;

                    Audith audith = new Audith(aId, acedula, desc, aFecha);
                    controladora.AltaAudith(audith);
                    controladora.ResetUser(cedula);

                    Response.Redirect("~/Presentacion/wfrmInicio.aspx");
                }
                else if (usuario2 != null && (usuario == null && usuario2.Intentos >= 3 || usuario != null && usuario2.Intentos >= 3))
                {
                    this.txtMensaje.InnerText = "Limite de intentos incorrectos";
                }
                else if (usuario == null && (usuario2 == null || usuario2.Intentos < 3))
                {
                    this.txtMensaje.InnerText = "Datos incorrectos";

                    if (controladora.BuscarUsuarioCi(cedula) != null)
                    {
                        int aId = 0;
                        int acedula = cedula;
                        string desc = "Inicio de sesion fallido";
                        DateTime aFecha = DateTime.Now;

                        Audith audith = new Audith(aId, acedula, desc, aFecha);
                        controladora.AltaAudith(audith);
                        controladora.intentosUsuario(cedula);
                    }
                }

            }
            else
            {
                this.txtMensaje.InnerText = "Faltan datos";
            }
        }
    }
}
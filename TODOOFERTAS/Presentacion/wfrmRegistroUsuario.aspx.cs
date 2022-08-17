using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TODOOFERTAS.Dominio;

namespace TODOOFERTAS.Presentacion
{
    public partial class wfrmRegistroUsuario : System.Web.UI.Page
    {
        Controladora controladora = new Controladora();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCedula.Attributes.Add("onkeypress", "SoloNumeros(event);");
            txtNombre.Attributes.Add("onkeypress", "SoloLetras(event);");
        }

        #region Métodos auxiliares
        private void limpiar()
        {
            this.txtCedula.Text = "";
            this.txtNombre.Text = "";
            this.txtPassword.Text = "";
        }

        private bool faltanDatos()
        {
            if (this.txtCedula.Text == "" || this.txtNombre.Text == "" || this.txtPassword.Text == "")
            {
                return true;
            }
            return false;
        }
        #endregion

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            if (!this.faltanDatos())
            {
                Usuario usuario = controladora.BuscarUsuarioCi(int.Parse(this.txtCedula.Text));

                if (usuario == null)
                {
                    int cedula = int.Parse(this.txtCedula.Text);
                    string nombre = this.txtNombre.Text;
                    string password = Encriptacion.Encriptar(this.txtPassword.Text);
                    int intentos = 0;
                    Usuario unUsuario = new Usuario(cedula, nombre, password, intentos);
                    if (controladora.AltaUsuario(unUsuario))
                    {
                        this.txtMensaje.InnerText = "Registrado con éxito";
                        this.limpiar();
                    }
                    else
                    {
                        this.txtMensaje.InnerText = "F";
                    }
                }
                else
                {
                    this.txtMensaje.InnerText = "Ya existe un usuario con esa cédula.";
                }
            }
            else
            {
                this.txtMensaje.InnerText = "Faltan datos";
            }
        }
    }
}
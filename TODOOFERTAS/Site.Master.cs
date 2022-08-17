using Sentry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;


namespace TODOOFERTAS
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies[".ASPXAUTH"] == null)
                {
                    this.login.InnerText = "Iniciar Sesion";
                }
                else
                {
                    this.login.InnerText = "Cerrar Sesion";
                }
            }
            using (SentrySdk.Init(o =>
            {
                o.Dsn = "https://b8a0fb927e86469192bfa0c5ca6ccbcf@o1362174.ingest.sentry.io/6653444";
                // When configuring for the first time, to see what the SDK is doing:
                o.Debug = true;
                // Set traces_sample_rate to 1.0 to capture 100% of transactions for performance monitoring.
                // We recommend adjusting this value in production.
                o.TracesSampleRate = 1.0;
            })) ;
        }

        protected void Login(object sender, EventArgs e)
        {
            if (this.login.InnerText == "Iniciar Sesion")
            {
                Response.Redirect("~/Presentacion/wfrmLoginUsuario");
            }
            if (this.login.InnerText == "Cerrar Sesion")
            {
                if (Request.Cookies[".ASPXAUTH"] != null)
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/Presentacion/wfrmInicio");
                }
            }
        }

    }
}
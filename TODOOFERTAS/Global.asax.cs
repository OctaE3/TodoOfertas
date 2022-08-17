using Sentry;
using Sentry.AspNet;
using Sentry.EntityFramework;
using Sentry.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace TODOOFERTAS
{
    public class Global : HttpApplication
    {
        private IDisposable _sentry;
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            _sentry = SentrySdk.Init(o =>
            {
                o.AddAspNet();
                o.Dsn = "https://fb4aad60bb67406aa7e22a72067f4ecd@o1362204.ingest.sentry.io/6653497";
                // When configuring for the first time, to see what the SDK is doing:
                o.Debug = true;
                // Set TracesSampleRate to 1.0 to capture 100%
                // of transactions for performance monitoring.
                // We recommend adjusting this value in production
                o.TracesSampleRate = 1.0;
                // If you are using EF (and installed the NuGet package):
                o.AddEntityFramework();
            });
        }

        protected void Application_Error() => Server.CaptureLastError();

        protected void Application_BeginRequest()
        {
            Context.StartSentryTransaction();
        }

        protected void Application_EndRequest()
        {
            Context.FinishSentryTransaction();
        }

        protected void Application_End()
        {
            // Flushes out events before shutting down.
            _sentry?.Dispose();
        }
    }
}
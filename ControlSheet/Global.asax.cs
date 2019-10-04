using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ControlSheet
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static NLog.Logger _logger;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //LogManager.LoadConfiguration(ConfigurationManager.AppSettings["PathNLog"]);
            ////_loggingConfiguration = new LoggingConfiguration();
            ////LogManager.Configuration = _loggingConfiguration;
            //_logger = LogManager.GetCurrentClassLogger();
        }
    }
}

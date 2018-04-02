using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace CheckoutTomasRito
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}

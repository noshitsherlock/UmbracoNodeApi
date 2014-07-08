using System.Reflection;
using System.Web.Http.Filters;
using log4net;

namespace Noshitsherlock.UmbracoNodeApi
{
    public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
    {
        public static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response != null)
            {
                //Log.Info("RequestUri : " + actionExecutedContext.Response.RequestMessage.RequestUri.Host.ToLower());

                if (actionExecutedContext.Response.RequestMessage.RequestUri.Host.ToLower() == "localhost" || actionExecutedContext.Response.RequestMessage.RequestUri.Host.ToLower() == "preview.area.eelab.se")
                    actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            }

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Swashbuckle.Application;

namespace ASF.Hosts.Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {

                    var baseDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\bin\";
                    var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                    var commentsFile = Path.Combine(baseDirectory, commentsFileName);

                    c.SingleApiVersion("v1", "Eduardo Acosta")
                        .Description("Web Api")
                        .TermsOfService("")
                        .Contact(cc => cc
                            .Name("Eduardo Acosta")
                            .Url("")
                            .Email(""))
                        .License(lc => lc
                            .Name("")
                            .Url(""));
                })
                .EnableSwaggerUi();
        }
    }
}
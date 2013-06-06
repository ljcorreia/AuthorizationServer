﻿using System.IdentityModel.Services;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Thinktecture.AuthorizationServer.Interfaces;

namespace Thinktecture.AuthorizationServer.WebHost
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            AutofacConfig.Configure();

            TestData.Populate();
            TestData.Test();

            FederatedAuthentication.FederationConfigurationCreated += FederatedAuthentication_FederationConfigurationCreated;
        }

        void FederatedAuthentication_FederationConfigurationCreated(object sender, System.IdentityModel.Services.Configuration.FederationConfigurationCreatedEventArgs e)
        {
            var svc = DependencyResolver.Current.GetService<IAuthorizationServerAdministratorsService>();
            e.FederationConfiguration.IdentityConfiguration.ClaimsAuthenticationManager = new AuthorizationServerClaimsTransformer(svc);
        }

        void Application_EndRequest()
        {
            //if (Response.StatusCode == 401 && 
            //    !User.Identity.IsAuthenticated)
            //{
            //    var app = Request.RequestContext.RouteData.Values["application"];
            //    var originalUrl = Request.Url.AbsoluteUri;
            //    // logic here for a 302....
            //}
        }
    }
}
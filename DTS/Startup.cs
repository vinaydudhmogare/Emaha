using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using DTS.Providers;

[assembly: OwinStartup(typeof(DTS.Startup))]

namespace DTS
{
    public partial  class Startup
    {
        public void Configuration(IAppBuilder app)
        {    
            ConfigureAuth(app);
        }
    }
}

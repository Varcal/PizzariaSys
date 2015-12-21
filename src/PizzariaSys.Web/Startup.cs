using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using PizzariaSys.Web;

[assembly: OwinStartup(typeof(Startup))]

namespace PizzariaSys.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}

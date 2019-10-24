using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Otc.AspNetCore.ApiBoot;
using Otc.WebHostedWorker;
using System.Diagnostics.CodeAnalysis;

namespace WebHostedWorker.Template
{
    /// <summary>
    /// WebHostedWorker Startup class. 
    /// </summary>
    public class Startup : WebHostedWorkerStartup<HostedWorker>
    {
        protected override ApiMetadata ApiMetadata => new ApiMetadata()
        {
            Name = "WebHostedWorker.Template",
            Description = "This project is based in WebHostedWorker package " +
                "(https://github.com/OleConsignado/otc-hosted-worker).",
            DefaultApiVersion = "1.0"
        };

        public Startup(IConfiguration configuration)
            : base(configuration)
        {

        }

        //
        // IMPORTANT
        // You should not override ConfigureApiServices method, 
        // implement ConfigureWebHostedWorkerServices in order to register worker dependencies.
        //

        /// <summary>
        /// Worker dependencies registration.
        /// </summary>
        /// <param name="services">The service collection</param>
        protected override void ConfigureWebHostedWorkerServices(IServiceCollection services)
        {
            // Worker dependencies registration goes here
        }
    }
}

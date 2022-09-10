using System;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Softplan.Common.Authorization.Abstractions.Services;
using Softplan.Common.Core.Entities.Abstractions;
using Softplan.Common.Graph.Client.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.CommandStack.MPC;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.MCD;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.PTC;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.TAX;
using Softplan.MP.DistribuicaoSegundoGrau.Gateway.USR;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.Authorization;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.MCD;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.MCP;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.PTC;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.TAX;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.USR;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration, IWebHostEnvironment env) : base(configuration, env)
        {
        }

        protected override void ConfigureAutoMapper(IServiceProvider services, IMapperConfigurationExpression configuration)
        {
            base.ConfigureAutoMapper(services, configuration);
            configuration.AddMaps(Assembly.GetExecutingAssembly());
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            
            services.RemoveAll<IGatewayService>();
            services.AddSingleton<IMpcGatewayService, MPCTestGatewayService>();
            services.AddSingleton<IMcdGatewayService, McdTestGatewayService>();
            services.AddSingleton<IPtcGatewayService, PtcTestGatewayService>();
            services.AddSingleton<IUsrGatewayService, UsrTestGatewayService>();
            services.AddSingleton<ITaxGatewayService, TaxTestGatewayService>();
            
            services.RemoveAll<IAuthorizationService>();
            services.AddSingleton<IAuthorizationService, DisabledAuthorizationService>();
        }

        public override void Configure(IApplicationBuilder app)
        {
            app.UseJobs(Configuration);
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("lotacao", "2");
                context.Request.Headers.Add("lotacao", "2");
                await next.Invoke();
            });
            base.Configure(app);
            if (Configuration.GetValue("DATABASE_PROVIDER", "InMemory") == "InMemory") return;
            Configuration.RunSajMigrationsWhenSeedIsEnabled();
        }
    }
}
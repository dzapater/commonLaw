using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Softplan.Common.Authorization.AuthorizationTypes;
using Softplan.Common.Graph.Extensions;
using Softplan.Common.Graph.SchemaExtension;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Extensions;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph;
using Softplan.SAJ.MP.AspNetCore.Abstractions;
using Softplan.SAJ.MP.Authorization.Extensions;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi
{
    public class Startup : MpStartup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env) : base(configuration, env)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IExtensibleSchema, DistribuicaoSegundoGrauSchema>();
            services.AddInfrastructure(Configuration);
            base.ConfigureServices(services);
            services.AddMpAuthorization(LoadAuthorizationFromFile());
        }

        public override void Configure(IApplicationBuilder app)
        {
            app.MapAuthorizationTypesEndpoint();
            app.UseInfrastructure(Configuration);
            app.UseJobs(Configuration);
            base.Configure(app);
            app.UseGraphQlSchema<IExtensibleSchema>("DSG");
        }

        protected override void ConfigureAutoMapper(IServiceProvider services,
            IMapperConfigurationExpression configuration)
        {
            configuration.ConfigureApplication();
        }
        
        private static IAuthorizationTypesConfiguration LoadAuthorizationFromFile()
        {
            var filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new InvalidOperationException();
            var map = File.ReadAllText(Path.Combine(filePath, "authorizationsettings.json"));
            return JsonConvert.DeserializeObject<AuthorizationTypesConfiguration>(map);
        }
    }
}
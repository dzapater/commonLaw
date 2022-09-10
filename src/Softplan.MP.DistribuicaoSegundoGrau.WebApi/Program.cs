using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Hosting;
using Softplan.Common.AspNetCore.Abstractions;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi
{
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        public static void Main(params string[] args) => 
            CreateWebHostBuilder(args).Build().Run();

        private static IWebHostBuilder CreateWebHostBuilder(params string[] args) =>
            SoftplanWebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
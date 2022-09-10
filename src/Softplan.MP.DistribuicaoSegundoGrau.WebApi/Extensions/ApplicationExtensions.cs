using FluentValidation;
using GraphQL.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Softplan.Common.Job.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Jobs;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Extensions
{
    public static class ApplicationExtensions
    {
        public static void UseInfrastructure(this IApplicationBuilder app, IConfiguration configuration)
        {
            ValidatorOptions.Global.CascadeMode = CascadeMode.StopOnFirstFailure;
            
            configuration.RunMigrationsWhenSeedIsEnabled();
        }
        
        public static void UseJobs(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.ApplicationServices.GetRequiredService<IJobSchedulerProducer>().ProduceRecurringJob<DistribuicaoVagaJobEntry>(nameof(DistribuicaoVagaJobEntry), job => job.Processar()
                , () => configuration.GetValue("DIST_PROC_JOB", "* * * * *"));
        }
    }
}
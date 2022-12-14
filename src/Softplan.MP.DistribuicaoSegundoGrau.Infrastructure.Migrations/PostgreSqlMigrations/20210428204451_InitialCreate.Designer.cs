// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Migrations.PostgreSqlMigrations
{
    [DbContext(typeof(PostgreSqlMigrationsDbContext))]
    [Migration("20210428204451_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("saj_dsg")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);
#pragma warning restore 612, 618
        }
    }
}

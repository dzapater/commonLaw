using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.Parametros.Repositories.Maps
{
    public static class ParamentroMapConfig
    {
        private const string Schema = "SAJ";

        public static void ApplyParametroConfigurations(this ModelBuilder modelBuilder, bool toLowerCase)
        {
            modelBuilder.ApplyConfiguration(new ParametroMap(MapSchema(toLowerCase)));
        }

        private static string MapSchema(bool isDatabasePropertiesConvertCaseToLowerCase)
            => isDatabasePropertiesConvertCaseToLowerCase ? Schema.ToLower(CultureInfo.InvariantCulture) : Schema;
    }
}
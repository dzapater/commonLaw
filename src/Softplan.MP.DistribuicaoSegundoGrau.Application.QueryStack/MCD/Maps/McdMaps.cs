using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.MCD.Maps
{
    public static class McdMaps
    {
        private const string Schema = "SAJ";

        public static void ApplyMcdConfigurations(this ModelBuilder modelBuilder, bool toLowerCase)
        {
            modelBuilder.ApplyConfiguration(new EspecialidadeReadModelMap(MapSchema(toLowerCase)));
        }

        private static string MapSchema(bool isDatabasePropertiesConvertCaseToLowerCase)
            => isDatabasePropertiesConvertCaseToLowerCase ? Schema.ToLower(CultureInfo.InvariantCulture) : Schema;
    }
}
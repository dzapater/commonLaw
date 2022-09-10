using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.TAX.Maps
{
    public static class TaxMaps
    {
        private const string Schema = "SAJ";
        public static void ApplyTaxonomiaConfigurations(this ModelBuilder modelBuilder, bool toLowerCase)
        {
            modelBuilder.ApplyConfiguration(new AssuntoReadModelMap(MapSchema(toLowerCase)));
            modelBuilder.ApplyConfiguration(new ClasseReadModelMap(MapSchema(toLowerCase)));
            modelBuilder.ApplyConfiguration(new ForoReadModelMap(MapSchema(toLowerCase)));
            modelBuilder.ApplyConfiguration(new VaraReadModelMap(MapSchema(toLowerCase)));
            modelBuilder.ApplyConfiguration(new TarjaReadModelMap(MapSchema(toLowerCase)));
        }
        private static string MapSchema(bool isDatabasePropertiesConvertCaseToLowerCase)
            => isDatabasePropertiesConvertCaseToLowerCase ? Schema.ToLower(CultureInfo.InvariantCulture) : Schema;
    }
}
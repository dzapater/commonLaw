using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Cadastros.VinculoMembroVagas.Maps
{
    public static class VinculoMembroVagasMaps
    {
        private const string Schema = "SAJ";

        public static void ApplyVinculoMembroVagaConfigurations(this ModelBuilder modelBuilder, bool toLowerCase)
        {
            modelBuilder.ApplyConfiguration(new MotivoMembroVagaReadModelMap(MapSchema(toLowerCase)));
        }

        private static string MapSchema(bool isDatabasePropertiesConvertCaseToLowerCase)
            => isDatabasePropertiesConvertCaseToLowerCase ? Schema.ToLower(CultureInfo.InvariantCulture) : Schema;
    }
}
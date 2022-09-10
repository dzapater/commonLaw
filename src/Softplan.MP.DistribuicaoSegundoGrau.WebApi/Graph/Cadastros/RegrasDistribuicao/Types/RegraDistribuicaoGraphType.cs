using GraphQL.Types;
using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.RegrasDistribuicao.Types
{
    public class RegraDistribuicaoGraphType : Softplan.Common.Graph.Types.ObjectGraphType<RegraDistribuicao>
    {
        public RegraDistribuicaoGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.Id);
            Field(x => x.Descricao);
            Field(x => x.Ativo);
            Field(x => x.Metadata, type: typeof(MetadataGraphType));
            Field(x => x.TipoProcesso, true, type: typeof(TipoProcessoGraphType));
            Field(x => x.Area, true, type: typeof(AreaGraphType));
            Field(x => x.VariavelEquilibrio, type: typeof(VariavelEquilibrioGraphType));
            Field(x => x.EscopoEquilibrio, type: typeof(EscopoEquilibrioGraphType));
            Field(x => x.Especialidades, true, typeof(ListGraphType<EspecialidadeGraphType>));
            Field(x => x.Assuntos, true, typeof(ListGraphType<AssuntoGraphType>));
            Field(x => x.Classes, true, typeof(ListGraphType<ClasseGraphType>));
            Field(x => x.Tarjas, true, typeof(ListGraphType<TarjaGraphType>));
            Field(x => x.Unidades, true, typeof(ListGraphType<UnidadeGraphType>));
            Field(x => x.OrgaosJulgadores, true, typeof(ListGraphType<OrgaoJulgadorGraphType>));
        }
    }
}
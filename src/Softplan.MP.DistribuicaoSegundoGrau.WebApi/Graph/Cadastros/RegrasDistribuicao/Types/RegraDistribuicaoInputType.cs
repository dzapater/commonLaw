using GraphQL.Types;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Cadastros.RegrasDistribuicao.Types
{
    public abstract class RegraDistribuicaoInputType : Softplan.Common.Graph.Types.InputObjectGraphType<RegraDistribuicao>
    {
        protected RegraDistribuicaoInputType()
        {
            Field(x => x.Descricao);
            Field(x => x.Ativo);
            Field(x => x.TipoProcesso, true, type: typeof(TipoProcessoGraphType));
            Field(x => x.Area, true, type: typeof(AreaGraphType));
            Field(x => x.VariavelEquilibrio, type: typeof(VariavelEquilibrioGraphType));
            Field(x => x.EscopoEquilibrio, type: typeof(EscopoEquilibrioGraphType));
            Field(x => x.Especialidades, true, typeof(ListGraphType<EspecialidadeInputType>));
            Field(x => x.Assuntos, true, typeof(ListGraphType<RegraDistribuicaoAssuntoInputType>));
            Field(x => x.Classes, true, typeof(ListGraphType<RegraDistribuicaoClasseInputType>));
            Field(x => x.Tarjas, true, typeof(ListGraphType<RegraDistribuicaoTarjaInputGraphType>));
            Field(x => x.Unidades, true, typeof(ListGraphType<RegraDistribuicaoUnidadeInputType>));
            Field(x => x.OrgaosJulgadores, true, typeof(ListGraphType<RegraDistribuicaoOrgaoJulgadorInputType>));
        }
    }
}
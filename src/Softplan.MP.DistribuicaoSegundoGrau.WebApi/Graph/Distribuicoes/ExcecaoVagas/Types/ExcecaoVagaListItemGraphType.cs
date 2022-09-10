using Softplan.Common.Graph.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Application.QueryStack.Distribuicoes.ExcecaoVagas;
using Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Types;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Graph.Distribuicoes.ExcecaoVagas.Types
{
    public class ExcecaoVagaListItemGraphType: Softplan.Common.Graph.Types.ObjectGraphType<ExcecaoVagaReadModel>
    {
        public ExcecaoVagaListItemGraphType(IDescriptionProvider descriptionProvider) : base(descriptionProvider)
        {
            Field(x => x.ExcecaoVaga.Id);
            Field(x => x.ExcecaoVaga.IdVaga);
            Field(x => x.ExcecaoVaga.IdAssunto, true);
            Field(x => x.ExcecaoVaga.IdClasse, true);
            Field(x => x.ExcecaoVaga.IdEspecialidade, true);
            Field(x => x.ExcecaoVaga.IdOrgaoJulgador, true);
            Field(x => x.ExcecaoVaga.IdOrigem, true);
            Field(x => x.ExcecaoVaga.IdUnidade, true);
            Field(x => x.ExcecaoVaga.Motivo, true);
            Field(x => x.ExcecaoVaga.Especialidade, true, typeof(EspecialidadeGraphType));
            Field(x => x.ExcecaoVaga.Assunto, true, typeof(AssuntoGraphType));
            Field(x => x.ExcecaoVaga.Classe, true, typeof(ClasseGraphType));
            Field(x => x.ExcecaoVaga.Origem, true, typeof(OrigemGraphType));
            Field(x => x.ExcecaoVaga.Unidade, true, typeof(UnidadeGraphType));
            Field(x => x.ExcecaoVaga.OrgaoJulgador, true, typeof(OrgaoJulgadorGraphType));
        }
    }
}
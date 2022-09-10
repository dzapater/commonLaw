using System.Collections.Generic;
using System.Diagnostics;
using Softplan.Common.Core.Entities;
using Softplan.Common.Core.Entities.Abstractions;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Criterios;
using Softplan.MP.DistribuicaoSegundoGrau.Domain.Valores;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Cadastros.RegrasDistribuicao
{
    public class RegraDistribuicao : IdRegraDistribuicao, IDomainModel
    {
        public EntityMetadata Metadata { get; set; } = EntityMetadata.New;
        public TipoProcesso? TipoProcesso { get; set; }
        public Area? Area { get; set; }
        public VariavelEquilibrio VariavelEquilibrio { get; set; } = VariavelEquilibrio.Indefinido;
        public EscopoEquilibrio EscopoEquilibrio { get; set; } = EscopoEquilibrio.Indefinido;
        public ICollection<CriterioEspecialidade> Especialidades { get; set; } = new List<CriterioEspecialidade>();
        public ICollection<CriterioAssunto> Assuntos { get; set; } = new List<CriterioAssunto>();
        public ICollection<CriterioClasse> Classes { get; set; } = new List<CriterioClasse>();
        public ICollection<CriterioTarja> Tarjas { get; set; } = new List<CriterioTarja>();
        public ICollection<CriterioUnidade> Unidades { get; set; } = new List<CriterioUnidade>();
        public ICollection<CriterioOrgaoJulgador> OrgaosJulgadores { get; set; } = new List<CriterioOrgaoJulgador>();
        public ICollection<IVinculoVaga> VinculoVagas { get; set; } = new List<IVinculoVaga>();
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public int CdLocal { get; set; }

        public bool SemCriterios() => ValidarCriterios();

        private bool ValidarCriterios() => Especialidades.Count == 0 && Assuntos.Count == 0 &&
                                           Unidades.Count == 0 && OrgaosJulgadores.Count == 0 && Tarjas.Count == 0 &&
                                           Classes.Count == 0 && Area == null;
        
    }
}
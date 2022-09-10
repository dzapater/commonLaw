using System.Collections.Generic;
using Softplan.Common.Core.Entities;

namespace Softplan.MP.DistribuicaoSegundoGrau.Gateway.Messages
{
    public class ConsultaProcessoResponseMessage : SimpleId<string>
    {
        public string Status { get; set; }
        public int Volumes { get; set; }
        public AssuntoResponseMessage Assunto { get; set; }
        public ClasseResponseMessage Classe { get; set; }
        public EspecialidadeResponseMessage Especialidade { get; set; }
        public OrgaoJulgadorResponseMessage OrgaoJulgador { get; set; }
        public List<AreaProcessoResponseMessage> Areas { get; set; }
        public List<TarjaResponseMessage> Tarjas { get; set; } = new List<TarjaResponseMessage>();
    }
  
}
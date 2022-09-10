using System.Collections.Generic;

namespace Softplan.MP.DistribuicaoSegundoGrau.Gateway.Messages
{
    public class ItemsResponseMessage<TEntity>
    {
        public ICollection<TEntity> Items { get; set; }
    }
}
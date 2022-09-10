using Newtonsoft.Json;

namespace Softplan.MP.DistribuicaoSegundoGrau.Domain.Jobs
{
    public abstract class Job<T> : IdJob
    {
        public string Descricao { get; }
        public byte[] RowVersion { get; set; }
        public string PayLoad { get; protected set; }
        public T PayLoadData  =>  JsonConvert.DeserializeObject<T>(PayLoad);
        protected Job()
        {
            Descricao = Id;
        }
        public void UpdatePayload(T payload)
        {
            PayLoad = JsonConvert.SerializeObject(payload);
        }
    }
}
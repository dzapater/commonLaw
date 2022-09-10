using System;
using Softplan.Common.Graph.Client.Abstractions;

namespace Softplan.MP.DistribuicaoSegundoGrau.Infrastructure.IoC
{
    public abstract class BaseGatewayService: IDisposable
    {
        protected IGraphClientFactory GraphClientFactory => _graphClientFactory.Value;
        protected const string ServiceName = "APOLLO";
        
        ~BaseGatewayService() => Dispose(false);
        
        private static Lazy<IGraphClientFactory> _graphClientFactory;
        private bool _disposedValue;

        protected BaseGatewayService(IServiceProvider serviceProvider)
        {
            _graphClientFactory = CriarInstanciaLazy<IGraphClientFactory>(serviceProvider);
        }
        private static Lazy<T> CriarInstanciaLazy<T>(IServiceProvider serviceProvider)
            => new Lazy<T>(() => (T)serviceProvider.GetService(typeof(T)));

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue && disposing)
                GraphClientFactory.GetGraphClient(ServiceName).Dispose();
            
            _disposedValue = true;
        }
        
    }
}
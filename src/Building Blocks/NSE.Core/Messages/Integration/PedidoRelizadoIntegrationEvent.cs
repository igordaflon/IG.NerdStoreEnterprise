using System;

namespace NSE.Core.Messages.Integration
{
    public class PedidoRelizadoIntegrationEvent : IntegrationEvent
    {
        public Guid ClientId { get; private set; }

        public PedidoRelizadoIntegrationEvent(Guid clientId)
        {
            ClientId = clientId;
        }
    }
}

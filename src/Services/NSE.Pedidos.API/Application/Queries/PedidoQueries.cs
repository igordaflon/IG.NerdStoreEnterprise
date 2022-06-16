using NSE.Pedidos.API.Application.DTO;
using NSE.Pedidos.Domain.Pedidos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.Pedidos.API.Application.Queries
{
    public interface IPedidoQueries
    {
        Task<PedidoDTO> ObterUltimoPedido(Guid clienteId);
        Task<IEnumerable<PedidoDTO>> ObterListaPorClienteId(Guid clienteId); 
    }

    public class PedidoQueries : IPedidoQueries
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoQueries(IPedidoRepository _pedidoRepository)
        {
            this._pedidoRepository = _pedidoRepository;
        }

        public Task<IEnumerable<PedidoDTO>> ObterListaPorClienteId(Guid clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<PedidoDTO> ObterUltimoPedido(Guid clienteId)
        {
            throw new NotImplementedException();
        }
    }
}

using NSE.WebApp.MVC.Models;
using System;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public interface ICarrinhoService
    {
        Task<ResponseResult> AdicionarItemCarrinho(ItemProdutoViewModel produto);
        Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemProdutoViewModel produto);
        Task<CarrinhoViewModel> ObterCarrinho();
        Task<ResponseResult> RemoverItemCarrinho(Guid produtoId);
    }
}
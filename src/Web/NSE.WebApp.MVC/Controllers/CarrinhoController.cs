using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Services;
using System;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Controllers
{
    public class CarrinhoController : MainController
    {
        private readonly ICarrinhoService _carrinhoService;
        private readonly ICatalogoService _catalogoService;

        public CarrinhoController
        (
             ICarrinhoService _carrinhoService,
             ICatalogoService _catalogoService
        )
        {
            this._carrinhoService = _carrinhoService;
            this._catalogoService = _catalogoService;
        }

        [Route("carrinho")]
        public async Task<IActionResult> Index()
        {
            return View(await _carrinhoService.ObterCarrinho());
        }

        [HttpPost]
        [Route("carrinho/adicionar-item")]
        public async Task<IActionResult> AdicionarItemCarrinho(ItemProdutoViewModel itemProduto)
        {
            var produto = await _catalogoService.ObterPorId(itemProduto.ProdutoId);

            ValidarItemCarrinhho(produto, itemProduto.Quantidade);
            if(!OperacaoValida()) return View("Index", await _carrinhoService.ObterCarrinho());

            itemProduto.Nome = produto.Nome;
            itemProduto.Valor = produto.Valor;
            itemProduto.Imagem = produto.Imagem;

            var resposta = await _carrinhoService.AdicionarItemCarrinho(itemProduto);

            if(ResponsePossuiErros(resposta)) return View("Index", await _carrinhoService.ObterCarrinho());

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("carrinho/atualizar-item")]
        public async Task<IActionResult> AtualizarItemCarrinho(Guid produtoId, int quantidade)
        {
            var produto = await _catalogoService.ObterPorId(produtoId);

            ValidarItemCarrinhho(produto, quantidade);
            if (!OperacaoValida()) return View("Index", await _carrinhoService.ObterCarrinho());

            var itemProduto = new ItemProdutoViewModel { ProdutoId = produtoId, Quantidade = quantidade };
            var resposta = await _carrinhoService.AtualizarItemCarrinho(produtoId, itemProduto);

            if (ResponsePossuiErros(resposta)) return View("Index", await _carrinhoService.ObterCarrinho());

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("carrinho/remover-item")]
        public async Task<IActionResult> RemoverItemCarrinho(Guid produtoId)
        {
            var produto = await _catalogoService.ObterPorId(produtoId);
            if (produto == null)
            {
                AdicionarErroValidacao("Produto inexistente!");
                return View("Index", await _carrinhoService.ObterCarrinho());
            }

            var resposta = await _carrinhoService.RemoverItemCarrinho(produtoId);

            if (ResponsePossuiErros(resposta)) return View("Index", await _carrinhoService.ObterCarrinho());

            return RedirectToAction("Index");
        }

        private void ValidarItemCarrinhho(ProdutoViewModel produto, int quantidade)
        {
            if (produto == null) AdicionarErroValidacao("Produto Inexistente!");
            if (quantidade < 1) AdicionarErroValidacao($"Escolha ao menos uma unidade do produto {produto.Nome}");
            if (quantidade > produto.QuantidadeEstoque) AdicionarErroValidacao($"O produto {produto.Nome} possui {produto.QuantidadeEstoque} unidades em escolhe, você selecionou {quantidade}");
        }
    }
}

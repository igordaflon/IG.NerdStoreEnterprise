using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Services;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Extensions
{
    public class CarrinhoViewComponent : ViewComponent
    {
        private readonly ICarrinhoService _carrinhoService;

        public CarrinhoViewComponent(ICarrinhoService _carrinhoService)
        {
            this._carrinhoService = _carrinhoService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _carrinhoService.ObterCarrinho() ?? new CarrinhoViewModel());
        }
    }
}

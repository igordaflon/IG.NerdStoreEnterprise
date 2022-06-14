using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSE.WebApi.Core.Controllers;
using System.Threading.Tasks;

namespace NSE.Pedidos.API.Controllers
{
    [Authorize]
    public class VoucherController : MainController
    {
        [HttpGet("voucher/{codigo}")]
        public async Task<IActionResult> ObterPorCodigo(string codigo)
        {
            return View();
        }
    }
}

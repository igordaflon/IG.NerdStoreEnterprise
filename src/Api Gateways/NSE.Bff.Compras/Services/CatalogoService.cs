using Microsoft.Extensions.Options;
using NSE.Bff.Compras.Extensions;
using System;
using System.Net.Http;

namespace NSE.Bff.Compras.Services
{
    public interface ICatalogoService
    {

    }

    public class CatalogoService : Service, ICatalogoService
    {
        private readonly HttpClient _httpClient;

        public CatalogoService
        (
            HttpClient _httpClient,
            IOptions<AppServicesSettings> settings
        )
        {
            this._httpClient = _httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CatalogoUrl);
        }
    }
}

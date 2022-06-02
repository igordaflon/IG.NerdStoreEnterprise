using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace NSE.WebApi.Core.Usuario
{

    public class AspNetUser : IAspNetUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AspNetUser(IHttpContextAccessor _accessor)
        {
            this._accessor = _accessor;
        }

        public string Name => _accessor.HttpContext.User.Identity.Name;

        public bool EstaAutenticado()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public IEnumerable<Claim> ObterClaims()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public HttpContext ObterHttpContext()
        {
            return _accessor.HttpContext;
        }

        public string ObterUserEmail()
        {
            return EstaAutenticado() ? _accessor.HttpContext.User.GetUserEmail() : "";
        }

        public Guid ObterUserId()
        {
            return EstaAutenticado() ? Guid.Parse(_accessor.HttpContext.User.GetUserId()) : Guid.Empty;
        }

        public string ObterUsuarioToken()
        {
            return EstaAutenticado() ? _accessor.HttpContext.User.GetUserToken() : "";
        }

        public bool PossuiRole(string role)
        {
            return _accessor.HttpContext.User.IsInRole(role);
        }
    }
}

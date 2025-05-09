using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using DomSalca_E_Commerce_MVC_App.Controllers;


namespace DomSalca_E_Commerce_MVC_App.Controllers
{
    /// <summary>
    /// OWIN’e dış (external) oturum açma sağlayıcısına yönlendirme (challenge) göndermek için kullanılan sınıf.
    /// </summary>
    public class ChallengeResult : HttpUnauthorizedResult
    {
        private const string XsrfKey = "XsrfId";

        public string LoginProvider { get; }
        public string RedirectUri { get; }
        public string UserId { get; }

        public ChallengeResult(string provider, string redirectUri, string userId = null)
        {
            LoginProvider = provider;
            RedirectUri = redirectUri;
            UserId = userId;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var props = new AuthenticationProperties { RedirectUri = RedirectUri };
            if (UserId != null)
                props.Dictionary[XsrfKey] = UserId;

            context.HttpContext
                   .GetOwinContext()
                   .Authentication
                   .Challenge(props, LoginProvider);
        }
    }
}


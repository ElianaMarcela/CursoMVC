using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CursoMVC.Infraestructura
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        // Lista de solo lectura que contiene los roles permitidos
        public readonly string[] AllowRoles;

        public CustomAuthorizeAttribute(params string[] roles)
        {
            this.AllowRoles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {           
            var UserRole = Convert.ToString(httpContext.Session["Perfil"]);
            foreach (var itemRol in AllowRoles)
            {
                if (itemRol == UserRole)
                    return true;                
            }
            return false;
        }

        /// <summary>
        /// Método que se ejecuta cada vez que el método AuthorizeCore retorna false
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    {"controller", "User" },
                    {"action", "Unauthorized" }
                });
        }
    }
}
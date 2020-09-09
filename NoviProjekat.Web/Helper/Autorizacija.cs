using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using NoviProjekat.Data;
using NoviProjekat.Data.EntityModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoviProjekat.Web.Helper
{
    public class AutorizacijaAttribute : TypeFilterAttribute
    {
        public AutorizacijaAttribute(bool prodavac, bool klijenti, bool serviser,bool admin)
            : base(typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] { prodavac, klijenti, serviser,admin };
        }
        public class MyAuthorizeImpl : IAsyncActionFilter
        {
            public MyAuthorizeImpl(bool prodavac, bool klijenti, bool serviser,bool admin)
            {
                _prodavac = prodavac;
                _klijenti = klijenti;
                _serviser = serviser;
                _admin = admin;
            }
            private readonly bool _prodavac;
            private readonly bool _klijenti;
            private readonly bool _serviser;
            private readonly bool _admin;
            public async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
            {
                KorisnickiNalog k = filterContext.HttpContext.GetLogiraniKorisnik();

                if (k == null)
                {
                    if (filterContext.Controller is Controller controller)
                    {
                        controller.TempData["error_poruka"] = "Niste logirani";
                    }

                    filterContext.Result = new RedirectToActionResult("Index", "Autentifikacija", new { @area = "" });
                    return;
                }
                MyContext db = filterContext.HttpContext.RequestServices.GetService<MyContext>();

                if (_prodavac && db.Prodavac.Any(p => p.KorisnickiNalogId == k.Id))
                {
                    await next();
                    return;
                }
                if (_klijenti && db.Klijent.Any(s => s.KorisnickiNalogId == k.Id))
                {
                    await next();
                    return;
                }
                if (_serviser && db.Serviser.Any(s => s.KorisnickiNalogId == k.Id))
                {
                    await next();
                    return;
                }
                if (_admin && db.Admin.Any(s => s.KorisnickiNalogId == k.Id))
                {
                    await next();
                    return;
                }
                if (filterContext.Controller is Controller c1)
                {
                    c1.TempData["eror_poruka"] = "Nemate pravo pristupa";
                }
                filterContext.Result = new RedirectToActionResult("Index", "Autentifikacija", new { @area = "" });
            }
            public void OnActionExecuted(ActionExecutedContext context)
            {

            }

        }
    }
}

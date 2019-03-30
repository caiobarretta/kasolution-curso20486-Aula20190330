using FN.Store.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.UI.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult SignIn() => View();

        [HttpPost]
        public IActionResult SignIn(SignInVM model)
        {
            if (model.Email == "caioabarretta@gmail.com" && model.Senha == "123456")
            {
                //Gerar o cookie
                var claims = new List<Claim>()
                {
                    new Claim("id","1"),
                    new Claim("nome","Caio Barretta"),
                    new Claim("email", model.Email),
                    new Claim("perfils", string.Join(',', (new string[]{ "admin", "ti" })))
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, "email", "perfils");
                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(principal);
                
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    return Redirect(model.ReturnUrl);

                return RedirectToAction("Index", "Produtos");
            }
                return View();
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("SignIn");
        }
    }
}

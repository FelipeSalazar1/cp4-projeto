using ConsultoriaDev.Models;
using ConsultoriaDev.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ConsultoriaDev.Controllers;

public class AdminController : Controller
{
    private readonly DadosMemoriaService _dados;

    public AdminController(DadosMemoriaService dados)
    {
        _dados = dados;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View(new LoginViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (model.Usuario == "techlead" && model.Senha == "123456")
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Tech Líder"),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return RedirectToAction(nameof(Dashboard));
        }

        ViewBag.Erro = "Usuário ou senha inválidos.";
        return View(model);
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Dashboard()
    {
        var solicitacoes = _dados.ListarSolicitacoes();
        return View(solicitacoes);
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Aprovar(int id)
    {
        _dados.AprovarSolicitacao(id);
        return RedirectToAction(nameof(Dashboard));
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Reprovar(int id)
    {
        _dados.ReprovarSolicitacao(id);
        return RedirectToAction(nameof(Dashboard));
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction(nameof(Login));
    }
}

using ConsultoriaDev.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ConsultoriaDev.Models;

namespace ConsultoriaDev.Controllers;

public class HomeController : Controller
{
    private readonly DadosMemoriaService _dados;

    public HomeController(DadosMemoriaService dados)
    {
        _dados = dados;
    }

    public IActionResult Index()
    {
        var problemas = _dados.ListarProblemas();
        return View(problemas);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

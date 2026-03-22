using ConsultoriaDev.Models;
using ConsultoriaDev.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsultoriaDev.Controllers;

public class SolicitacaoController : Controller
{
    private readonly DadosMemoriaService _dados;

    public SolicitacaoController(DadosMemoriaService dados)
    {
        _dados = dados;
    }

    [HttpGet]
    public IActionResult Criar(int problemaId)
    {
        var problema = _dados.ObterProblema(problemaId);
        if (problema is null)
        {
            return RedirectToAction("Index", "Home");
        }

        var model = new Solicitacao
        {
            ProblemaId = problema.Id,
            ProblemaNome = problema.Nome
        };

        ViewBag.Problema = problema;
        return View(model);
    }

    [HttpPost]
    public IActionResult Criar(Solicitacao model)
    {
        var problema = _dados.ObterProblema(model.ProblemaId);
        if (problema is null)
        {
            return RedirectToAction("Index", "Home");
        }

        if (!ModelState.IsValid)
        {
            ViewBag.Problema = problema;
            return View(model);
        }

        model.ProblemaNome = problema.Nome;
        _dados.AdicionarSolicitacao(model);

        TempData["MensagemSucesso"] = "Seu pedido foi solicitado com sucesso.";
        return RedirectToAction("Index", "Home");
    }
}

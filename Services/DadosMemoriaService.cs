using ConsultoriaDev.Models;

namespace ConsultoriaDev.Services;

public class DadosMemoriaService
{
    private readonly List<Problema> _problemas;
    private readonly List<Solicitacao> _solicitacoes;
    private readonly List<DevDisponivel> _devs;
    private int _ultimoId = 0;

    public DadosMemoriaService()
    {
        _problemas = new List<Problema>
        {
            new() { Id = 1, Nome = "Correção de Bug Crítico", Descricao = "Análise e correção de falhas que impedem o funcionamento do sistema.", TempoResposta = "Até 4 horas", Preco = 350.00m },
            new() { Id = 2, Nome = "Melhoria de Performance", Descricao = "Otimização de telas, consultas e processos lentos.", TempoResposta = "Até 24 horas", Preco = 550.00m },
            new() { Id = 3, Nome = "Implementação de Nova Funcionalidade", Descricao = "Desenvolvimento de pequenas funcionalidades sob demanda.", TempoResposta = "Até 48 horas", Preco = 900.00m },
            new() { Id = 4, Nome = "Integração com API", Descricao = "Integração com serviços externos, gateways ou sistemas parceiros.", TempoResposta = "Até 72 horas", Preco = 1200.00m }
        };

        _solicitacoes = new List<Solicitacao>();

        _devs = new List<DevDisponivel>
        {
            new() { Nome = "Felipe Dev", WhatsApp = "5511991111111", Disponivel = true },
            new() { Nome = "Erick Dev", WhatsApp = "5511992222222", Disponivel = true },
            new() { Nome = "Victor Dev", WhatsApp = "5511993333333", Disponivel = false }
        };
    }

    public List<Problema> ListarProblemas() => _problemas;
    public List<Solicitacao> ListarSolicitacoes() => _solicitacoes.OrderByDescending(s => s.DataSolicitacao).ToList();
    public Problema? ObterProblema(int id) => _problemas.FirstOrDefault(p => p.Id == id);
    public Solicitacao? ObterSolicitacao(int id) => _solicitacoes.FirstOrDefault(s => s.Id == id);

    public void AdicionarSolicitacao(Solicitacao solicitacao)
    {
        _ultimoId++;
        solicitacao.Id = _ultimoId;
        solicitacao.Status = "Pendente";
        solicitacao.DataSolicitacao = DateTime.Now;
        _solicitacoes.Add(solicitacao);
    }

    public void AprovarSolicitacao(int id)
    {
        var solicitacao = ObterSolicitacao(id);
        if (solicitacao is null)
        {
            return;
        }

        var dev = _devs.FirstOrDefault(d => d.Disponivel);
        solicitacao.Status = "Aprovada";

        if (dev is not null)
        {
            solicitacao.DevResponsavel = dev.Nome;
            solicitacao.WhatsAppDev = dev.WhatsApp;
            dev.Disponivel = false;
        }
        else
        {
            solicitacao.DevResponsavel = "Sem dev disponível no momento";
            solicitacao.WhatsAppDev = null;
        }
    }

    public void ReprovarSolicitacao(int id)
    {
        var solicitacao = ObterSolicitacao(id);
        if (solicitacao is null)
        {
            return;
        }

        solicitacao.Status = "Reprovada";
        solicitacao.DevResponsavel = null;
        solicitacao.WhatsAppDev = null;
    }
}

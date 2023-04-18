using System.Text.Json;
using Aliens.Models;

namespace Aliens.Services;
public class AlienService : IAliensService
{
    private readonly IHttpContextAccessor _session;
    private readonly string aliensFile = @"Data\aliens.json";
    private readonly string tiposFile = @"Data\tipos.json";
    public AliensService(IHttpContextAccessor session)
    {   
        _session = session;
        PopularSessao();
    }
    public List<Aliens> GetAliens()
    {
         PopularSessao();
        var aliens = JsonSerializer.Deserialize<List<Aliens>>
        (_session.HttpContext.Session.GetString("Aliens"));
        return aliens;
    }
    public List<Tipo> GetTipos()
    {
        PopularSessao();
        var tipos = JsonSerializer.Deserialize<List<Tipo>>
        (_session.HttpContext.Session.GetString("Tipos"));
        return tipos;
    }
    public Aliens GetAlien(int Numero)
    {
        var aliens = GetAliens();
        return aliens.Where(p => p.Numero == Numero).FirstOrDefault();
    }
    public AliensDto GetAliensDto()
    {
        var aliens = new AliensDto()
        {
            Aliens = GetAliens(),
            Tipos = GetTipos()
        };
        return aliens;
    }

    public DetailsDto GetDetailedAlien(int Numero)
     {
        var aliens = GetAliens();
        var aliens = new DetailsDto()
        {
            Current = aliens.Where(p => p.Numero == Numero)
            .FirstOrDefault(),
            Prior = aliens.OrderByDescending(p => p.Numero)
            .FirstOrDefault(p => p.Numero < Numero),
            Next = aliens.OrderBy(p => p.Numero)
            .FirstOrDefault(p => p.Numero > Numero),
        };
        return aliens;
    }
    public Tipo GetTipo(string Nome)
    {
        var tipos = GetTipos();
        return tipos.Where(t => t.Nome == Nome).FirstOrDefault();
    }

    private void PopularSessao()
    {
        if (string.IsNullOrEmpty(_session.HttpContext.Session.GetString("Tipos")))
        {
            _session.HttpContext.Session
            .SetString("Aliens", LerArquivo(aliensFile));
            _session.HttpContext.Session
            .SetString("Tipos", LerArquivo(tiposFile));
        }
    }
    private string LerArquivo(string fileName)
    {
        using (StreamReader leitor = new StreamReader(fileName))
        {
            string dados = leitor.ReadToEnd();
            return dados;
        }
    }
}
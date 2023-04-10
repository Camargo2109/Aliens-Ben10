using System.Text.Json;
using Aliens.Models;
namespace Aliens.Services;
public class AlienService : IAlienService
{
    private readonly IHttpContextAccessor _session;
    private readonly string aliensFile = @"Data\aliens.json";
    private readonly string tiposFile = @"Data\tipos.json";
    public AlienService(IHttpContextAccessor session)
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
    public Alien GetAlien(int Numero)
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
        var Aliens = GetAliens();
        var aliens = new DetailsDto()
        {
            Current = Aliens.Where(p => p.Numero == Numero)
            .FirstOrDefault(),
            Prior = Aliens.OrderByDescending(p => p.Numero)
            .FirstOrDefault(p => p.Numero < Numero),
            Next = Aliens.OrderBy(p => p.Numero)
            .FirstOrDefault(p => p.Numero > Numero),
        };
        return Alien;
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
            .SetString("Aliens", LerArquivo(alienFile));
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
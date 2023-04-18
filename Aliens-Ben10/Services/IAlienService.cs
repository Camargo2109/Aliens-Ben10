using Aliens.Models;
namespace Aliens.Services;
public interface IAlienService
{
    List<Aliens> GetAliens();
    List<Tipo> GetTipos();
    Aliens GetAliens(int Numero);
    AliensDto GetAliensDto();
    DetailsDto GetDetailedAliens(int Numero);
    Tipo GetTipo(string Nome);
}   
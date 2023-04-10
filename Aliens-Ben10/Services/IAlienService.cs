using Aliens.Models;
namespace Aliens.Services;
public interface IAlienService
{
    List<Aliens> GetAliens();
    List<Tipo> GetTipos();
    Aliens GetAlien(int Numero);
    AliensDto GetAliensDto();
    DetailsDto GetDetailedAliens(int Numero);
    Tipo GetTipo(string Nome);
}   
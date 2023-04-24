using Aliens_Ben10.Models;
namespace Aliens.Services;
public interface IAliensBenServices
{
    List<Aliens10> GetAliens();
    List<Tipo> GetTipos();
    Aliens10 GetAliens(int Numero);
    AliensDto GetAliensDto();
    DetailsDto GetDetailedAliens(int Numero);
    Tipo GetTipo(string Nome);
}   

namespace Aliens_Ben10.Models;
public class Aliens10 
{
    //Atributos
     public int Numero {get; set;}
    public string Nome {get; set;}
    public string Descricao {get; set;}
    public string Especie {get; set;}
    public List<Tipo> Tipos {get; set;}
    public string Imagem{get; set;}
    
            public Aliens10()
    {
            Tipo = new List<string>();
    }

}   
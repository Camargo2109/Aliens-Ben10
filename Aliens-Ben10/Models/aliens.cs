
namespace Aliens_Ben10.Models
{
    public class aliens
    {
        //Atributos
        public string Numero {get; set;}
        public string Nome {get; set;}
        public string Descrição {get; set;}
        public string Especie {get; set;}
        public string Altura {get; set;}
        public string Peso {get; set;}
        public string Tipo {get; set;}
        public string Imagem{get; set;}

        //Método Construtor
        public Aliens()
        {
            Tipo = new List<string>();
        }

    }
}
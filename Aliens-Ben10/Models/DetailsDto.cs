

namespace Aliens_Ben10.Models
{
    public class DetailsDto
    {
        public Aliens10 Prior {get; set;}
        public Aliens10 Current {get; set;}
        public Aliens10 Next {get; set;}
        public List<Tipo> Tipos { get; set;}

    }
}
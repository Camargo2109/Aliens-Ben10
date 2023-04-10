

namespace Aliens_Ben10.Models
{
    public class DetailsDto
    {
        public Aliens Prior {get; set;}
        public Aliens Current {get; set;}
        public Aliens Next {get; set;}
        public List<Tipo> Tipos { get; set;}

    }
}
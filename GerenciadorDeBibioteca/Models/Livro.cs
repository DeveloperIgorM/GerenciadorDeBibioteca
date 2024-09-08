namespace GerenciadorDeBibioteca.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Isbn { get; set; }
        public DateTime Ano_publicacao{ get; set; }
        public string faculdade_id { get; set; }
            
    }
}

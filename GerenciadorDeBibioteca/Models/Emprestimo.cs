namespace GerenciadorDeBibioteca.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public int Usuario_id { get; set; }
        public int Livro_id { get; set; }
        public DateTime DateTime { get; set; }

        public DateTime Data_devolucao { get; set; }

    }
}

namespace ProjetoAnime.Core.Entidade
{
    public class Anime
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Diretor { get; set; }
        public  string Resumo { get; set; }
    }
}

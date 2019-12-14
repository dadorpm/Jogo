
namespace Jogo.Models
{
    public class Jogador
    {
        public int JogadorId { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int NacionalidadeId { get; set; }
        public virtual Nacionalidade Nacionalidade { get; set; }

    }
}

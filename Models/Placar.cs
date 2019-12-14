using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jogo.Models
{
    public class Placar
    {
        public int PlacarId { get; set; }
        public string Name { get; set; }
        public int JogadorId { get; set; }
        public virtual Jogador Jogador { get; set; }
        public ulong Pontos { get; set; }
        public DateTime Data { get; set; }
    }
}

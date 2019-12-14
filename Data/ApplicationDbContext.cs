using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Jogo.Models;

namespace Jogo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Jogo.Models.Jogador> Jogador { get; set; }
        public DbSet<Jogo.Models.Nacionalidade> Nacionalidade { get; set; }
        public DbSet<Jogo.Models.Placar> Placar { get; set; }
    }
}

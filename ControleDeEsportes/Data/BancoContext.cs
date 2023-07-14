using ControleDeEsportes.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEsportes.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }
        public DbSet<EspacoModel> Espacos { get; set; }
    }
}

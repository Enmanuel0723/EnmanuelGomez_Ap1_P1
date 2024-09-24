using EnmanuelGomez_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace EnmanuelGomez_Ap1_P1.DAL
{
    public class Contexto : DbContext

    {
        DbSet<Registros> Registros { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    }
}

using EnmanuelGomez_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace EnmanuelGomez_Ap1_P1.DAL;
using Microsoft.EntityFrameworkCore;


public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
{

    public DbSet<Prestamos> Prestamos { get; set; }
}
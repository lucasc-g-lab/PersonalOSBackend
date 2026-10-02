using Microsoft.EntityFrameworkCore;
using PersonalOSBackend.Models;

namespace PersonalOSBackend.Data;

public class AppDbContext : DbContext
{
    // Construtor obrigatório para configurar a ligação
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Estas são as tabelas que vão ser criadas no SQLite
    public DbSet<Financeiro> Financeiros { get; set; }
    public DbSet<ContaPartilhada> ContasPartilhadas { get; set; }
    public DbSet<Treino> Treinos { get; set; }
    public DbSet<Refeicao> Refeicoes { get; set; }
}
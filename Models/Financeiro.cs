namespace PersonalOSBackend.Models;

public class Financeiro
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public string Tipo { get; set; } = string.Empty; // Ex: "Receita" ou "Despesa"
    public DateTime Data { get; set; }
    public string Categoria { get; set; } = string.Empty; // Ex: "Supermercado", "Renda", "Lazer"
    public bool Partilhado { get; set; } // Verdadeiro se dividiu esta conta com alguém
}
namespace PersonalOSBackend.Models;

public class Treino
{
    public int Id { get; set; }
    public string Tipo { get; set; } = string.Empty; // Ex: "Musculação", "Esteira"
    public string? GrupoMuscular { get; set; } // Ex: "Peito e Tríceps"
    public DateTime Data { get; set; }
    public int DuracaoMinutos { get; set; }
    public string? Observacoes { get; set; }
}
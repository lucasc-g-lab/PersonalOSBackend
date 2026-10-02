namespace PersonalOSBackend.Models;

public class Refeicao
{
    public int Id { get; set; }
    public string DiaDaSemana { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty; // Ex: "Almoço", "Jantar"
    public string PratoPrincipal { get; set; } = string.Empty;
    public string Status { get; set; } = "Planejado"; // Pode ser "Planejado" ou "Preparado"
}
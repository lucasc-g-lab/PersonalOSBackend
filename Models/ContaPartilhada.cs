namespace PersonalOSBackend.Models;

public class ContaPartilhada
{
    public int Id { get; set; }
    public int FinanceiroId { get; set; }
    public Financeiro? Financeiro { get; set; } // Faz a ligação com a despesa principal
    public string NomeDaPessoa { get; set; } = string.Empty; // Serve para qualquer pessoa (amigo, familiar, etc.)
    public decimal ValorParte { get; set; }
    public bool EstaPago { get; set; }
}
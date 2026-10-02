using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. CONFIGURAÇÃO DA PORTA PARA A NUVEM (RENDER)
builder.WebHost.UseUrls($"http://0.0.0.0:{Environment.GetEnvironmentVariable("PORT") ?? "5212"}");

// 2. CONFIGURAÇÃO DO BANCO DE DADOS (SQLITE)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=app.db"));

// 3. CONFIGURAÇÃO DE CORS (PERMITIR ACESSO DO APLICATIVO EM QUALQUER REDE)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAll");

// 4. GARANTE QUE O BANCO DE DADOS É CRIADO NA NUVEM AO INICIAR
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.UseSwagger();
app.UseSwaggerUI();

// ==========================================
// ENDPOINTS DE FINANÇAS
// ==========================================
app.MapGet("/api/financeiro", async (AppDbContext db) => await db.Financeiros.ToListAsync());

app.MapPost("/api/financeiro", async (AppDbContext db, Financeiro novaDespesa) =>
{
    db.Financeiros.Add(novaDespesa);
    await db.SaveChangesAsync();
    return Results.Created($"/api/financeiro/{novaDespesa.Id}", novaDespesa);
});

app.MapPut("/api/financeiro/{id}", async (int id, AppDbContext db, Financeiro despesaAtualizada) =>
{
    if (id != despesaAtualizada.Id) return Results.BadRequest();
    db.Entry(despesaAtualizada).State = EntityState.Modified;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/api/financeiro/{id}", async (int id, AppDbContext db) =>
{
    var despesa = await db.Financeiros.FindAsync(id);
    if (despesa is null) return Results.NotFound();
    db.Financeiros.Remove(despesa);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

// ==========================================
// ENDPOINTS DE TREINOS
// ==========================================
app.MapGet("/api/treinos", async (AppDbContext db) => await db.Treinos.ToListAsync());

app.MapPost("/api/treinos", async (AppDbContext db, Treino novoTreino) =>
{
    db.Treinos.Add(novoTreino);
    await db.SaveChangesAsync();
    return Results.Created($"/api/treinos/{novoTreino.Id}", novoTreino);
});

app.MapDelete("/api/treinos/{id}", async (int id, AppDbContext db) =>
{
    var treino = await db.Treinos.FindAsync(id);
    if (treino is null) return Results.NotFound();
    db.Treinos.Remove(treino);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

// ==========================================
// ENDPOINTS DE REFEIÇÕES
// ==========================================
app.MapGet("/api/refeicoes", async (AppDbContext db) => await db.Refeicoes.ToListAsync());

app.MapPost("/api/refeicoes", async (AppDbContext db, Refeicao novaRefeicao) =>
{
    db.Refeicoes.Add(novaRefeicao);
    await db.SaveChangesAsync();
    return Results.Created($"/api/refeicoes/{novaRefeicao.Id}", novaRefeicao);
});

app.MapDelete("/api/refeicoes/{id}", async (int id, AppDbContext db) =>
{
    var refeicao = await db.Refeicoes.FindAsync(id);
    if (refeicao is null) return Results.NotFound();
    db.Refeicoes.Remove(refeicao);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
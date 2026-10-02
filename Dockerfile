# Usa a imagem do SDK do .NET 8 para compilar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia o ficheiro do projeto e restaura as dependências
COPY *.csproj ./
RUN dotnet restore

# Copia o resto do código e gera a versão de publicação
COPY . ./
RUN dotnet publish -c Release -o out

# Usa a imagem otimizada do ASP.NET para correr a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Inicia a aplicação indicando a tua DLL
ENTRYPOINT ["dotnet", "PersonalOSBackend.dll"]
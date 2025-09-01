#tempo de execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

#build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["ProjetoAnime/ProjetoAnime.csproj", "ProjetoAnime/"]
RUN dotnet restore "ProjetoAnime/ProjetoAnime.csproj"

COPY . .
WORKDIR "/src/ProjetoAnime"
RUN dotnet build "ProjetoAnime.csproj" -c Release -o /app/build

#Publicação
FROM build AS publish
RUN dotnet publish "ProjetoAnime.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjetoAnime.dll"]

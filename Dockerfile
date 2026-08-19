# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AgendaBackend.csproj", "./"]
RUN dotnet restore "AgendaBackend.csproj"
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Etapa de ejecución (Base Debian para evitar el error 139)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "AgendaBackend.dll"]
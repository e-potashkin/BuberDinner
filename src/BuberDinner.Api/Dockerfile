FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/BuberDinner.Api/BuberDinner.Api.csproj", "src/BuberDinner.Api/"]
COPY ["src/BuberDinner.Contracts/BuberDinner.Contracts.csproj", "src/BuberDinner.Contracts/"]
COPY ["src/BuberDinner.Application/BuberDinner.Application.csproj", "src/BuberDinner.Application/"]
COPY ["src/BuberDinner.Domain/BuberDinner.Domain.csproj", "src/BuberDinner.Domain/"]
COPY ["src/BuberDinner.Infrastructure/BuberDinner.Infrastructure.csproj", "src/BuberDinner.Infrastructure/"]
COPY ["src/BuberDinner.Persistence/BuberDinner.Persistence.csproj", "src/BuberDinner.Persistence/"]
RUN dotnet restore "src/BuberDinner.Api/BuberDinner.Api.csproj"
COPY . .
WORKDIR "/src/src/BuberDinner.Api"
RUN dotnet build "BuberDinner.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BuberDinner.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BuberDinner.Api.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ./.editorconfig ./StyleCop.ruleset ./Directory.*.props ./

COPY ["./src/BuildingBlocks/Infrastructure/BuildingBlocks.Infrastructure.csproj", "BuildingBlocks/Infrastructure/"]
COPY ["./src/BuildingBlocks/Domain/BuildingBlocks.Domain.csproj", "BuildingBlocks/Domain/"]
COPY ["./src/BuildingBlocks/Application/BuildingBlocks.Application.csproj", "BuildingBlocks/Application/"]

COPY ["./src/Modules/BuberDinner/BuberDinner.Api/BuberDinner.Api.csproj", "Modules/BuberDinner/BuberDinner.Api/"]
COPY ["./src/Modules/BuberDinner/BuberDinner.Application/BuberDinner.Application.csproj", "Modules/BuberDinner/BuberDinner.Application/"]
COPY ["./src/Modules/BuberDinner/BuberDinner.Contracts/BuberDinner.Contracts.csproj", "Modules/BuberDinner/BuberDinner.Contracts/"]
COPY ["./src/Modules/BuberDinner/BuberDinner.Domain/BuberDinner.Domain.csproj", "Modules/BuberDinner/BuberDinner.Domain/"]
COPY ["./src/Modules/BuberDinner/BuberDinner.Infrastructure/BuberDinner.Infrastructure.csproj", "Modules/BuberDinner/BuberDinner.Infrastructure/"]

RUN for file in $(ls *.csproj); do mkdir -p ./${file%.*}/ && mv $file ./${file%.*}/; done
RUN dotnet restore "Modules/BuberDinner/BuberDinner.Api/BuberDinner.Api.csproj"
COPY ./src .
WORKDIR "/src/Modules/BuberDinner/BuberDinner.Api"
RUN dotnet build "BuberDinner.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BuberDinner.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BuberDinner.Api.dll"]

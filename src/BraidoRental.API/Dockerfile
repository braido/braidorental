#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["BraidoRental.API/BraidoRental.API.csproj", "BraidoRental.API/"]
COPY ["Services/BraidoRental.Services.Application/BraidoRental.Services.Application.csproj", "Services/BraidoRental.Services.Application/"]
COPY ["Core/Domain/BraidoRental.Core.Domain/BraidoRental.Core.Domain.csproj", "Core/Domain/BraidoRental.Core.Domain/"]
COPY ["Services/Domain/BraidoRental.Services.Locadora.Domain/BraidoRental.Services.Locadora.Domain.csproj", "Services/Domain/BraidoRental.Services.Locadora.Domain/"]
COPY ["Services/Domain/BraidoRental.Services.Estoque.Domain/BraidoRental.Services.Estoque.Domain.csproj", "Services/Domain/BraidoRental.Services.Estoque.Domain/"]
COPY ["Services/Domain/BraidoRental.Services.Faturamento.Domain/BraidoRental.Services.Faturamento.Domain.csproj", "Services/Domain/BraidoRental.Services.Faturamento.Domain/"]
COPY ["Services/BraidoRental.Services.Infrastructure/BraidoRental.Services.Infrastructure.csproj", "Services/BraidoRental.Services.Infrastructure/"]
COPY ["Core/Infrastructure/BraidoRental.Core.Infrastructure.Repository/BraidoRental.Core.Infrastructure.Repository.csproj", "Core/Infrastructure/BraidoRental.Core.Infrastructure.Repository/"]
RUN dotnet restore "BraidoRental.API/BraidoRental.API.csproj"
COPY . .
WORKDIR "/src/BraidoRental.API"
RUN dotnet build "BraidoRental.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BraidoRental.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BraidoRental.API.dll"]

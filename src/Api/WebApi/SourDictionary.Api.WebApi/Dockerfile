#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Api/WebApi/SourDictionary.Api.WebApi/SourDictionary.Api.WebApi.csproj", "src/Api/WebApi/SourDictionary.Api.WebApi/"]
COPY ["src/Api/Infrastructure/SourDictionary.Infrastructure.Persistence/SourDictionary.Infrastructure.Persistence.csproj", "src/Api/Infrastructure/SourDictionary.Infrastructure.Persistence/"]
COPY ["src/Api/Core/SourDictionary.Api.Application/SourDictionary.Api.Application.csproj", "src/Api/Core/SourDictionary.Api.Application/"]
COPY ["src/Api/Core/SourDictionary.Api.Domain/SourDictionary.Api.Domain.csproj", "src/Api/Core/SourDictionary.Api.Domain/"]
COPY ["src/Common/SourDictionary.Common/SourDictionary.Common.csproj", "src/Common/SourDictionary.Common/"]
RUN dotnet restore "src/Api/WebApi/SourDictionary.Api.WebApi/SourDictionary.Api.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Api/WebApi/SourDictionary.Api.WebApi"
RUN dotnet build "SourDictionary.Api.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SourDictionary.Api.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SourDictionary.Api.WebApi.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Projections/SourDictionary.Projections.FavoriteService/SourDictionary.Projections.FavoriteService.csproj", "src/Projections/SourDictionary.Projections.FavoriteService/"]
COPY ["src/Common/SourDictionary.Common/SourDictionary.Common.csproj", "src/Common/SourDictionary.Common/"]
RUN dotnet restore "src/Projections/SourDictionary.Projections.FavoriteService/SourDictionary.Projections.FavoriteService.csproj"
COPY . .
WORKDIR "/src/src/Projections/SourDictionary.Projections.FavoriteService"
RUN dotnet build "SourDictionary.Projections.FavoriteService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SourDictionary.Projections.FavoriteService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SourDictionary.Projections.FavoriteService.dll"]
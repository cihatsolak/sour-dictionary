#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Projections/SourDictionary.Projections.UserService/SourDictionary.Projections.UserService.csproj", "src/Projections/SourDictionary.Projections.UserService/"]
COPY ["src/Common/SourDictionary.Common/SourDictionary.Common.csproj", "src/Common/SourDictionary.Common/"]
RUN dotnet restore "src/Projections/SourDictionary.Projections.UserService/SourDictionary.Projections.UserService.csproj"
COPY . .
WORKDIR "/src/src/Projections/SourDictionary.Projections.UserService"
RUN dotnet build "SourDictionary.Projections.UserService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SourDictionary.Projections.UserService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SourDictionary.Projections.UserService.dll"]
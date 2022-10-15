#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Projections/SourDictionary.Projections.VoteService/SourDictionary.Projections.VoteService.csproj", "src/Projections/SourDictionary.Projections.VoteService/"]
COPY ["src/Common/SourDictionary.Common/SourDictionary.Common.csproj", "src/Common/SourDictionary.Common/"]
RUN dotnet restore "src/Projections/SourDictionary.Projections.VoteService/SourDictionary.Projections.VoteService.csproj"
COPY . .
WORKDIR "/src/src/Projections/SourDictionary.Projections.VoteService"
RUN dotnet build "SourDictionary.Projections.VoteService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SourDictionary.Projections.VoteService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SourDictionary.Projections.VoteService.dll"]
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
COPY . ./
#RUN dotnet publish -c Release -o output
RUN dotnet publish "src/Clients/BlazorWeb/SourDictionary.WebApp/SourDictionary.WebApp.csproj" -c Release -o /app/build

FROM nginx:alpine
WORKDIR /var/www/web
COPY --from=build-env /app/build/wwwroot
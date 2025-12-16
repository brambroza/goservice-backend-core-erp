FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY *.sln ./
COPY CoreERPService.csproj .
RUN dotnet restore CoreERPService.csproj
COPY . .
RUN dotnet publish CoreERPService.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "CoreERPService.dll"]

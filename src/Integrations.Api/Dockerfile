FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY ["src/Integrations.Api/Integrations.Api.csproj", "src/Integrations.Api/"]

RUN dotnet restore "src/Integrations.Api/Integrations.Api.csproj"

COPY . .

WORKDIR /src/src/Integrations.Api

RUN dotnet publish "Integrations.Api.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore \
    /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT [ "dotnet", "Integrations.Api.dll" ]

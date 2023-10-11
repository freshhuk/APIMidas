FROM mcr.microsoft.com/dotnet/aspnet:7.0-windowsservercore-ltsc2019 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0-windowsservercore-ltsc2019 AS build
WORKDIR /src
COPY ["APIMidas/APIMidas.csproj", "APIMidas/"]
RUN dotnet restore "APIMidas/APIMidas.csproj"
COPY . .
WORKDIR "/src/APIMidas"
RUN dotnet build "APIMidas.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "APIMidas.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APIMidas.dll"]

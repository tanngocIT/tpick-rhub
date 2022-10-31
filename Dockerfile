FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TPick.RHub.Hub/TPick.RHub.Hub.csproj", "TPick.RHub.Hub/"]
COPY ["CsMicro/", "CsMicro/"]
RUN dotnet restore "TPick.RHub.Hub/TPick.RHub.Hub.csproj"
COPY . .
WORKDIR "/src/TPick.RHub.Hub"
RUN dotnet build "TPick.RHub.Hub.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TPick.RHub.Hub.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TPick.RHub.Hub.dll"]

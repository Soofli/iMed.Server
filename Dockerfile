FROM registry.vnfco.ir/library/dotnet/aspnet:7.0 AS base
ENV ASPNETCORE_URLS=http://0.0.0.0:8010
WORKDIR /app
EXPOSE 8010

FROM registry.vnfco.ir/library/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NuGet.config", ""]
COPY ["iMed.Server/iMed.Server.csproj", "iMed.Server/"]
RUN dotnet restore "iMed.Server/iMed.Server.csproj" --configfile NuGet.config
COPY . .
WORKDIR "/src/iMed.Server"
RUN dotnet build "iMed.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "iMed.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "iMed.Server.dll"]

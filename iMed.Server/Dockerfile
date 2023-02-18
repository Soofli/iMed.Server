#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["iMed.Server/iMed.Server.csproj", "iMed.Server/"]
#RUN dotnet restore "iMed.Server/iMed.Server.csproj"
#COPY . .
#WORKDIR "/src/iMed.Server"
#RUN dotnet build "iMed.Server.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "iMed.Server.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "iMed.Server.dll"]

FROM registry.vnfco.ir/library/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM registry.vnfco.ir/library/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["iMed.Server/iMed.Server.csproj", "iMed.Server/"]
RUN dotnet restore "iMed.Server/iMed.Server.csproj"
COPY . .
WORKDIR "/src/iMed.Server"
RUN dotnet build "iMed.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "iMed.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "iMed.Server.dll"]
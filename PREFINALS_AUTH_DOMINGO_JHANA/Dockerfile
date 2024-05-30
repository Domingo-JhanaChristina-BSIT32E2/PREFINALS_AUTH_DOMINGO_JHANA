#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PREFINALS_AUTH_DOMINGO_JHANA/PREFINALS_AUTH_DOMINGO_JHANA.csproj", "PREFINALS_AUTH_DOMINGO_JHANA/"]
RUN dotnet restore "PREFINALS_AUTH_DOMINGO_JHANA/PREFINALS_AUTH_DOMINGO_JHANA.csproj"
COPY . .
WORKDIR "/src/PREFINALS_AUTH_DOMINGO_JHANA"
RUN dotnet build "PREFINALS_AUTH_DOMINGO_JHANA.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PREFINALS_AUTH_DOMINGO_JHANA.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PREFINALS_AUTH_DOMINGO_JHANA.dll"]
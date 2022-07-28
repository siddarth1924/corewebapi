FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5099

ENV ASPNETCORE_URLS=http://+:5099

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["corewebapi.csproj", "./"]
RUN dotnet restore "corewebapi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "corewebapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "corewebapi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "corewebapi.dll"]

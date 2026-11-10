FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["catch-up-platform.sln", "./"]
COPY ["CatchUpPlatform.API/CatchUpPlatform.API.csproj", "CatchUpPlatform.API/"]

RUN dotnet restore "CatchUpPlatform.API/CatchUpPlatform.API.csproj"

COPY . .
WORKDIR "/src/CatchUpPlatform.API"
RUN dotnet build "CatchUpPlatform.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CatchUpPlatform.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CatchUpPlatform.API.dll"]

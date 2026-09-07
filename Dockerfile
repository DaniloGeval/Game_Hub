FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Game_Hub/Game_Hub.csproj", "Game_Hub/"]
RUN dotnet restore "Game_Hub/Game_Hub.csproj"
COPY . .
WORKDIR "/src/Game_Hub"
RUN dotnet publish "Game_Hub.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Game_Hub.dll"]

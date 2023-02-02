FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GoalkeeperSchoolAPI/GoalkeeperSchoolAPI.csproj", "GoalkeeperSchoolAPI/"]
RUN dotnet restore "GoalkeeperSchoolAPI/GoalkeeperSchoolAPI.csproj"
COPY . .
WORKDIR "/src/GoalkeeperSchoolAPI"
RUN dotnet build "GoalkeeperSchoolAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GoalkeeperSchoolAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GoalkeeperSchoolAPI.dll"]

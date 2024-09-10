#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Database6/MongoDBData.csproj", "Database6/"]
RUN dotnet restore "Database6/MongoDBData.csproj"
COPY . .
WORKDIR "/src/Database6"
RUN dotnet build "MongoDBData.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MongoDBData.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MongoDBData.dll"]
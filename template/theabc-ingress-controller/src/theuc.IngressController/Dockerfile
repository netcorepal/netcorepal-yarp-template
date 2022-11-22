#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["src/theuc.IngressController/theuc.IngressController.csproj", "src/theuc.IngressController/"]
RUN dotnet restore "src/theuc.IngressController/theuc.IngressController.csproj"
COPY . .
WORKDIR "/src/src/theuc.IngressController"
RUN dotnet build "theuc.IngressController.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "theuc.IngressController.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "theuc.IngressController.dll"]
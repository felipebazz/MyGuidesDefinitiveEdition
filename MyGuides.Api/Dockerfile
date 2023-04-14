#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MyGuides.Api/MyGuides.Api.csproj", "MyGuides.Api/"]
COPY ["MyGuides.Startup/MyGuides.Startup.csproj", "MyGuides.Startup/"]
COPY ["MyGuides.Application/MyGuides.Application.csproj", "MyGuides.Application/"]
COPY ["MyGuides.Domain/MyGuides.Domain.csproj", "MyGuides.Domain/"]
COPY ["MyGuides.Notifications/MyGuides.Notifications.csproj", "MyGuides.Notifications/"]
COPY ["MyGuides.Infra.Data/MyGuides.Infra.Data.csproj", "MyGuides.Infra.Data/"]
COPY ["MyGuides.Utils/MyGuides.Utils.csproj", "MyGuides.Utils/"]
COPY ["Steam.Api/Steam.Api.csproj", "Steam.Api/"]
RUN dotnet restore "MyGuides.Api/MyGuides.Api.csproj"
COPY . .
WORKDIR "/src/MyGuides.Api"
RUN dotnet build "MyGuides.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyGuides.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyGuides.Api.dll"]
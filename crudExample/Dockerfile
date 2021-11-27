#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["crudExample/crudExample.csproj", "crudExample/"]
COPY ["Application/crudExample.Application.csproj", "Application/"]
COPY ["crudExample.Infrastructure/crudExample.Infrastructure.csproj", "crudExample.Infrastructure/"]
COPY ["crudExample.Domain/crudExample.Domain.csproj", "crudExample.Domain/"]
RUN dotnet restore "crudExample/crudExample.csproj"
COPY . .
WORKDIR "/src/crudExample"
RUN dotnet build "crudExample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "crudExample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "crudExample.dll"]
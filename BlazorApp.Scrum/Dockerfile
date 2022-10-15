#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BlazorApp.Scrum/BlazorApp.Scrum.csproj", "BlazorApp.Scrum/"]
RUN dotnet restore "BlazorApp.Scrum/BlazorApp.Scrum.csproj"
COPY . .
WORKDIR "/src/BlazorApp.Scrum"
RUN dotnet build "BlazorApp.Scrum.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorApp.Scrum.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorApp.Scrum.dll"]

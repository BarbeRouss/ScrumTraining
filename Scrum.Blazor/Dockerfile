#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Scrum.Blazor/Scrum.Blazor.csproj", "Scrum.Blazor/"]
RUN dotnet restore "Scrum.Blazor/Scrum.Blazor.csproj"
COPY . .
WORKDIR "/src/Scrum.Blazor"
RUN dotnet build "Scrum.Blazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Scrum.Blazor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Scrum.Blazor.dll"]
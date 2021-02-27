#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["megaphone.resources/megaphone.resources.csproj", "megaphone.resources/"]
RUN dotnet restore "megaphone.resources/megaphone.resources.csproj"
COPY . .
WORKDIR "/src/megaphone.resources"
RUN dotnet build "megaphone.resources.csproj" --no-restore -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "megaphone.resources.csproj" --no-build-c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "megaphone.resources.dll"]
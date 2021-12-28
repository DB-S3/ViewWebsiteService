#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ViewWebsiteService/ViewWebsiteService.csproj", "ViewWebsiteService/"]
COPY ["Logic/Logic.csproj", "Logic/"]
COPY ["Factory/Factory.csproj", "Factory/"]
COPY ["Data/Data.csproj", "Data/"]
COPY ["Common/Common.csproj", "Common/"]
RUN dotnet restore "ViewWebsiteService/ViewWebsiteService.csproj"
COPY . .
WORKDIR "/src/ViewWebsiteService"
RUN dotnet build "ViewWebsiteService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ViewWebsiteService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ViewWebsiteService.dll"]
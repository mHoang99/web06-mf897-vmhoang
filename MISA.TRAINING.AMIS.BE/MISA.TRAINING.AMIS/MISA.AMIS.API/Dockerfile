#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MISA.CukCuk.API/MISA.CukCuk.API.csproj", "MISA.CukCuk.API/"]
RUN dotnet restore "MISA.CukCuk.API/MISA.CukCuk.API.csproj"
COPY . .
WORKDIR "/src/MISA.CukCuk.API"
RUN dotnet build "MISA.CukCuk.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MISA.CukCuk.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MISA.CukCuk.API.dll"]
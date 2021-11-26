#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Moksnes.CurrencyConverter/Moksnes.CurrencyConverter.csproj", "Moksnes.CurrencyConverter/"]
RUN dotnet restore "Moksnes.CurrencyConverter/Moksnes.CurrencyConverter.csproj"
COPY . .
WORKDIR "/src/Moksnes.CurrencyConverter"
RUN dotnet build "Moksnes.CurrencyConverter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Moksnes.CurrencyConverter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Moksnes.CurrencyConverter.dll"]
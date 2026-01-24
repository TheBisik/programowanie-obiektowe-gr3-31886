# Etap budowania
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Kopiujemy pliki projektu i przywracamy zależności
COPY DiscountApp/*.csproj ./
RUN dotnet restore

# Kopiujemy resztę i publikujemy aplikację
COPY . ./
RUN dotnet publish "DiscountApp/DiscountApp.csproj" -c Release -o out

# Etap uruchamiania
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .

# PORT 8080:
ENV ASPNETCORE_HTTP_PORTS=8080

ENTRYPOINT ["dotnet", "DiscountApp.dll"]
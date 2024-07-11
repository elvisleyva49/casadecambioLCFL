# Use .NET SDK 8.0 base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /source

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY CasaDeCambioAPI/*.csproj ./CasaDeCambioAPI/
COPY CasaDeCambioApp/*.csproj ./CasaDeCambioApp/

RUN dotnet restore

# Copy everything else and build the application
COPY . .

# Publish the application
RUN dotnet publish -c Release -o /app
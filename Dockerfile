# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copia y restaura dependencias
COPY *.sln .
COPY CasaDeCambioApp/*.csproj ./CasaDeCambioApp/
RUN dotnet restore

# Copia todo y compila
COPY . .
WORKDIR /source/CasaDeCambioApp
RUN dotnet publish -c Release -o /app

# Etapa de publicación
FROM nginx:alpine AS runtime
COPY --from=build /app /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]

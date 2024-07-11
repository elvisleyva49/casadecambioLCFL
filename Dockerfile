# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copia el archivo de solución y el proyecto
COPY CasaDeCambioApp/*.csproj ./CasaDeCambioApp/
COPY *.sln .

# Restaura las dependencias del proyecto
RUN dotnet restore "CasaDeCambioApp/CasaDeCambioApp.csproj"

# Copia todo y compila el proyecto
COPY . .
WORKDIR /source/CasaDeCambioApp
RUN dotnet publish -c Release -o /app/publish

# Etapa de servidor
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=build /app/publish/wwwroot .

# Nota: No estamos copiando el archivo nginx.conf aquí
# Si no tienes un archivo nginx.conf personalizado, puedes eliminar la línea siguiente
# COPY nginx.conf /etc/nginx/nginx.conf

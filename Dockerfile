# Stage 1: Build the Blazor app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

COPY . .
RUN dotnet publish -c Release -o /app

# Stage 2: Serve the app with nginx
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=build /app/wwwroot .

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]

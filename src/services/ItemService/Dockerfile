# ========================================
# BUILD STAGE (SDK Image - for building)
# ========================================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set working directory
WORKDIR /src

# Copy solution and project files
COPY ["src/ItemService.API/ItemService.API.csproj", "src/ItemService.API/"]
COPY ["src/ItemService.Application/ItemService.Application.csproj", "src/ItemService.Application/"]
COPY ["src/ItemService.Domain/ItemService.Domain.csproj", "src/ItemService.Domain/"]
COPY ["src/ItemService.Infrastructure/MyApp.Infrastructure.csproj", "src/ItemService.Infrastructure/"]

# Restore NuGet packages
RUN dotnet restore "src/ItemService.API/ItemService.API.csproj"

# Copy all source code
COPY . .

# Publish the application
RUN dotnet publish "src/ItemService.API/ItemService.API.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore

# ========================================
# RUNTIME STAGE (ASP.NET Image - for execution)
# ========================================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set working directory
WORKDIR /app

# Create a non-root user
RUN adduser --disabled-password --gecos "" appuser && \
    chown appuser:appuser /app
USER appuser

# Copy from build stage
COPY --from=build --chown=appuser:appuser /app/publish .

# Expose ports (adjust as needed)
EXPOSE 5
ENV ASPNETCORE_URLS=http://+:8080

# Entry point
ENTRYPOINT ["dotnet", "ItemService.API.dll"]
# Use the official .NET SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /src

# Copy project files (adjusted for the new structure)
COPY src/fa.domain/fa.domain.csproj ./fa.domain/
COPY src/fa.application/fa.application.csproj ./fa.application/
COPY src/fa.infrastructure/fa.infrastructure.csproj ./fa.infrastructure/
COPY src/fa.api/fa.api.csproj ./fa.api/

# Restore dependencies
RUN dotnet restore src/fa.api/fa.api.csproj

# Copy all source files
COPY src/ .

# Build the application
RUN dotnet build src/fa.api/fa.api.csproj -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish src/fa.api/fa.api.csproj -c Release -o /app/publish

# Final stage: runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "fa.api.dll"]

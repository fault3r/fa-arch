FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src/JwtService.Api
COPY . ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /src/JwtService.Api/out ./
EXPOSE 5006
ENTRYPOINT ["dotnet", "JwtService.Api.dll"]

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src/SampleService.Api
COPY . ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 as final
WORKDIR /app
COPY --from=build /src/SampleService.Api/out ./
EXPOSE 5006
ENTRYPOINT ["dotnet", "SampleService.Api.dll"]
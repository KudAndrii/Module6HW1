FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /asp-api-app

# Copy csproj and restore as distinct layers
COPY ProductsWebAPI.sln ./
COPY ProductsWebAPI/*.csproj ./ProductsWebAPI/
COPY Core/*.csproj ./Core/
COPY Infrastructure/*.csproj ./Infrastructure/
COPY ProductsWebAPI/products.json ./

RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish ProductsWebAPI.sln -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0

ENV ASPNETCORE_URLS=http://*:8888
ENV ASPNETCORE_ENVIRONMENT=Development

USER 1000

WORKDIR /asp-api-app
COPY --from=build-env /asp-api-app/out .

EXPOSE 8080
ENTRYPOINT ["dotnet", "ProductsWebAPI.dll"]
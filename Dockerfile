# Create image based on the official .NET Core 7 runtime image from Microsoft
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Create image based on the official .NET Core 7 SDK image from Microsoft
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CartoMongo.csproj", ""]
RUN dotnet restore "./CartoMongo.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CartoMongo.csproj" -c Release -o /app/build

# Create final image using the base image and copying the build files
FROM base AS final
WORKDIR /app
COPY --from=build /app/build .
ENTRYPOINT ["dotnet", "CartoMongo.dll"]
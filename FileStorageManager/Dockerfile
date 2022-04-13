FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
RUN apt update
RUN apt install nodejs npm --assume-yes
RUN apt install build-essential --assume-yes
WORKDIR /app

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "FileStorageManager.dll"]
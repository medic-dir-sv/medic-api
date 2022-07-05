FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /.aws
COPY credentials .

WORKDIR /app

# Copy everything
COPY . .

# Restore as distinct layers
RUN dotnet restore

# Build and publish a release
RUN dotnet publish -c Release -o out
WORKDIR /app/out

EXPOSE 5000:5000
# ENTRYPOINT ["dotnet", "Medic.API.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Medic.API.dll
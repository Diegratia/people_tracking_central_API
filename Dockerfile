# Base SDK image for restoring and building
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution and project files for caching restore layer
COPY ["PeopleTrackingCentral.sln", "./"]
COPY ["CentralMonitoring.Domain/CentralMonitoring.Domain.csproj", "CentralMonitoring.Domain/"]
COPY ["CentralMonitoring.Application/CentralMonitoring.Application.csproj", "CentralMonitoring.Application/"]
COPY ["CentralMonitoring.Infrastructure/CentralMonitoring.Infrastructure.csproj", "CentralMonitoring.Infrastructure/"]
COPY ["CentralMonitoring.Presentation/CentralMonitoring.Presentation.csproj", "CentralMonitoring.Presentation/"]

# Restore dependencies
RUN dotnet restore "PeopleTrackingCentral.sln"

# Copy everything else and build the application
COPY . .
WORKDIR "/src/CentralMonitoring.Presentation"
RUN dotnet publish "CentralMonitoring.Presentation.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Configure port binding (binds to port 5200 inside container)
ENV ASPNETCORE_URLS=http://0.0.0.0:5200
EXPOSE 5200

ENTRYPOINT ["dotnet", "CentralMonitoring.Presentation.dll"]
